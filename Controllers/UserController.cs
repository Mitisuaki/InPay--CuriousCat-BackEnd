namespace InPay__CuriousCat_BackEnd.Controllers;

using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain;

[ApiController]
[Route("users")]
public class UserController: ControllerBase
{

    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;
     
     public UserController(IMapper mapper, AppDbContext appDbContext) {
        _mapper = mapper;
        _appDbContext = appDbContext;
     }



    


}


