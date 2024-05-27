namespace BlazorWebApp.Data;

public class SavedCourses
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string UserId { get; set; } = null!;
    public string CourseId { get; set; } = null!;
}
