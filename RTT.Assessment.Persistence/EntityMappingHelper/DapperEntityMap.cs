using RTT.Assessment.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;

namespace RTT.Assessment.Persistence.EntityMappingHelper
{
    public class DapperEntityMap<T> where T : BaseEntity
    {
        public static readonly string SelectAll;
        public static readonly string SelectById;
        public static readonly string Insert;
        public static readonly string Update;
        public static readonly string Delete;

        static DapperEntityMap()
        {
            var type = typeof(T);
            var table = type.GetCustomAttribute<TableAttribute>()?.Name ?? type.Name + "s";

            var cols = type.GetProperties()
                .Where(p => p.CanRead && p.CanWrite
                            && p.Name != nameof(BaseEntity.Id)
                            && p.GetCustomAttribute<NotMappedAttribute>() == null
                            && IsSimple(p.PropertyType))
                .Select(p => p.Name)
                .ToArray();

            var colList = string.Join(", ", cols.Select(c => $"[{c}]"));
            var paramList = string.Join(", ", cols.Select(c => $"@{c}"));
            var setList = string.Join(", ", cols.Select(c => $"[{c}] = @{c}"));

            SelectAll = $"SELECT [Id], {colList} FROM [{table}]";
            SelectById = $"{SelectAll} WHERE [Id] = @id";
            Insert = $"INSERT INTO [{table}] ({colList}) OUTPUT INSERTED.[Id] VALUES ({paramList})";
            Update = $"UPDATE [{table}] SET {setList} WHERE [Id] = @Id";
            Delete = $"DELETE FROM [{table}] WHERE [Id] = @Id";
        }

        private static bool IsSimple(Type t)
        {
            t = Nullable.GetUnderlyingType(t) ?? t;
            return t.IsPrimitive || t.IsEnum
                || t == typeof(string) || t == typeof(decimal) || t == typeof(Guid)
                || t == typeof(DateTime) || t == typeof(DateTimeOffset)
                || t == typeof(DateOnly) || t == typeof(byte[]);
        }
    }
}
