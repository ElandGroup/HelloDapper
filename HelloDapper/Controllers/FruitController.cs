using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using HelloDapper.Models;
using HelloDapper.Service;


namespace HelloDapper.Controllers
{
    public class FruitController : ApiController
    {
        readonly IFruitService _fruitService;
        public FruitController(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }
        public async Task<IHttpActionResult> Get()
        {
            var fruitResult = await _fruitService.FruitQuery();
            return Ok(fruitResult);
        }
        public async Task<IHttpActionResult> Get(string name)
        {
            var fruitResult = await _fruitService.FruitQuery(name);
            return Ok(fruitResult);
        }

        public IHttpActionResult Post([FromBody]List<FruitDto> fruitDtoList)
        {
            if (fruitDtoList == null)
            {
                return BadRequest("A required parameter is missing or parameter doesn't have the right format");
            }
            _fruitService.FruitInsert(fruitDtoList);
            return Content(HttpStatusCode.NoContent, this.GetType());
        }

        public IHttpActionResult Put([FromBody]List<FruitDto> fruitDtoList)
        {
            if (fruitDtoList == null)
            {
                return BadRequest("A required parameter is missing or parameter doesn't have the right format");
            }
            _fruitService.FruitUpdate(fruitDtoList);
            return Content(HttpStatusCode.NoContent, this.GetType());
        }
    }
}
