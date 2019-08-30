using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verdant.Zero.Erp.Api.Model
{
    public class ValidationResult
    {
        public Boolean ValidationStatus { get; set; }
        public List<String> ValidationMessages { get; set; }

        public ValidationResult()
        {
            ValidationStatus = true;
            ValidationMessages = new List<String>();
        }
    }
}
