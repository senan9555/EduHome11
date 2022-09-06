using System.ComponentModel.DataAnnotations;

namespace EduHome.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="bos ola bilmez")]
        public string Title { get; set; }
        [Required(ErrorMessage = "bos ola bilmez")]
        public string SubTitle { get; set; }

        public bool IsDeactive { get; set; }
    }
}
