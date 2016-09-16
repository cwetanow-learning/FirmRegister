using FirmRegister.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmRegister.Domain.Concrete
{
    public class CountryRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public IEnumerable<Country> Countries
        {
            get
            {
                return context.Countries;
            }
        }
    }
}
