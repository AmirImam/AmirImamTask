
using AmirImamTask.API.Services;
using AmirImamTask.Entities.Dtos;

namespace AmirImamTask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase, IItemServiceBase<IActionResult>
{
    private readonly IItemService service;
    private readonly ReportsService reportsService;

    public ItemController(IItemService service,ReportsService reportsService)
    {
        this.service = service;
        this.reportsService = reportsService;
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

    [HttpGet]
    [Route("/api/Item/GetItemBalances")]
    public async Task<IEnumerable<ItemStoreDto>> GetItemBalancesAsync()
        => await service.GetItemBalancesAsync();

    [HttpGet]
    [Route("/api/Item/BalancesReport")]
    public async Task<IActionResult> BalancesReportAsync()
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        var dataSource = await service.GetItemBalancesAsync();
        
        reportsService.ReportName = "ItemsBalances.rdl";
        reportsService.DataSource = new("DataSet1", dataSource);
        var reportResult = reportsService.Execute();
        return File(reportResult, "application/pdf");
    }
}

