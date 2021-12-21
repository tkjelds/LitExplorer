using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iLit.Infrastructure;
using iLit.Core;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace iLit.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/")]
    public class EdgeController : ControllerBase
    {
        private readonly IEdgeRepository _repository;
        private readonly ILogger<EdgeController> _logger;

        public EdgeController(ILogger<EdgeController> logger, IEdgeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(EdgeDTO), 201)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(EdgeCreateDTO newEdge)
        {
            var result = await _repository.createNewEdge(newEdge);

            if (result != null)
            {
                return CreatedAtAction(nameof(Get), new { result.edgeID }, result);
            }

            return BadRequest();
        }
        [Authorize]
        [HttpGet]
        public async Task<IReadOnlyCollection<EdgeDTO>> Get()
        {
            return await _repository.getAllEdges();
        }

        [Authorize]
        [HttpGet("ToNodeId/{id}")]
        public async Task<IReadOnlyCollection<EdgeDTO>> GetEdgesToNodeId(int id)
        {
            return await _repository.getEdgesRelatedToNodeId(id);
        }

        [Authorize]
        [HttpGet("FromNodeId/{id}")]
        public async Task<IReadOnlyCollection<EdgeDTO>> GetEdgesFromNodeId(int id)
        {
            return await _repository.getEdgesRelatedFromNodeId(id);
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(EdgeDTO), StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<ActionResult<EdgeDTO>> Get(int id)
        {
            return (await _repository.getEdge(id)).ToActionResult();
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            return (await _repository.deleteEdge(id)).ToActionResult();
        }
    }

}
