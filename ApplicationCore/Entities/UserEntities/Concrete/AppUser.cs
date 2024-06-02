using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.UserEntities.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.UserEntities.Concrete
{
    public class AppUser : IdentityUser, IBaseUser
    {
        private Status _status = Status.Active;
        private DateTime _createdDate = DateTime.Now;

        [Required(ErrorMessage ="First name is required")]
        [MaxLength(100,ErrorMessage = "Maximum length is 100 characters")]
        [MinLength(2, ErrorMessage = "Minimum length is 2 characters")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(100,ErrorMessage="Maximum length is 100 characters")]
        [MinLength(2, ErrorMessage = "Minimum length is 2 characters")]
        public string? LastName { get; set; }

        [MaxLength(250, ErrorMessage = "Maximum length is 250 characters")]
        [MinLength(5, ErrorMessage = "Minimum length is 5 characters")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Birthdate is required")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDate { get => _createdDate; set => _createdDate = value; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Status Status { get => _status; set => _status = value; }

    }
}
