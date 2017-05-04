using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriGo.Db.Models.Authentication
{
    public class SetPasswordBindingModel
    {
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
