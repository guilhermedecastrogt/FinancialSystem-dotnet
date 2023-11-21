using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Entities._4___Entities.Entities.Entities;

public class ApplicationUser : IdentityUser
{
    [Column("USR_CPF")] public string CPF { get; set; }
}