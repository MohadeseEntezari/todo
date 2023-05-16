using System.ComponentModel.DataAnnotations;

namespace ToDo.Domain.Entities;

public class User
{
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Firstname { get; set; }

    [Required]
    public string Lastname { get; set; }

    [Required]
    [RegularExpression("^09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}]", ErrorMessage = "Invalid Mobile Number")]
    public string Mobile { get; set; }

    [Required]
    public string Password { get; set; }



}
