# NullableTest

Strange behavior when I try to enumerate type info's from an assembly and check if the type is nullable. Every other type then String returns correctly but String always returns non-nullable no matter how I mark it.

I encountered this issue when I was trying to convert my Entity Framework generated models (database first) to protocol buffers with a self made code-gen tool. I wanted to use google.protobuf.StringValue wrapper instead of just string but couldn't find a way to read the string? type properly. It always returns System.String.

[How to identify a nullable value type
](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types#how-to-identify-a-nullable-value-type)


## Class definition:
```
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTest.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }

        [AllowNull]
        public string? AllowNullString { get; set; }

        [MaybeNull]
        public string? MaybeNullString { get; set; }

        [DisallowNull]
        public string? DisallowNullString { get; set; }

        public string Comments { get; set; } = "Test comments";

        public int? Age { get; set; }
        public double? LocationX { get; set; }
        public float? LocationY { get; set; }
        public long? ChildrenCount { get; set; }
        public decimal? MoneyInTheBank { get; set; }
        public ulong? SiblingsCount { get; set; }
        
    }
}
```

## Main program:
```
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
```

## Output:
```
1. System.Int32, Nullable: False
2. System.String, Nullable: False
3. System.String, Nullable: False
4. System.String, Nullable: False
5. System.String, Nullable: False
6. System.String, Nullable: False
7. System.String, Nullable: False
8. System.String, Nullable: False
9. System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], Nullable: True
10. System.Nullable`1[[System.Double, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], Nullable: True
11. System.Nullable`1[[System.Single, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], Nullable: True
12. System.Nullable`1[[System.Int64, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], Nullable: True
13. System.Nullable`1[[System.Decimal, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], Nullable: True
14. System.Nullable`1[[System.UInt64, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]], Nullable: True
```
