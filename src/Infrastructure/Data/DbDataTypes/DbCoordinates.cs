using Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbDataTypes;

[Owned]
public sealed class DbCoordinates
{
    public required double Lat { get; set; }
    public required double Lon { get; set; }

    public void Update(DbCoordinates targetEntityCoordinates)
    {
      if (this.Lat.IsNotEqualTo(targetEntityCoordinates.Lat))
      {
        this.Lat = targetEntityCoordinates.Lat;
      }
      if (this.Lon.IsNotEqualTo(targetEntityCoordinates.Lon))
      {
        this.Lon = targetEntityCoordinates.Lon;
      }
    }
}
