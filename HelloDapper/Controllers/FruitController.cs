using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using HelloDapper.Service;

namespace HelloDapper.Controllers
{
    public class FruitController : ApiController
    {
        IFruitService _fruitService = new FruitService();
        public async Task<IHttpActionResult> Get()
        {
            var fruitResult = await _fruitService.FruitQuery();
            return Ok(fruitResult);
        }
    }
}
