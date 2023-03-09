namespace ByteTest.Domain.Interfaces;

public interface IEntity
{
    int Id { get; set; }
    DateTime CreationTime { get; set; }
    DateTime? LastModificationTime { get; set; }
}