
namespace AmirImamTask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase, IItemServiceBase<IActionResult>
{
    private readonly IItemService service;

    public ItemController(IItemService service)
    {
        this.service = service;
    }
    
    [HttpGet]
    public async Task<IEnumerable<Item>> GetAllAsync() => await service.GetAllAsync();
    
    
    [HttpGet]
    [Route("/api/[controller]/{id}")]
    public async Task<Item> GetAsync(Guid id) => await service.GetAsync(id);
    
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync(Item entity)
    {
        var result = await service.CreateAsync(entity);
        if(result.Success == true)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(Item entity)
    {
        var result = await service.UpdateAsync(entity);
        if (result.Success == true)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await service.DeleteAsync(id);
        if (result.Success == true)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    

}

