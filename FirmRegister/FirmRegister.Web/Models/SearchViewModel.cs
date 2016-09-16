using FirmRegister.Domain.Utils.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirmRegister.Web.Models
{
    public class SearchViewModel
    {
        public string Name { get; set; }

        public int StartAge { get; set; }

        public int EndAge { get; set; }

        public GenderType Gender { get; set; }
    }
}