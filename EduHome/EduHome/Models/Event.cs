using System;

namespace EduHome.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
