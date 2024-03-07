using Core.Application.Repositories;
using Core.Application.ViewModel;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UsersController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [Route("add")]
    public async Task<ActionResult<bool>> AddUser([FromBody] VM_AddUser vm_addUser)
    {
        User user = new()
        {
            Name = vm_addUser.Name,
            Surname = vm_addUser.Surname,
            Email = vm_addUser.Email,
            Password = vm_addUser.Password,
        };
        var userControl =await _repository.GetWhere(u => u.Email == vm_addUser.Email).FirstOrDefaultAsync();
        if (userControl != null)
        {
            throw new Exception("Email adresi zaten kayıtlı");
        }
        var result = await _repository.AddAsync(user);
        if (result)
        {
            return Ok("Kişi eklendi");
        }
        else
        {
            return BadRequest("Server da bir hata oluştu");
        }
    }

    [HttpPost]
    [Route("update")]
    public async Task<ActionResult<bool>> UpdateUserPassword([FromBody]VM_UpdateUser vm_updateUser)
    {
        var user = await _repository.GetByIdAsync(vm_updateUser.Id);

        if (user == null)
        {
            throw new ArgumentNullException("Bu Id de bir kullanıcı bulunamadı");
        }
        
        user.Password = vm_updateUser.Password;
        
        var result = _repository.Update(user);
        if (result)
        {
            return Ok("Kişi Güncellendi");
        }
        else
        {
            return BadRequest("Server da bir hata oluştu");
        }
    }
}


