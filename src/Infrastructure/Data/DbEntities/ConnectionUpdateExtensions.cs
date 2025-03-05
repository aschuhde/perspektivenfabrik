namespace Infrastructure.Data.DbEntities;

public static class ConnectionUpdateExtensions
{
  public static List<TConnection>? GetUpdateConnections<TConnection>(this List<TConnection>? connections, List<TConnection>? targetConnections, Func<TConnection, Guid> onGetLeftGuid, Func<TConnection, Guid> onGetRightGuid) where TConnection : DbEntityWithId
  {
    if (connections == null)
    {
      return null;
    }

    if (targetConnections == null)
    {
      return [];
    }
    
    foreach (var targetConnection in targetConnections)
    {
      var existingEntity = connections.FirstOrDefault(x => onGetLeftGuid(x) == onGetLeftGuid(targetConnection) && onGetRightGuid(x) == onGetRightGuid(targetConnection));
      if (existingEntity == null)
      {
        connections.Add(targetConnection);
      }
      else
      {
        // targetConnection.EntityId = existingEntity.EntityId;
      }
    }
    foreach (var connection in connections.ToList())
    {
      if (targetConnections.All(x => onGetLeftGuid(x) != onGetLeftGuid(connection) || onGetRightGuid(x) != onGetRightGuid(connection)))
      {
        connections.Remove(connection);
      }
    }
    return connections;
  }
}
