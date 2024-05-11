﻿using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.Models.Home;

public class SubscribeModel
{
    [Display(Name = "Email", Prompt = "Enter your email.", Order = 0)]
    [Required(ErrorMessage = "Email is required.")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = null!;
    public bool IsSubscribed { get; set; }
    public bool DailyNewsLetter { get; set; } 
    public bool AdvertisingUpdates { get; set; }
    public bool WeekInReviews { get; set; }
    public bool EventUpdates { get; set; } 
    public bool StartupsWeekly { get; set; } 
    public bool Podcasts { get; set; }


    
}
