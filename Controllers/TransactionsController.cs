using Microsoft.AspNetCore.Mvc;
using AutoMapper;


namespace InPay__CuriousCat_BackEnd.Controllers;

[ApiController]
[Route("transaction")]

public class TransactionsController(IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
}