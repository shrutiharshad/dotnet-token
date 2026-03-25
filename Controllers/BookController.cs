using Microsoft.AspNetCore.Mvc;

namespace Web_Api;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    
     private  readonly  AppDbContext? _DBcontext;

    public BookController( AppDbContext appDbContext)
    {
        _DBcontext=appDbContext;
    }

    [HttpGet]
    public ActionResult<string> Get([FromQuery] string avaiability)
    {   
        return Ok(_DBcontext.Books.Where(b=>b.Avaiability==avaiability)); 
    }
    
}
