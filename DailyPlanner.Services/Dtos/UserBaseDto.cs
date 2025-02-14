﻿using System.ComponentModel.DataAnnotations;

namespace DailyPlanner.Services.Dtos
{
    public abstract class UserBaseDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
