
using AmirImamTask.Entities.Dtos;

namespace AmirImamTask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ItemStoreController : ControllerBase, IItemStoreServiceBase<IActionResult>
{
    private readonly IItemStoreService service;

    public ItemStoreController(IItemStoreService service)
    {
        this.service = service;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ItemStore>> GetAllAsync() => await service.GetAllAsync();
    
    
    [HttpGet]
    [Route("/api/[controller]/{id}")]
    public async Task<ItemStore> GetAsync(Guid id) => await service.GetAsync(id);
    
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync(ItemStore entity)
    {
        var result = await service.CreateAsync(entity);
        if(result.Success == true)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(ItemStore entity)
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
    [HttpGet]
    [Route("/api/ItemStore/GetItemStoresByItem/{itemId}")]
    public async Task<IEnumerable<ItemStoreDto>> GetItemStoresByItemAsync(Guid itemId)
    {
        var result = await service.GetItemStoresByItemAsync(itemId);
        return result;
    }
}

