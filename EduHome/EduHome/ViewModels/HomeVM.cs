using EduHome.Models;
using System.Collections.Generic;

namespace EduHome.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Course> Courses { get; set; }
        public List<Service> Services { get; set; }
        public List<Notice> Notices { get; set; }
        public List<Event> Events { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public About About { get; set; }

        public Testimonial Testimonial { get; set; }
    }
}
