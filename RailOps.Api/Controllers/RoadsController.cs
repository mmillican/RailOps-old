using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RailOps.Api.Models.Roster;
using RailOps.Shared.Data;
using RailOps.Shared.Domain.Roster;

namespace RailOps.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/roads")]
    public class RoadsController : Controller
    {
        private readonly RailOpsContext _dbContext;
        private readonly ILogger<RoadsController> _logger;

        public RoadsController(RailOpsContext dbContext,
            ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger<RoadsController>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var road = await _dbContext.Roads.FindAsync(id);
                if (road == null)
                    return NotFound();

                var model = new RoadModel
                {
                    Id = road.Id,
                    Code = road.Code,
                    Name = road.Name
                };

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not retrieve road ID {id}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> Get(string name = null)
        {
            try
            {
                var roads = await _dbContext.Roads
                    .Where(x => (string.IsNullOrEmpty(name) || x.Name.Contains(name)))
                    .OrderBy(x => x.Name)
                    .Select(x => new RoadModel
                    {
                        Id = x.Id,
                        Code = x.Code,
                        Name = x.Name
                    })
                    .ToListAsync();

                return Ok(roads);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not retrieve roads");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] RoadModel model)
        {
            try
            {
                var road = new Road
                {
                    Code = model.Code,
                    Name = model.Name
                };

                _dbContext.Roads.Add(road);
                await _dbContext.SaveChangesAsync();

                model.Id = road.Id;

                var url = Url.Action(nameof(GetById), new { id = road.Id });
                return Created(url, model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not create new road '{model.Name}'");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RoadModel model)
        {
            try
            {
                var road = await _dbContext.Roads.FindAsync(id);
                if (road == null)
                    return NotFound();

                road.Code = model.Code;
                road.Name = model.Name;

                await _dbContext.SaveChangesAsync();

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not update road ID {id} ({model.Name})");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // TODO: Verify it's not associated to any rolling stock
            try
            {
                var road = await _dbContext.Roads.FindAsync(id);
                if (road == null)
                    return NotFound();

                _dbContext.Roads.Remove(road);
                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Could not delete road ID {id}");
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
