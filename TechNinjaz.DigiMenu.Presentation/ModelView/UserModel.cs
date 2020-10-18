﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TechNinjaz.DigiMenu.Presentation.ModelView
{
    public class UserModel
    {
        public int Id { get; set; }
        [EmailAddress]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required( AllowEmptyStrings = false)]
        public string FistName { get; set; }
        [Required( AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}