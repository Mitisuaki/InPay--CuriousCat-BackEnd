using Microsoft.AspNetCore.Mvc;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;
using InPay__CuriousCat_BackEnd.Domain.Services;
using InPay__CuriousCat_BackEnd.Exceptions;
using InPay__CuriousCat_BackEnd.Domain.MiddleWares;
using Microsoft.AspNetCore.Authorization;
using InPay__CuriousCat_BackEnd.Domain.Models;
using Microsoft.AspNetCore.Cors;

namespace InPay__CuriousCat_BackEnd.Controllers;


[ApiController]
[EnableCors]
[Route("users", Name = "User Routes")]
public class UserController : ControllerBase
{
    private readonly UserServices _userService;
    private readonly TokensVerifications _tokensVerifications;

    public UserController(UserServices userService, TokensVerifications tokensVerifications)
    {
        _userService = userService;
        _tokensVerifications = tokensVerifications;
    }

    [HttpPost("/register", Name = "Creater New User")]
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

    [HttpGet("/user/{Id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserCreateResponseDTO))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUserInfoById(string Id)
    {
        try
        {
            Request.Headers.TryGetValue("authorization", out var authorization);
            var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

            if (tokenClaims.Id != Id && !tokenClaims.IsAdmin)
                throw new UnauthorizedAccessException("You're not authorized to acess this content");


            if (tokenClaims.IsAdmin)
            {
                var userFoundByAdmin = await _userService.GetUserInfoById(Id);
                return Ok(userFoundByAdmin);
            }

            var userFound = await _userService.GetUserBasicInfoById(Id);

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
    [HttpGet]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserCreateResponseDTO>))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult ListAllUsers()
    {
        try
        {
            Request.Headers.TryGetValue("authorization", out var authorization);
            var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

            if (!tokenClaims.IsAdmin)
                throw new UnauthorizedAccessException("You're not authorized to acess this content");


            var users = _userService.ListAllUsers();

            return Ok(users);

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

    [HttpPut("/user/{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserCreateResponseDTO>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUser(string id, UserUpdateDTO userUpdateDTO)
    {
        try
        {
            Request.Headers.TryGetValue("authorization", out var authorization);
            var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

            if (tokenClaims.Id != id && !tokenClaims.IsAdmin)
                throw new UnauthorizedAccessException("You're not authorized to acess this content");


            var userUpdated = await _userService.UpdateUser(id, userUpdateDTO);

            return Ok(userUpdated);

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

    [HttpPatch("/user/{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PatchUser(string id, UserPatchDTO userPatchDTO)
    {
        try
        {
            Request.Headers.TryGetValue("authorization", out var authorization);
            var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

            if (tokenClaims.Id != id && !tokenClaims.IsAdmin)
                throw new UnauthorizedAccessException("You're not authorized to acess this content");


            var userUpdated = await _userService.PatchUser(id, userPatchDTO);

            return Ok(userUpdated);

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
    [HttpPut("/user/{id}/changePassword")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateUserPW(string id, UserUpdatePWDTO userUpdatePWDTO)
    {
        try
        {
            Request.Headers.TryGetValue("authorization", out var authorization);
            var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

            if (tokenClaims.Id != id && !tokenClaims.IsAdmin)
                throw new UnauthorizedAccessException("You're not authorized to acess this content");


            await _userService.UpdatePassword(id, userUpdatePWDTO);

            return Ok();

        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            return Unauthorized(e.Message);
        }

        catch (BadHttpRequestException e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPut("/user/{id}/forgotPassword")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ForgotPassWord(string id, UserForgotPWDTO userForgotPWDTO)
    {
        try
        {
            Request.Headers.TryGetValue("authorization", out var authorization);
            var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

            if (tokenClaims.Id != id && !tokenClaims.IsAdmin)
                throw new UnauthorizedAccessException("You're not authorized to acess this content");


            await _userService.ForgotPassWord(id, userForgotPWDTO);

            return Ok();

        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            return Unauthorized(e.Message);
        }
        catch (BadHttpRequestException e)
        {
            return BadRequest(e.Message);
        }
        catch (ServerProblemException e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpDelete("/user/{id}/deleteUser")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeactivateUser(string id)
    {
        try
        {
            Request.Headers.TryGetValue("authorization", out var authorization);
            var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

            if (tokenClaims.Id != id && !tokenClaims.IsAdmin)
                throw new UnauthorizedAccessException("You're not authorized to acess this content");


            await _userService.DeactivateUser(id);

            return Ok();

        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            return Unauthorized(e.Message);
        }
        catch (BadHttpRequestException e)
        {
            return BadRequest(e.Message);
        }
        catch (ServerProblemException e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpPut("/user/{id}/undeleteUser")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> ReactivateUser(string id)
    {
        try
        {
            Request.Headers.TryGetValue("authorization", out var authorization);
            var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

            if (!tokenClaims.IsAdmin)
                throw new UnauthorizedAccessException("You're not authorized to acess this content");


            await _userService.ReactivateUser(id);

            return Ok();

        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            return Unauthorized(e.Message);
        }
        catch (BadHttpRequestException e)
        {
            return BadRequest(e.Message);
        }
        catch (ServerProblemException e)
        {
            return StatusCode(500, e.Message);
        }

    }
}


