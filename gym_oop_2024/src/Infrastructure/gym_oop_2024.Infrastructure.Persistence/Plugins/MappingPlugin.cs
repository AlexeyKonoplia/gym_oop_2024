using Itmo.Dev.Platform.Postgres.Plugins;
using Npgsql;

namespace gym_oop_2024.Infrastructure.Persistence.Plugins;

/// <summary>
///     Plugin for configuring NpgsqlDataSource's mappings
///     ie: enums, composite types
/// </summary>
public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder) { }
}