using FirmRegister.Domain.Utils.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirmRegister.Web.Models
{
    public class SearchViewModel
    {
        public string Name { get; set; }

        [Display(Name ="Lower age")]
        public int StartAge { get; set; }

        [Display(Name = "Higher age")]
        public int EndAge { get; set; }

        public GenderType Gender { get; set; }
    }
}