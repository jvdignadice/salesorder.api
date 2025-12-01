using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.DomainAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CsvKeyAttribute : Attribute
    {
    }
}
