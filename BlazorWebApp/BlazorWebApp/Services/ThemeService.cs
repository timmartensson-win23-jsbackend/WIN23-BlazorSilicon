using Microsoft.AspNetCore.Components;

namespace BlazorWebApp.Services;

public class ThemeService
{
    private string selectedTheme = "light-mode";

    public event Action? OnThemeChanged;
    public string GetTheme()
    {
        if (selectedTheme == "light-mode")
        {
            return string.Empty;
        }
        else
        {
            return "dark-mode";
        }
    }

    public void ToggleTheme()
    {
        if (selectedTheme == "light-mode")
        {
            selectedTheme = "dark-mode";
        }
        else
        {
            selectedTheme = "light-mode";
        }
    }
}
