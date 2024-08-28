﻿using System.ComponentModel.DataAnnotations;

namespace DailyPlanner.Model
{
    public class UserBase
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
