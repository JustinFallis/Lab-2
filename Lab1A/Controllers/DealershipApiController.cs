// I, Justin Fallis, 000398973, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1A.Data;
using Lab1A.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealershipApiController : ControllerBase
    {
        private readonly DealershipMgr _context;

        public DealershipApiController(DealershipMgr context)
        {
            _context = new DealershipMgr();
        }

        // GET: api/DealershipApi
        [HttpGet]
        public IEnumerable<Dealership> Get()
        {
            return _context.Get();
        }

        // GET: api/DealershipApi/5
        [HttpGet("{id}", Name = "Get")]
        public Dealership Get(int id)
        {
            return _context.GetDealership(id);
        }

        // POST: api/DealershipApi
        [HttpPost]
        public void Post([FromBody] Dealership dealership)
        {
            if((dealership.Name != null || dealership.Name != "") && (dealership.Email != null || dealership.Email != ""))
            {
                _context.PostDealership(dealership);

            }     
        }

        // PUT: api/DealershipApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Dealership dealership)
        {
            if ((dealership.Name != null || dealership.Name != "") && (dealership.Email != null || dealership.Email != ""))
            {
                _context.PutDealership(id, dealership);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.DeleteDealership(id);
        }
    }
}
