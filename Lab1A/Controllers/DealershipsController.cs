// I, Justin Fallis, 000398973, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab1A.Models;
using Lab1A.Data;

namespace Lab1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealershipsController : ControllerBase
    {

        private readonly DealershipMgr _context;

        public DealershipsController(DealershipMgr context)
        {
            _context = new DealershipMgr();
        }

        // GET: api/Dealerships
        [HttpGet]
        public IEnumerable<Dealership> GetDealership()
        {
            return _context.Get();
        }

        // GET: api/Dealerships/5
        [HttpGet("{id}")]
        public Dealership GetDealership(int id)
        {
            var dealership = _context.GetDealership(id);

            if (dealership == null)
            {
                return null;
            }

            return dealership;
        }

        // PUT: api/Dealerships/5
        [HttpPut("{id}")]
        public string PutDealership(int id, Dealership dealership)
        {
            if (id != dealership.ID)
            {
                return "Error";
            }

            return (_context.PutDealership(id, dealership));
        }

        // POST: api/Dealerships
        [HttpPost]
        public Dealership PostDealership(Dealership dealership)
        {
            return _context.PostDealership(dealership);
        }

        // DELETE: api/Dealerships/5
        [HttpDelete("{id}")]
        public String DeleteDealership(int id)
        {
            return _context.DeleteDealership(id);
        }
    }
}
