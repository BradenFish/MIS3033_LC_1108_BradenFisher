using System.ComponentModel.DataAnnotations;

namespace MIS3033_LC_1108_BradenFisher.Models
{
    public class Student
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }

    }
}
