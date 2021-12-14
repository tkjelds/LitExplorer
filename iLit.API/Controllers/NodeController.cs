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
    public class NodeController : ControllerBase
    {
        private readonly INodeRepository _repository;
        private readonly ILogger<NodeController> _logger;

        public NodeController(ILogger<NodeController> logger, INodeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

    }

}
