namespace BlazorWebApp.Models.Courses;

public class CourseResult
{
    public bool Succeeded { get; set; }
    public bool Exists { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public IEnumerable<CoursesModel>? Courses { get; set; }     //eventuellt? Se Tims lösning  = [];
}
