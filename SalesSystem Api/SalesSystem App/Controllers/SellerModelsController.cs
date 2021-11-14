using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesSystem_App.Interfaces;
using SalesSystem_App.Models;
using SalesSystem_App.Requests;
using SalesSystem_App.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesSystem_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerModelsController : ControllerBase
    {
        private readonly ISellersRepository _repository;

        public SellerModelsController(ISellersRepository repository)
        {
            _repository = repository;
        }

        
        // GET: api/SellerModels/5
        [HttpGet]
        public ActionResult<List<SellerResponse>> GetSellerModel()
        {
            var parentandChildNodes = _repository.Seller_get();

            if (parentandChildNodes == null)
            {
                return NotFound();
            }

            return parentandChildNodes;
        }


        // POST: api/SellerModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<SellerResponse> PostSellerModel(SellerRequest seller)
        {
            try
            {
                _repository.AddSeller(seller);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

            return Ok();
        }
    }
}
