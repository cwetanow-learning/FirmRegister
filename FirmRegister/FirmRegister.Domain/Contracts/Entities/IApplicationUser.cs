using FirmRegister.Domain.Utils.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmRegister.Domain.Contracts.Entities
{
    public interface IApplicationUser
    {
        string FirstName { get; set; }
        
        string LastName { get; set; }
        
        int Age { get; set; }

        GenderType Gender { get; set; }
    }
}
