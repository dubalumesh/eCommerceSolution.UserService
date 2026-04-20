

namespace eCommerce.Core.DTOs
{
    public record AuthenticationResponse
   (Guid UserId, string? Email, string? PersonName, string? Gender, string? Token, bool Sucess)
    {
        public AuthenticationResponse() : this(default, default, default, default, default, default)
        { }
    }
}
