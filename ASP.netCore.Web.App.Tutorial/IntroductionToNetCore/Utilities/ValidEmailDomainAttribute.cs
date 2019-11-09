using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IntroductionToNetCore.Utilities
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        public ValidEmailDomainAttribute(string allowedDomain)
        {
            AllowedDomain = allowedDomain;
        }

        public string AllowedDomain { get; }

        public override bool IsValid(object value)
        {
            string[] a = value.ToString().Split('@');
            return AllowedDomain.ToUpper() == a[1].ToUpper();
        }
    }
}
