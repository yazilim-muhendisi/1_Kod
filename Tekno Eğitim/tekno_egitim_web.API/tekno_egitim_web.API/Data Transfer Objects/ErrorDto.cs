using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tekno_egitim_web.API.Data_Transfer_Objects
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Error = new List<string>();
        }
        public List<String> Error { get; set; }
        public int Durum { get; set; }
    }
}
