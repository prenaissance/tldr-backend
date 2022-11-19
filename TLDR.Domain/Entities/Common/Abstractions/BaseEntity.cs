namespace TLDR.Domain.Entities.Common.Abstractions;
public abstract class BaseEntity<T>
{
    public T Id { get; set; } = default!;
}
