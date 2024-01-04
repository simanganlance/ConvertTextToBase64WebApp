using System;
using System.Text;
using System.Threading.Tasks;
using ConvertTextWebApp.Business.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace ConvertTextWebApp.Business.Services
{
    public class EncodingService : IEncodingService
    {
        private static readonly object _lock = new object();
        private static bool _isEncoding = false;
        private readonly IHubContext<EncodeHub> _hubContext;
        private readonly ILogger<EncodingService> _logger;

        public EncodingService(IHubContext<EncodeHub> hubContext, ILogger<EncodingService> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task<string> Encode(string input)
        {
            string base64 = "";
            if (_isEncoding)
            {
                throw new InvalidOperationException("Encoding in progress. Cannot start another.");
            }

            try {
                _isEncoding = true;
                base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(input));

                foreach (char c in base64)
                {
                    lock (_lock)
                    {
                        if (!_isEncoding)
                        {
                            break;
                        }
                    }

                    await Task.Delay(TimeSpan.FromSeconds(new Random().Next(1, 6)));

                    // Send character to the client using SignalR hub
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", c.ToString());
                }
            } catch (Exception ex) {

                _logger.LogError($"Error while encoding: {ex.Message}");
            }
            

            _isEncoding = false;
            return base64;
        }

        public void CancelEncoding()
        {
            lock (_lock)
            {
                _isEncoding = false;
            }
        }
    }
}
