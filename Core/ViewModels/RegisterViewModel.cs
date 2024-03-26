namespace Core.ViewModels;

public class RegisterViewModel
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string UserName {  get; set; }
    [Required]
    public string EmailAddress {  get; set; }
    [Required]
    public string PhoneNumber {  get; set; }
    [Required]
    public string Password {  get; set; }
    [Required]
    [Compare("Password")]
    public string ConfirmPassword {  get; set; }

    
}
