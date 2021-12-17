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

        [HttpPost]
        [ProducesResponseType(typeof(NodeDTO), 201)]
        [ProducesResponseType(null, 400)]
        public async Task<IActionResult> Post(NodeCreateDTO newNode)
        {
            var result = await _repository.createNewNode(newNode);
                
            if (result != null)
            {
                return CreatedAtAction(nameof(Get), new { result.id }, result);
            }

            return BadRequest();
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
        {
            return (await _repository.getNode(id)).ToActionResult();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            return (await _repository.deleteNode(id)).ToActionResult();
        }

    }

}


