using Domain.Enums;
using Domain.ValueObjects;
using Kwaffeur.Domain.Common;

namespace Domain.Entities
{
    public class Person : AuditableEntity
    {
        public int Id { get; set; }
        public Name Name { get; set; }
        public GenderType GenderType { get; set; }
    }
}
