using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.DbEntities;

[Table("Persons")]
public class DbPerson : DbEntity
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Firstname { get; set; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Lastname { get; set; }
    [MaxLength(Constants.StringLengths.Medium)]
    public required string Email { get; set; }

    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbPerson person) return;
      if (this.Firstname != person.Firstname)
      {
        this.Firstname = person.Firstname;
      }

      if (this.Lastname != person.Lastname)
      {
        this.Lastname = person.Lastname;
      }

      if (this.Email != person.Email)
      {
        this.Email = person.Email;
      }
      base.UpdateToTarget(target);
    }
}
public sealed class DbUser : DbPerson
{
    [MaxLength(Constants.StringLengths.Medium)]
    public required string PasswordHash { get; set; }
    
    public required bool Active { get; set; }
    
    public required bool EmailConfirmed { get; set; }
    
    public override void UpdateToTarget(DbEntityWithId target)
    {
      if(target is not DbUser user) return;
      if (this.PasswordHash != user.PasswordHash)
      {
        this.PasswordHash = user.PasswordHash;
      }

      if (this.Active != user.Active)
      {
        this.Active = user.Active;
      }
      
      if (this.EmailConfirmed != user.EmailConfirmed)
      {
        this.EmailConfirmed = user.EmailConfirmed;
      }
      base.UpdateToTarget(target);
    }
}
