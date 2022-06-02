using AmirImamTask.Entities;
using AmirImamTask.Entities.Helpers;
using AmirImamTask.Entities.Infrastructures;

namespace AmirImamTask.Entities.Infrastructures;

public interface IPersonService : IPersonServiceBase<ResponseResult<Person>>
{
    
}
