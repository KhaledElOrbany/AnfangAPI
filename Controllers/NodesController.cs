using System.Collections.Generic;
using AnfangAPI.Data;
using AnfangAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnfangAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly INodeRepo _nodeRepo;

        public NodesController(INodeRepo nodeRepo)
        {
            _nodeRepo = nodeRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Node>> GetAllNodes()
        {
            var nodes = _nodeRepo.GetAllNodes();
            if (nodes != null)
            {
                return Ok(nodes);
            }
            else
            {
                return new EmptyResult();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Node> GetNodeById(int id)
        {
            return Ok(_nodeRepo.GetNodeById(id));
        }
    }
}