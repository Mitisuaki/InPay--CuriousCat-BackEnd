using Microsoft.AspNetCore.Mvc;
using InPay__CuriousCat_BackEnd.Domain.Services;
using InPay__CuriousCat_BackEnd.Exceptions;
using InPay__CuriousCat_BackEnd.Domain.MiddleWares;
using InPay__CuriousCat_BackEnd.Domain.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using InPay__CuriousCat_BackEnd.Domain.DTOs.Accounts;
using System.Text.Json.Nodes;

namespace InPay__CuriousCat_BackEnd.Controllers;


[ApiController]
[Route("user/{id}/acc", Name = "Accounts Routes")]
public class AccController : ControllerBase
{
    private readonly AccountServices _accService;
    private readonly TokensVerifications _tokensVerifications;

    public AccController(AccountServices accService, TokensVerifications tokensVerifications)
    {
        _accService = accService;
        _tokensVerifications = tokensVerifications;
    }

    [HttpPost("createPFAcc")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AccPFCreateResponseDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePFAcc([FromBody] AccPFCreateDTO accPFCreateDTO, string id)
    {
        try
        {
            Request.Headers.TryGetValue("authorization", out var authorization);
            var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

            if (tokenClaims.Id != id && !tokenClaims.IsAdmin)
                throw new UnauthorizedAccessException("You're not authorized to acess this content");

            var accCreated = await _accService.CreateAcc(accPFCreateDTO, id);

            // return CreatedAtAction(nameof(GetAccInfoById), new { accCreated.Id }, accCreated);
            return Ok(accCreated);
        }
        catch (AlreadyExistsException e)
        {
            return BadRequest(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            return Unauthorized(e.Message);
        }
    }

    [HttpPost("createPJAcc")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AccPJCreateResponseDTO))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreatePJAcc([FromBody] AccPJCreateDTO accPJCreateDTO, string id)
    {
        try
        {
            Request.Headers.TryGetValue("authorization", out var authorization);
            var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

            if (tokenClaims.Id != id && !tokenClaims.IsAdmin)
                throw new UnauthorizedAccessException("You're not authorized to acess this content");

            var accCreated = await _accService.CreateAcc(accPJCreateDTO, id);

            // return CreatedAtAction(nameof(GetAccInfoById), new { accCreated.Id }, accCreated);
            return Ok(accCreated);
        }
        catch (AlreadyExistsException e)
        {
            return BadRequest(e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            return Unauthorized(e.Message);
        }
    }

    [HttpPost("login")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult LoginAcc(AccLoginDTO accDto, string id)
    {
        try
        {
            Request.Headers.TryGetValue("authorization", out var authorization);
            var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

            if (tokenClaims.Id != id && !tokenClaims.IsAdmin)
                throw new UnauthorizedAccessException("You're not authorized to acess this content");
            string accToken = _accService.Login(accDto, id, tokenClaims);
            JsonObject json = [];
            json.Add("AccToken", accToken);

            return Ok(json);
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

    [HttpGet("{accNumber}/balance")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public IActionResult GetAccInfoById(string id, string accNumber)
    {
        try
        {
            Request.Headers.TryGetValue("authorization", out var authorization);
            var tokenClaims = _tokensVerifications.AccTokenVerification(authorization!);

            if (tokenClaims.UserId != id || tokenClaims.AccNumber != accNumber)
                throw new UnauthorizedAccessException($"You're not authorized to acess this content");


            var userBalance = _accService.GetBalance(tokenClaims);
            JsonObject json = [];
            json.Add("Balance", userBalance);

            return Ok(json);


        }
        catch (UnauthorizedAccessException e)
        {
            return Unauthorized(e.Message);
        }
    }
    // [HttpGet]
    // [Authorize(AuthenticationSchemes = "Bearer")]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserCreateResponseDTO>))]
    // [ProducesResponseType(StatusCodes.Status204NoContent)]
    // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    // public IActionResult ListAllAccs()
    // {
    //     try
    //     {
    //         Request.Headers.TryGetValue("authorization", out var authorization);
    //         var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

    //         if (!tokenClaims.IsAdmin)
    //             throw new UnauthorizedAccessException("You're not authorized to acess this content");


    //         var users = _userService.ListAllUsers();

    //         return Ok(users);

    //     }
    //     catch (NotFoundException e)
    //     {
    //         return NotFound(e.Message);
    //     }
    //     catch (UnauthorizedAccessException e)
    //     {
    //         return Unauthorized(e.Message);
    //     }
    // }

    // [HttpPut("/user/acc/{id}")]
    // [Authorize(AuthenticationSchemes = "Bearer")]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserCreateResponseDTO>))]
    // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // public async Task<IActionResult> UpdateAcc(string id, UserUpdateDTO userUpdateDTO)
    // {
    //     try
    //     {
    //         Request.Headers.TryGetValue("authorization", out var authorization);
    //         var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

    //         if (tokenClaims.Id != id && !tokenClaims.IsAdmin)
    //             throw new UnauthorizedAccessException("You're not authorized to acess this content");


    //         var userUpdated = await _userService.UpdateUser(id, userUpdateDTO);

    //         return Ok(userUpdated);

    //     }
    //     catch (NotFoundException e)
    //     {
    //         return NotFound(e.Message);
    //     }
    //     catch (UnauthorizedAccessException e)
    //     {
    //         return Unauthorized(e.Message);
    //     }
    // }

    // [HttpPatch("/user/acc/{id}")]
    // [Authorize(AuthenticationSchemes = "Bearer")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // public async Task<IActionResult> PatchAcc(string id, UserPatchDTO userPatchDTO)
    // {
    //     try
    //     {
    //         Request.Headers.TryGetValue("authorization", out var authorization);
    //         var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

    //         if (tokenClaims.Id != id && !tokenClaims.IsAdmin)
    //             throw new UnauthorizedAccessException("You're not authorized to acess this content");


    //         var userUpdated = await _userService.PatchUser(id, userPatchDTO);

    //         return Ok(userUpdated);

    //     }
    //     catch (NotFoundException e)
    //     {
    //         return NotFound(e.Message);
    //     }
    //     catch (UnauthorizedAccessException e)
    //     {
    //         return Unauthorized(e.Message);
    //     }
    // }
    // [HttpPut("/user/acc/{id}/changePJPassword")]
    // [Authorize(AuthenticationSchemes = "Bearer")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // public async Task<IActionResult> UpdateAccPJPW(string id, UserUpdatePWDTO userUpdatePWDTO)
    // {
    //     try
    //     {
    //         Request.Headers.TryGetValue("authorization", out var authorization);
    //         var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

    //         if (tokenClaims.Id != id && !tokenClaims.IsAdmin)
    //             throw new UnauthorizedAccessException("You're not authorized to acess this content");


    //         await _userService.UpdatePassword(id, userUpdatePWDTO);

    //         return Ok();

    //     }
    //     catch (NotFoundException e)
    //     {
    //         return NotFound(e.Message);
    //     }
    //     catch (UnauthorizedAccessException e)
    //     {
    //         return Unauthorized(e.Message);
    //     }

    //     catch (BadHttpRequestException e)
    //     {
    //         return BadRequest(e.Message);
    //     }
    // }
    // [HttpPut("/user/acc/{id}/forgotPJPassword")]
    // [Authorize(AuthenticationSchemes = "Bearer")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // public async Task<IActionResult> ForgotAccPJPassWord(string id, UserForgotPWDTO userForgotPWDTO)
    // {
    //     try
    //     {
    //         Request.Headers.TryGetValue("authorization", out var authorization);
    //         var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

    //         if (tokenClaims.Id != id && !tokenClaims.IsAdmin)
    //             throw new UnauthorizedAccessException("You're not authorized to acess this content");


    //         await _userService.ForgotPassWord(id, userForgotPWDTO);

    //         return Ok();

    //     }
    //     catch (NotFoundException e)
    //     {
    //         return NotFound(e.Message);
    //     }
    //     catch (UnauthorizedAccessException e)
    //     {
    //         return Unauthorized(e.Message);
    //     }
    //     catch (BadHttpRequestException e)
    //     {
    //         return BadRequest(e.Message);
    //     }
    //     catch (ServerProblemException e)
    //     {
    //         return StatusCode(500, e.Message);
    //     }
    // }
    // [HttpDelete("/user/acc/{id}/deleteUser")]
    // [Authorize(AuthenticationSchemes = "Bearer")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // public async Task<IActionResult> DeactivateAcc(string id)
    // {
    //     try
    //     {
    //         Request.Headers.TryGetValue("authorization", out var authorization);
    //         var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

    //         if (tokenClaims.Id != id && !tokenClaims.IsAdmin)
    //             throw new UnauthorizedAccessException("You're not authorized to acess this content");


    //         await _userService.DeactivateUser(id);

    //         return Ok();

    //     }
    //     catch (NotFoundException e)
    //     {
    //         return NotFound(e.Message);
    //     }
    //     catch (UnauthorizedAccessException e)
    //     {
    //         return Unauthorized(e.Message);
    //     }
    //     catch (ServerProblemException e)
    //     {
    //         return StatusCode(500, e.Message);
    //     }
    // }
    // [HttpPut("/user/acc{id}/undeleteUser")]
    // [Authorize(AuthenticationSchemes = "Bearer")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // public async Task<IActionResult> ReactivateAcc(string id)
    // {
    //     try
    //     {
    //         Request.Headers.TryGetValue("authorization", out var authorization);
    //         var tokenClaims = _tokensVerifications.UserTokenVerification(authorization!);

    //         if (!tokenClaims.IsAdmin)
    //             throw new UnauthorizedAccessException("You're not authorized to acess this content");


    //         await _userService.ReactivateUser(id);

    //         return Ok();

    //     }
    //     catch (NotFoundException e)
    //     {
    //         return NotFound(e.Message);
    //     }
    //     catch (UnauthorizedAccessException e)
    //     {
    //         return Unauthorized(e.Message);
    //     }
    //     catch (ServerProblemException e)
    //     {
    //         return StatusCode(500, e.Message);
    //     }
    // }
}


