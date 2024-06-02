using ApplicationCore.DTO_s.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.AccountDTO
{
    public class EditUserDTO:AppUserDTO
    {
        public string? Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "Username")]
        public string? UserName { get; set; }
        public string? Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }


    }
}
