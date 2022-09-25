using System.Reflection;
using System.Xml.Linq;

bool IsNullable(Type type) => Nullable.GetUnderlyingType(type) != null;

Assembly sharedAssembly = Assembly.GetExecutingAssembly();
var models = sharedAssembly.DefinedTypes.Where(t => t.Namespace == "NullableTest.Models");

foreach (var model in models)
{
    int n = 1;

    foreach (var property in model.DeclaredProperties)
    {
        var type = property.PropertyType;
        Console.WriteLine($"{n}. {type.FullName}, Nullable: {IsNullable(type)}");
        n++;
    }
}