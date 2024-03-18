namespace InPay__CuriousCat_BackEnd.Controllers;

using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using InPay__CuriousCat_BackEnd.Domain;
using InPay__CuriousCat_BackEnd.Domain.Models;
using InPay__CuriousCat_BackEnd.Domain.DTOs.User;
using Microsoft.EntityFrameworkCore;

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


   [HttpGet]
   [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   public ActionResult<IEnumerable<User>> GetAllUsers() {
      return Ok(_appDbContext.Users.ToList());
   } 


   [HttpGet("{id:int}")]
   [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
   public IActionResult GetUserById(int id) {
      var UserFind = _appDbContext.Users.Find(id);

      if(UserFind == null) {
         return NotFound();
      }

      return Ok(UserFind);
   }


   [HttpPost]
   public IActionResult AddUsers(UserResponseDTO newUser) {

     var UserAdd = _mapper.Map<User>(newUser);
     var result = _appDbContext.Users.Add(UserAdd);

     _appDbContext.SaveChanges();
     var UserSaved = result.Entity;

      return CreatedAtAction(nameof(GetUserById), new{ Id = UserSaved.id}, UserSaved);
   } 

   [HttpPut("{id:int}")]
   public async Task<IActionResult> AlteredUsers(int id, UserResponseDTO user) {
      
      if(id != user.id) 
         return BadRequest();


      _appDbContext.Entry(user).State = EntityState.Modified;

      try {
         await _appDbContext.SaveChangesAsync();

      } catch(DbUpdateConcurrencyException) {

         if(user.id != id) 
            return NotFound();
         else 
            throw;
      }

      return NoContent();
   
   }




   [HttpDelete("{id:int}")]
   public async Task<IActionResult> DeleteUser(int id) {

      var userId = await _appDbContext.Users.FindAsync(id);

      if(userId == null)
         return NotFound();

      _appDbContext.Users.Remove(userId);
      await _appDbContext.SaveChangesAsync();

      return NoContent();
   }







}


