namespace Clean.Architecture.Core.Entities.Base;

public abstract class EntityBase
{
    public EntityBase()
    {
        Id = Guid.NewGuid();
        CreatedDate = DateTime.UtcNow;
        IsActive = true;
        IsDeleted = false;
    }

    public Guid Id { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }

}
