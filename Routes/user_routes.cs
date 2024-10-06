
using Microsoft.EntityFrameworkCore;
using data;
using User_Model;
using user_schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using System.Security.Cryptography.X509Certificates;

namespace routes;

[ApiController]
[Tags("User")]
[Route("api/[controller]")]
public class User_Router : ControllerBase
{
    private readonly User_Controller _context;

    public User_Router(User_Controller context)
    {
        _context = context;
    }

    [HttpPost]
    public ActionResult<User> post_User(User_Schema user)
    {
        User pessoa = new User
        {
            Name = user.Name,
            Password = user.Password
        };
        _context.Users.Add(pessoa);
        try
        {
            _context.SaveChanges();
            return Ok(user);
        }
        catch (Exception ex) 
        {
            return BadRequest(ex);
        }

    }

    [HttpGet]
    public ActionResult<List<Dictionary<string, object>>> get_all() 
    {
        List<User> lista = _context.Users.ToList();
        List<Dictionary<string, object>> output = new List<Dictionary<string, object>>();
        if (lista.Count == 0) 
        {
            return BadRequest("Empty");
        }
        foreach(var item in lista)
            
        {
            output.Add(new Dictionary<string, object> { { "id",item.Id},{ "name",item.Name } });

        }
        return Ok(output);
         
        
    }

    [HttpGet("id")]
    public ActionResult<object> get_by_id(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) 
        {
            return BadRequest("Empty");
        }
        return Ok(new {  Id = user.Id ,Name = user.Name  });

    }

    [HttpDelete("id")]
    public ActionResult Delete(int id)
    {
        User user = _context.Users.Find(id);
        if (user == null)
        {
            return NotFound("user not found");
        }
        _context.Users.Remove(user);
        try
        {
            _context.SaveChanges();
            return Ok("Sucess");

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut("id")]
    public ActionResult<object> Put_user(int id, User_Schema user)
    {
        var person = _context.Users.Find(id);
        if (person == null)
        {
            return BadRequest("User not Found");
        }
        person.Name = user.Name;
        person.Password = user.Password;

        _context.Users.Update(person);
        try
        {
            _context.SaveChanges();
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }


}