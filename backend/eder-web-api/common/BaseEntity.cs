namespace eder_web_api.common
{
    public class BaseEntity
{
    public Guid Id {get;private set;}

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public DateTime UpdatedAt {get;private set;}

    public DateTime DeletedAt {get;private set;}

}
}
