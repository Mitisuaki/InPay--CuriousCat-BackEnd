using System.IdentityModel.Tokens.Jwt;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;


namespace InPay__CuriousCat_BackEnd.Domain.MiddleWares;

public class TokensVerifications(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public UserTokenVerificationResponseDTO UserTokenVerification(string userToken)
    {
        string token = userToken.Split(" ")[1];
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
        var userName = jwtSecurityToken.Claims.First(claim => claim.Type == "Username").Value;
        var id = jwtSecurityToken.Claims.First(claim => claim.Type == "Id").Value;
        var isAdmin = jwtSecurityToken.Claims.First(claim => claim.Type == "IsAdmin").Value;

        UserTokenVerificationResponseDTO response = new(userName, id, isAdmin);

        return response;

    }
    public void AccTokenVerification()
    {
        // verify if the Token is valid

    }
    public void AccAPITokenVerification()
    {
        // verify if the Token is valid

    }
}