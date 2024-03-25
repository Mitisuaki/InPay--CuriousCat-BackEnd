using Microsoft.AspNetCore.Mvc;
using InPay__CuriousCat_BackEnd.Domain.MiddleWares;
using InPay__CuriousCat_BackEnd.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using InPay__CuriousCat_BackEnd.Domain.DTOs.Transactions;
using InPay__CuriousCat_BackEnd.Exceptions;
using Microsoft.AspNetCore.Cors;
using System.Text.Json.Nodes;



namespace InPay__CuriousCat_BackEnd.Controllers;

[ApiController]
[EnableCors]
[Route("user/{userId}/acc/{accNumber}/")]

public class TransactionsController(AccTransactionServices accTransactionService, TokensVerifications tokensVerifications) : ControllerBase
{
    private readonly AccTransactionServices _accTransactionService = accTransactionService;
    private readonly TokensVerifications _tokensVerifications = tokensVerifications;

    [HttpPost("/deposit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Deposit([FromBody] DepoistRequestDTO depositInfo)
    {
        try
        {
            await _accTransactionService.Deposit(depositInfo);

            return Ok();
        }
        catch (NotFoundException e)
        {
            return BadRequest(e.Message);
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
    [HttpPost("withdraw")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Withdraw(string userId, string accNumber, WithdrawRequestDTO withdrawRequestDTO)
    {
        try
        {
            Request.Headers.TryGetValue("authorization", out var authorization);
            var tokenClaims = _tokensVerifications.AccTokenVerification(authorization!);

            if (tokenClaims.UserId != userId || tokenClaims.AccNumber != accNumber)
                throw new UnauthorizedAccessException($"You're not authorized to acess this content");

            double userNewBalance = await _accTransactionService.Withdraw(tokenClaims, withdrawRequestDTO);

            JsonObject json = [];
            json.Add("NewBalance", userNewBalance);

            return Ok(json);
        }
        catch (NotFoundException e)
        {
            return BadRequest(e.Message);
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

    // [HttpPost("/deposit")]
    // [Authorize(AuthenticationSchemes = "Bearer")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    // public async Task<IActionResult> Deposit([FromBody] DepoistRequestDTO accPFCreateDTO, string id, string accNumber)
    // {
    //     try
    //     {
    //         Request.Headers.TryGetValue("authorization", out var authorization);
    //         var tokenClaims = _tokensVerifications.AccTokenVerification(authorization!);

    //         if (tokenClaims.UserId != id || tokenClaims.AccNumber != accNumber)
    //             throw new UnauthorizedAccessException("You're not authorized to acess this content");

    //         var accCreated = await _accTransactionService.Deposit(accPFCreateDTO, id);

    //         // return CreatedAtAction(nameof(GetAccInfoById), new { accCreated.Id }, accCreated);
    //         return Ok(accCreated);
    //     }
    //     catch (AlreadyExistsException e)
    //     {
    //         return BadRequest(e.Message);
    //     }
    //     catch (UnauthorizedAccessException e)
    //     {
    //         return Unauthorized(e.Message);
    //     }
    // }

}