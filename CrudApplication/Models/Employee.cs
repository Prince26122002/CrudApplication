using System.ComponentModel.DataAnnotations;

namespace CrudApplication.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }

        public DateTime DOJ { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public int Salary { get; set; }
    }
}
