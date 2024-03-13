using Microsoft.AspNetCore.Mvc;
using AutoMapper;


namespace InPay__CuriousCat_BackEnd.Controllers;


[ApiController]
[Route("users")]

public class UserController(IMapper mapper) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
}


