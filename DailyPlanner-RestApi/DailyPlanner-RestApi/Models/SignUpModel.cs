﻿using System.ComponentModel.DataAnnotations;

namespace DailyPlanner_RestApi.Models
{
    public class SignUpModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
