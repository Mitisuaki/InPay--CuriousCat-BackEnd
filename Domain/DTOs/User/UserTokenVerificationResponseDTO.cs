using System.ComponentModel.DataAnnotations;

namespace InPay__CuriousCat_BackEnd.Domain.DTOs.User;

public class UserTokenVerificationResponseDTO(string userName, string id, string isAdmin)
{

    public string UserName { get; private set; } = userName;

    public string Id { get; private set; } = id;

    public bool IsAdmin { get; private set; } = bool.Parse(isAdmin);
}