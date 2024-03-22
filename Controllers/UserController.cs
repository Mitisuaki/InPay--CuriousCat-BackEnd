using Microsoft.AspNetCore.Mvc;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;
using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain.Db;
using Microsoft.AspNetCore.Identity;
using InPay__CuriousCat_BackEnd.Domain.Services;
using InPay__CuriousCat_BackEnd.Exceptions;


namespace InPay__CuriousCat_BackEnd.Controllers;


[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly UserServices _userService;

    public UserController(UserServices userService)
    {
        _userService = userService;
    }

    [HttpGet("/user/{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserCreateResponseDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserInfoById(string Id)
    {
        try
        {
            var userFound = await _userService.GetUserInfoById(Id);

            return Ok(userFound);

        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost("/register")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserCreateResponseDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateUser(UserCreateDTO userDto)
    {
        var userCreated = await _userService.CreateUser(userDto);


        return CreatedAtAction(nameof(GetUserInfoById), new { userCreated.Id }, userCreated);
    }

    [HttpPost("/login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserLoginResponseDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> LoginUser(UserLoginDTO userDto)
    {
        try
        {
            var userLogged = await _userService.LoginUser(userDto);

            return Ok(userLogged);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {

            return Unauthorized(e.Message);
        }
    }
}


