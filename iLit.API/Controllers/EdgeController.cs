using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iLit.Infrastructure;
using iLit.Core;
using Microsoft.Extensions.Logging;

namespace iLit.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EdgeController : ControllerBase
    {
        private readonly IEdgeRepository _repository;
        private readonly ILogger<EdgeController> _logger;

        public EdgeController(ILogger<EdgeController> logger, IEdgeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

    }

}
