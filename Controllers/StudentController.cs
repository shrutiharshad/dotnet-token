using Microsoft.AspNetCore.Mvc;

namespace Web_Api;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    
    private  readonly  AppDbContext? _DBcontext;

    public StudentController( AppDbContext appDbContext)
    {
        _DBcontext=appDbContext;
    }

    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        var studentById=_DBcontext.Students.FirstOrDefault(s=>s.Id==id);

        if (studentById== null)
        {
            return NotFound(new{ message ="Student not found !"});
        }
        
        return Ok();
    }
}
