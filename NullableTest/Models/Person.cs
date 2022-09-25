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
