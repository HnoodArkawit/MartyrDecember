﻿using System.ComponentModel.DataAnnotations;

namespace MartyrDecember.UI.ViewModels
{
    public class RoleFormViewModel
    {
        [Required, StringLength(256)]
        public string Name { get; set; }
    }
}