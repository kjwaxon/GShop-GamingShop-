﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTO_s.AccountDTO
{
    public class ChangePasswordDTO
    {

        public string Id { get; set; }

        [Display(Name = "Old Password")]
        public string? OldPassword { get; set; }

        [Display(Name = "New Password")]
        public string? NewPassword { get; set; }

        [Display(Name = "Confirm New Password")]
        public string? ConfirmNewPassword { get; set; }
    }
}