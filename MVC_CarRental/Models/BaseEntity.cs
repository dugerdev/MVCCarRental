namespace MVC_CarRental.Models;

/// <summary>
/// Base entity class that provides common properties for all entities
/// Implements soft delete pattern and audit trail functionality
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Unique identifier for the entity
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Indicates whether the entity is soft deleted
    /// </summary>
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Timestamp when the entity was created
    /// </summary>
    public DateTimeOffset CreatedOn { get; set; }

    /// <summary>
    /// Timestamp when the entity was last updated (nullable)
    /// </summary>
    public DateTimeOffset? UpdatedOn { get; set; }

    /// <summary>
    /// Timestamp when the entity was soft deleted (nullable)
    /// </summary>
    public DateTimeOffset? DeletedOn { get; set; }
}
