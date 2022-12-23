using System.ComponentModel.DataAnnotations;

namespace NumeSugestiv.Features.Tests.Views;

public class TestRequest
{
    [Required]public string Subject { get; set; }
    
    [Required]public DateTime TestDate { get; set; }
}