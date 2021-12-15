using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iLit.Infrastructure;
using iLit.Core;
using Microsoft.Extensions.Logging;
using iLit.API;
using static iLit.API.Extensions;

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

        public Task<CreatedAtActionResult> Post(string title)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<NodeDTO>> Get()
        {
            return await _repository.getAllNodes();
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(NodeDTO), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<NodeDTO>> Get(int id)
            => (await _repository.getNode(id)).ToActionResult();
        
    }

}
