using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDummyAPI.DTOs;
using MyDummyAPI.Repositories.Interfaces;
using MyDummyAPI.Services.Interfaces;

namespace MyDummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnersController : ControllerBase
    {
        private readonly IPartnerServices partnerServices;
        public PartnersController(IPartnerServices partnerServices)
        {
            this.partnerServices = partnerServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await partnerServices.getAllPartner();
            return Ok(result);
        }

        [HttpPost("AddPartner")]
        public async Task<IActionResult> addPartner(PartnerDTO partnerDTO)
        {
            var reult = await partnerServices.addPartner(partnerDTO);
            return Ok(reult);
        }
    }
}
