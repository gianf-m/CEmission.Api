using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.LoginAppServices {
    public class LoginRequestDto {
        [Required]
        public string UserName { get; set; }
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$")]
        public string Password { get; set; }
    }
}
