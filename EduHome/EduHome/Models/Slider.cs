﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
    public class Slider
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
