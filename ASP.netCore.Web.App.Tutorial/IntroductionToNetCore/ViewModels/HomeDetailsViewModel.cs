using IntroductionToNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroductionToNetCore.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Employee employee { get; set; }
        public string PageTitle { get; set; }
    }
}
