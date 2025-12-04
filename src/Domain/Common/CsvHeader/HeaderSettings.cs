using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.CsvHeader
{
    public class HeaderSettings
    {
        public Dictionary<string, string[]> Headers { get; set; } = new();
    }
}
