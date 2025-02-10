using System.ComponentModel.DataAnnotations;

namespace PlacementTracker.Web.Models.User;
public class ForgotPasswordViewModel
{
    [Required]
    public string Email { get; set; }
    
}
