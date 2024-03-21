using Microsoft.AspNetCore.Mvc;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;
using InPay__CuriousCat_BackEnd.Domain.Services;



namespace InPay__CuriousCat_BackEnd.Controllers;


[ApiController]
[Route("users")]
public class UserController() : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(UserCreateDTO user)
    {
        // var userMapped = UserServices.CreateUser(user);

        return Created();
    }
}


