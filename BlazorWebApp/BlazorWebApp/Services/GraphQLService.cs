using BlazorWebApp.Components.Pages.Admin.Courses;
using BlazorWebApp.Models.AdminPortal.Courses;
using BlazorWebApp.Models.Courses;

namespace BlazorWebApp.Services;

public class GraphQLService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<CreateCourseResponse> AddCourseAsync(CreateCourseModel course)
    {
        var mutation = @"
        mutation($course: CourseInput!) {
            createCourse(course: $course){
                id
                success
                message
            }
        }";

        var variables = new { course = new
        {
            isBestSeller = course.IsBestSeller,
            courseImage = course.CourseImage,
            courseImageAltText = course.CourseImageAltText,
            title = course.Title,
            price = course.Price,
            discountPrice = course.DiscountPrice,
            rating = course.Rating,
            reviews = course.Reviews,
            views = course.Views,
            likesInPercent = course.LikesInPercent,
            likesInNumbers = course.LikesInNumbers,
            authorName = course.AuthorName,
            autherBio = course.AutherBio,
            authorImage = course.AuthorImage,
            autherImageAltText = course.AutherImageAltText,
            youTubeSubscribers = course.YouTubeSubscribers,
            faceBookFollowers = course.FaceBookFollowers,
            showcaseImage = course.ShowcaseImage,
            courseDescription = course.CourseDescription,
            viewHours = course.ViewHours,
            articles = course.Articles,
            resources = course.Resources,
            accessTime = course.AccessTime,
            programDetailsTitle = course.ProgramDetailsTitle,
            programDetailsText = course.ProgramDetailsText,
            learnPoints = course.LearnPoints,
            category = course.Category == null ? null : new
            {
                categoryName = course.Category
            }
        }
        };

        var request = new { query = mutation, variables };

        var response = await _httpClient.PostAsJsonAsync("https://coursesprovider.azurewebsites.net/api/graphql?code=F3ve4AdrXYNCGI-2JWQFXh1E_D_dWo4yAmdz3qhVhM9JAzFucoYaqg%3D%3D", request);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<GraphQLResponse>();

        return result.Data.CreateCourse;

    }
}
public class GraphQLResponse
{
    public GraphQLData? Data { get; set; }
}
public class GraphQLData
{
    public CreateCourseResponse CreateCourse { get; set; }
}
public class CreateCourseResponse
{
    public string? Id { get; set; }
    public bool Success { get; set; }
    public string? Message { get; set; }
}
