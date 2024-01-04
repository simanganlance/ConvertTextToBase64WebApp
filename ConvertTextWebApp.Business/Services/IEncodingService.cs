using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertTextWebApp.Business.Services
{
    public interface IEncodingService
    {
        Task<string> Encode(string input);
        void CancelEncoding();
    }
}
