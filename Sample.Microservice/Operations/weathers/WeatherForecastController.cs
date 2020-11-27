using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Sample.Microservice.Services.Weather;
using Sample.Microservice.Operations.Weather.ViewModels;
namespace Sample.Microservice.Operations
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController
    {
    
        private readonly IMapper _mapper;
        private readonly IWeatherService _weatherService;
        public WeatherForecastController(
            IWeatherService weatherService,
            IMapper mapper
        )
        {
            _weatherService = weatherService;
            _mapper = mapper;
        }

        /// <summary>
        /// Return a list of all movies
        /// </summary>
        /// <remarks>
        /// Use this operation to return a list of all movies
        /// </remarks>
        /// <response code="200">Returns a list of all movies</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]    
        [HttpGet]
        public async Task<ActionResult<List<WeatherViewModel>>> Get()
        {
           var weather = _weatherService.Get();
           var response = _mapper.Map<List<WeatherViewModel>>(weather);
           return HandleSuccessResponse(response);
        }
    }
}
