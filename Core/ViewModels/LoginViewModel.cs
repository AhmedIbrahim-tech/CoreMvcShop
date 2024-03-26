namespace Core.ViewModels;

public class LoginViewModel
{
    [Required]
    public string UserName {  get; set; }
    [Required(ErrorMessage ="Password Must Contain at Least 8 characters")]
    [MinLength(8)]
    
    public string Password { get; set; }
    public bool RememberMe {  get; set; }
}
