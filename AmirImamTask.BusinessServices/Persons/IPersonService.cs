using AmirImamTask.Entities;
using AmirImamTask.Entities.Helpers;
using AmirImamTask.Entities.Infrastructures;

namespace AmirImamTask.BusinessServices;

public interface IPersonService : IPersonServiceBase<ResponseResult<Person>>
{
    
}
