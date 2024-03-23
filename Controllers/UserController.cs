using Microsoft.AspNetCore.Mvc;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;
using InPay__CuriousCat_BackEnd.Domain.Services;
using InPay__CuriousCat_BackEnd.Exceptions;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using InPay__CuriousCat_BackEnd.Domain.MiddleWares;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Security.Claims;



namespace InPay__CuriousCat_BackEnd.Controllers;


[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly UserServices _userService;
    private readonly TokensVerifications _tokensVerifications;

    public UserController(UserServices userService, TokensVerifications tokensVerifications)
    {
        _userService = userService;
        _tokensVerifications = tokensVerifications;
    }

    [HttpGet("/user/{Id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserCreateResponseDTO))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserInfoById(string Id, [FromHeader] string authorization)
    {
        try
        {
            var tokenClaims = _tokensVerifications.UserTokenVerification(authorization);

            if (tokenClaims.Id != Id && !tokenClaims.IsAdmin)
                throw new UnauthorizedAccessException("You're not authorized to acess this content");


            var userFound = await _userService.GetUserInfoById(Id);

            return Ok(userFound);

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

    [HttpPost("/register")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserCreateResponseDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateUser(UserCreateDTO userDto)
    {
        try
        {
            var userCreated = await _userService.CreateUser(userDto);


            return CreatedAtAction(nameof(GetUserInfoById), new { userCreated.Id }, userCreated);
        }
        catch (AlreadyExistsException e)
        {

            return BadRequest(e.Message);
        }
        catch (ServerProblemException e)
        {
            return StatusCode(500, e.Message);
        }
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


