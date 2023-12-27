using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DTOs.AccountTypes
{
    public class GetAccounts
    {
        [Key]
        public string Email { get; set; }

        public string Password { get; set; }
        public string AccessToken { get; set; }

        public int AccoutRole { get; set; }
    }
}
