
namespace Domain.Entities
{
    public class Product: AuditableBaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
