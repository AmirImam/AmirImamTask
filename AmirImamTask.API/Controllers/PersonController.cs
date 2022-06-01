
using AmirImamTask.Entities.Helpers;

namespace AmirImamTask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase, IPersonServiceBase<IActionResult>
{
    private readonly IPersonService service;
    private readonly IConfiguration configuration;

    public PersonController(IPersonService service,IConfiguration configuration)
    {
        this.service = service;
        this.configuration = configuration;
    }
    
    [HttpGet]
    public async Task<IEnumerable<Person>> GetAllAsync() => await service.GetAllAsync();
    
    
    [HttpGet]
    [Route("/api/[controller]/{id}")]
    public async Task<Person> GetAsync(Guid id) => await service.GetAsync(id);
    
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync(Person entity)
    {
        var result = await service.CreateAsync(entity);
        if(result.Success == true)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(Person entity)
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
    
    [HttpPost]
    [Route("/api/Person/Login")]
    public async Task<IActionResult> LoginAsync(LoginModel model)
    {
        model.Token = configuration["TokenKey"];
        var result = await service.LoginAsync(model);
        if (result.Success == true)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    [HttpPost]
    [Route("/api/Person/ChangePassword")]
    public async Task<IActionResult> ChangePasswordAsync(ChangePasswordModel model)
    {
        var result = await service.ChangePasswordAsync(model);
        if(result.Success == true)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
}
