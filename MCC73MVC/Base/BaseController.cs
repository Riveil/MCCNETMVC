using MCC73MVC.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MCC73MVC.Base;

public class BaseController<Entity, Repository, T> : Controller where Entity : class where Repository : IRepository<Entity, T>
{


    private readonly Repository _repositories;
    public BaseController(Repository repositories)
    {
        _repositories = repositories;
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        try
        {
            var result = _repositories.Get();
            return result.Count() == 0
                ? Ok(new { statusCode = 200, message = "Data Not Found!" })
                : Ok(new { statusCode = 200, message = "success", data = result });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = $"Something Wrong! : {e.Message}" });
        }
    }

    [HttpGet]

    [Route("{id}")]

    public ActionResult GetById(T id)
    {
        try
        {
            var result = _repositories.Get(id);
            return result == null
                ? Ok(new { statusCode = 200, message = "Data Not Found!" })
                : Ok(new { statusCode = 200, message = "success", data = result });
        }
        catch (Exception e)
        {

            return BadRequest(new { message = $"Something Wrong! : {e.Message}" });
        }

    }

    [HttpPost]
    public ActionResult Insert(Entity entity)
    {
        try
        {
            var result = _repositories.Insert(entity);
            return result == 0
                ? Ok(new { statusCode = 200, message = "Data Failed to Save!" })
                : Ok(new { statusCode = 200, message = "Data Save Successfully!" });
        }          //operation ternary
        catch (Exception e)
        {
            return BadRequest(new { message = $"Something Wrong! : {e.Message}" });
        }
    }

    [HttpPut]
    public ActionResult Update(Entity entity)
    {
        try
        {
            var result = _repositories.Update(entity);
            return result == 0
                ? Ok(new { statusCode = 200, message = "Data Not Found!" })
                : Ok(new { statusCode = 200, message = $"Data Has Changed!" });
        }
        catch (Exception e)
        {

            return BadRequest(new { message = $"Something Wrong! : {e.Message}" });
        }

    }

    [HttpDelete]

    public ActionResult Delete(T id)
    {
        try
        {
            var result = _repositories.Delete(id);
            return result == 0
               ? Ok(new { statusCode = 200, message = "Data Not Found!" })
               : Ok(new { statusCode = 200, message = $"Data {id} Has Deleted!" });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = $"Something Wrong! : {e.Message}" });
        }
    }
}
