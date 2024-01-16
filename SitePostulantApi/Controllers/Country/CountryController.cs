using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SitePostulant.Application.Country.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitePostulantApi.Controllers.Country
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : BaseApiController
    {
        private readonly ICountryService countryService;
        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet("getcountry")]
        public async Task<IActionResult> GetCountry()
        {

            var result = await countryService.GetCountryes();

            return Ok(result);

        }
    }
}
