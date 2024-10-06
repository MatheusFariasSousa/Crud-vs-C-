using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User_Model;

[Table("User")]
public class User
{
    [Column("Id")]
    [Key]
    public int Id { get; set; }

    [Column("Name")]
    public string Name { get; set; }

    [Column("Password")]
    public string Password { get; set; }

}