using Azure;
using DataAccess_Layer;
using DataAccess_Layer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API_Layer.Controllers
{
    [Route("API/People")]
    [ApiController]
    public class PeopleController : ControllerBase
    {




        [HttpGet("GetAllPeople")]
        public ActionResult<dynamic> GetAllPeople()
        {
           // return ePeopleDA.GetAllPeople();

            return temp.ExecGetAllPeople();
        }


    }
}
