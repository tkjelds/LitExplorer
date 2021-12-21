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
using Microsoft.AspNetCore.Authorization;

namespace iLit.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/")]
    public class NodeController : ControllerBase
    {
        private readonly INodeRepository _repository;
        private readonly ILogger<NodeController> _logger;

        public NodeController(ILogger<NodeController> logger, INodeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(NodeDTO), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(NodeCreateDTO newNode)
        {
            var result = await _repository.createNewNode(newNode);
                
            if (result != null)
            {
                return CreatedAtAction(nameof(Get), new { result.id }, result);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpGet]
        public async Task<IReadOnlyCollection<NodeDTO>> Get()
        {
            return await _repository.getAllNodes();
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(NodeDTO), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<NodeDTO>> Get(int id)
        {
            return (await _repository.getNode(id)).ToActionResult();
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            return (await _repository.deleteNode(id)).ToActionResult();
        }

    }

}

