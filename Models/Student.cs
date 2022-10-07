using System.ComponentModel.DataAnnotations;

namespace StudentData.Models;

public class Student
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string StudentName { get; set; }
    public string City { get; set; }
     

}
