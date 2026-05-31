namespace ECommerce.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; } = DateTime.UtcNow;
    }
}
