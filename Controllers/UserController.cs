using Microsoft.AspNetCore.Mvc;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;




namespace InPay__CuriousCat_BackEnd.Controllers;


[ApiController]
[Route("users")]
public class UserController() : ControllerBase
{
    [HttpPost("signin")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void CreateUser(UserCreateDTO user)
    {
        // var userToSave = _mapper.Map<User>(user);
        // var result = _InpayDbContext.Users.Add(userToSave);
        // _InpayDbContext.SaveChanges();
        // var userSaved = result.Entity;


        // return CreatedAtAction(nameof(CreateUser), new { userSaved.Id }, userSaved);
    }
}


