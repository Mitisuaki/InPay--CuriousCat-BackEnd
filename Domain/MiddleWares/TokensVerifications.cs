using System.IdentityModel.Tokens.Jwt;
using InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;


namespace InPay__CuriousCat_BackEnd.Domain.MiddleWares;

public class TokensVerifications()
{
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
    public AccTokenVerificationResponseDTO AccTokenVerification(string userToken)
    {
        string token = userToken.Split(" ")[1];
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
        var userId = jwtSecurityToken.Claims.First(claim => claim.Type == "UserId").Value;
        var accId = jwtSecurityToken.Claims.First(claim => claim.Type == "AccId").Value;
        var accNumber = jwtSecurityToken.Claims.First(claim => claim.Type == "AccNumber").Value;

        AccTokenVerificationResponseDTO response = new(userId, accId, accNumber);

        return response;

    }
    public void AccAPITokenVerification()
    {
        // verify if the Token is valid

    }
}