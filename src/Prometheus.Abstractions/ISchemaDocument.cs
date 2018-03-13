using System.Collections.Generic;

namespace Prometheus.Abstractions
{
    public interface ISchemaDocument
        : IEnumerable<ITypeDefinition>
    {
        IReadOnlyDictionary<string, InterfaceTypeDefinition> InterfaceTypes { get; }

        IReadOnlyDictionary<string, EnumTypeDefinition> EnumTypes { get; }

        IReadOnlyDictionary<string, ObjectTypeDefinition> ObjectTypes { get; }

        IReadOnlyDictionary<string, UnionTypeDefinition> UnionTypes { get; }

        IReadOnlyDictionary<string, InputObjectTypeDefinition> InputObjectTypes { get; }

        ObjectTypeDefinition QueryType { get; }

        ObjectTypeDefinition MutationType { get; }
    }
}