using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.DTOs
{
    public class DailyRevenueDto
    {
        public DateOnly Date { get; set; }
        public string Revenue { get; set; } = string.Empty;
    }
}
