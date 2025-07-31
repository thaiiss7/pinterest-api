using System.ComponentModel.DataAnnotations;
using Pinterest.Validations;

namespace Pinterest.UseCases.CreateProfile;

public record CreateProfilePayload
{
    // informações passadas na hora que cria uma conta

    [Required]
    [MinLength(5)]
    [MaxLength(20)]
    public string Username { get; init; }

    [Required]
    [EmailAddress]
    public string Email { get; init; }

    [Required]
    [MinLength(5)]
    [NeedNumber]
    public string Password { get; init; }

    [Required]
    [Compare("Password")]
    public string RepeatPassword { get; init; }

    [MaxLength(200)]
    public string ?Bio { get; init; }
}
