﻿using EduHome.Models;
using Microsoft.EntityFrameworkCore;

namespace EduHome.DAL
{
    public class AppDbContext:  DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
      


        
        
    }
}
