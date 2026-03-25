using Microsoft.AspNetCore.Mvc;

namespace Web_Api;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private  readonly  AppDbContext? _DBcontext;

    public ProductController( AppDbContext appDbContext)
    {
        _DBcontext=appDbContext;
    }

    [HttpGet]
    public ActionResult<string> Get()
    {
        var products= _DBcontext.Products.ToArray();

        return Ok(products) ;
    }

    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        var product=_DBcontext.Products.FirstOrDefault(p=>p.Id==id);

        return Ok(product);
    }
    
    [HttpGet("price")]
    public ActionResult<string> Get([FromQuery] int min, [FromQuery]int max)
    {
        var products = _DBcontext.Products.Where(p=> p.Price>min && p.Price<max);

        return Ok(products);
    }
}
