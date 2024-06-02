using BlazorWebApp.Components.Pages.Admin.Courses;
using BlazorWebApp.Models.AdminPortal.Courses;
using BlazorWebApp.Models.Courses;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace BlazorWebApp.Services;

public class GraphQLService(HttpClient httpClient)
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<(CreateCourseResponse? courseResponse, string? errorMessage)> AddCourseAsync(CreateCourseModel course)
    {
        var mutation = @"
        mutation($input: CourseCreateRequestInput!) { 
            createCourse(input: $input) { 
                id 
                title 
            }
        }";

        var variables = new 
        {
            input = new
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

        var request = new 
        { 
            query = mutation, 
            variables 
        };

        try
        {
            var response = await _httpClient.PostAsJsonAsync("https://coursesprovider.azurewebsites.net/api/graphql?code=F3ve4AdrXYNCGI-2JWQFXh1E_D_dWo4yAmdz3qhVhM9JAzFucoYaqg%3D%3D", request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<GraphQLResponse>();

            if(result?.Data?.CreateCourse == null)
            {
                return (null, "GraphQl mutation returnded null data.");

            }
            return (result.Data.CreateCourse, null);
        }
        catch(HttpRequestException httpEx)
        {
            return (null, $"HTTP Request failed: {httpEx.Message}");
        }
        catch (Exception ex)
        {
            return (null, $"HTTP Request failed: {ex.Message}");
        }

    }


    public async Task<(UpdateCourseResponse? courseResponse, string? errorMessage)> UpdateCourseAsync(CoursesModel course)
    {
        var mutation = @"
        mutation($input: CourseUpdateRequestInput!) { 
            updateCourse(input: $input) { 
                id 
                title 
            }
        }";

        var variables = new
        {
            input = new
            {
                id = course.Id,
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
        var request = new
        {
            query = mutation,
            variables
        };

        try
        {
            var response = await _httpClient.PostAsJsonAsync("https://coursesprovider.azurewebsites.net/api/graphql?code=F3ve4AdrXYNCGI-2JWQFXh1E_D_dWo4yAmdz3qhVhM9JAzFucoYaqg%3D%3D", request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<GraphQLResponse>();

            if (result?.Data?.UpdateCourse == null)
            {
                return (null, "GraphQl mutation returnded null data.");

            }
            return (result.Data.UpdateCourse, null);
        }
        catch (HttpRequestException httpEx)
        {
            return (null, $"HTTP Request failed: {httpEx.Message}");
        }
        catch (Exception ex)
        {
            return (null, $"HTTP Request failed: {ex.Message}");
        }
    }


    public async Task<bool> DeleteCourseAsync(CoursesModel course)   //skiten fungerar inte!!
    {
        var mutation = @"
            mutation($input: CourseDeleteRequestInput!) {
            deleteCourse(input: $input) 
        }";
               

        var variables = new
        {
            input = new { id = course.Id }
        };

        var request = new
        {
            query = mutation,
            variables
        };

        try
        {
            var response = await _httpClient.PostAsJsonAsync("https://coursesprovider.azurewebsites.net/api/graphql?code=Ms8IxsC9w8G_dT8KJZbuf11TR3o7reeP9ld8DSPtnesZAzFuaTdsNw%3D%3D", request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<GraphQLResponse>();

            return result?.Data?.DeleteCourse ?? false;
        }
        catch (HttpRequestException)
        {
            return false;
        }
    
    }
}


public class GraphQLResponse
{
    public GraphQLData? Data { get; set; }
}
public class GraphQLData
{
    public CreateCourseResponse? CreateCourse { get; set; }
    public UpdateCourseResponse? UpdateCourse { get; set; }
    public bool DeleteCourse { get; set; }
}
public class CreateCourseResponse
{
    public string? Id { get; set; }
    public string? Title { get; set; }
}

public class UpdateCourseResponse
{
    public string? Id { get; set; }
    public string? Title { get; set; }
}