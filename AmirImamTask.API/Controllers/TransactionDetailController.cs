
using AmirImamTask.Entities.Dtos;

namespace AmirImamTask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionDetailController : ControllerBase, ITransactionDetailServiceBase<IActionResult>
{
    private readonly ITransactionDetailService service;

    public TransactionDetailController(ITransactionDetailService service)
    {
        this.service = service;
    }
    
    [HttpGet]
    public async Task<IEnumerable<TransactionDetail>> GetAllAsync() => await service.GetAllAsync();
    
    
    [HttpGet]
    [Route("/api/[controller]/{id}")]
    public async Task<TransactionDetail> GetAsync(Guid id) => await service.GetAsync(id);
    
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync(TransactionDetail entity)
    {
        var result = await service.CreateAsync(entity);
        if(result.Success == true)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(TransactionDetail entity)
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
    [Route("/api/TransactionDetail/FindItemsByStoreAsync/{storeId}")]
    public async Task<IEnumerable<TransactionDetailDto>> FindItemsByStoreAsync(Guid storeId)
    {
        var result = await service.FindItemsByStoreAsync(storeId);
        return result;
    }
}

