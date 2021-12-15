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

        /*[HttpPost]
        [ProducesResponseType(typeof(int), 201)]
        public Task<IActionResult> Post(string title)
        {
            var result = _repository.createNewNode(title);

            return result.Result.Response == Core.Response.BadRequest ? CreatedAtAction(nameof(Get), result.Result.nodeID, result) : 2
        }*/

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
