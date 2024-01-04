using ConvertTextWebApp.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ConvertTextWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncodeController : ControllerBase
    {
        private readonly IEncodingService _encodingService;

        public EncodeController(IEncodingService encodingService)
        {
            _encodingService = encodingService;
        }

        [HttpGet("start/{input}")]
        public async Task<IActionResult> StartEncoding(string input)
        {
            try
            {
                string encodedText = await _encodingService.Encode(input);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("cancel")]
        public IActionResult CancelEncoding()
        {
            _encodingService.CancelEncoding();
            return Ok();
        }
    }
}