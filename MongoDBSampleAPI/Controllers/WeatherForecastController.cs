using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDBSampleAPI.Repository;
using System.Collections.Generic;

namespace MongoDBSampleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMongoDBRepository _dBRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMongoDBRepository dBRepository)
        {
            _logger = logger;
            _dBRepository = dBRepository;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            List<object> _list = new List<object>();

            var result = _dBRepository.GetAll();

            foreach (var item in result)
            {
                _list.Add(item.ToJson());
            }

            return _list;
        }
    }
}
