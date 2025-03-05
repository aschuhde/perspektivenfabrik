using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbMailAddress
{
    public required string Mail { get; set; }

    public void Update(DbMailAddress targetEntity)
    {
      if (this.Mail != targetEntity.Mail)
      {
        this.Mail = targetEntity.Mail;
      }
    }
}
