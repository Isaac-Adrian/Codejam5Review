using Microsoft.AspNetCore.Mvc;
using CodeJam5b.Models;
using CodeJam5b.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CodeJam5b.Server.Controllers
{
    public class ProgressData
    {
        public string? Id { get; set; }
        
        [Range(0, 1000, ErrorMessage = "Current weight must be between 0 and 1000")]
        public int CurrentWeight { get; set; }
        
        [Range(0, 1000, ErrorMessage = "Target weight must be between 0 and 1000")]
        public int TargetWeight { get; set; }
        
        [Range(0, 10000, ErrorMessage = "Target calories must be between 0 and 10000")]
        public int TargetCals { get; set; }
        
        [Range(0, 1000, ErrorMessage = "Target carbs must be between 0 and 1000")]
        public int TargetCarbs { get; set; }
        
        [Range(0, 1000, ErrorMessage = "Target fat must be between 0 and 1000")]
        public int TargetFat { get; set; }
        
        [Range(0, 1000, ErrorMessage = "Target protein must be between 0 and 1000")]
        public int TargetProtein { get; set; }
    }

    [ApiController]
    [Route("api/progress")]
    public class ProgressController : ControllerBase
    {
        private readonly CalorieCounterContext _db;
        public ProgressController(CalorieCounterContext db) { _db = db; }

        [HttpGet]
        public async Task<ActionResult<ProgressData>> Get()
        {
            var progress = await _db.Progress.FirstOrDefaultAsync();
            if (progress is null) return NotFound();
            
            return new ProgressData
            {
                Id = progress.ProgressId,
                CurrentWeight = progress.CurrentWeight,
                TargetWeight = progress.TargetWeight,
                TargetCals = progress.TargetCals,
                TargetCarbs = progress.TargetCarbs,
                TargetFat = progress.TargetFat,
                TargetProtein = progress.TargetProtein
            };
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProgressData body)
        {
            var progress = await _db.Progress.FirstOrDefaultAsync();
            if (progress is null)
            {
                // Create new progress record
                progress = new UserProgress
                {
                    ProgressId = Guid.NewGuid().ToString(),
                    CurrentWeight = body.CurrentWeight,
                    TargetWeight = body.TargetWeight,
                    TargetCals = body.TargetCals,
                    TargetCarbs = body.TargetCarbs,
                    TargetFat = body.TargetFat,
                    TargetProtein = body.TargetProtein
                };
                _db.Progress.Add(progress);
            }
            else
            {
                progress.CurrentWeight = body.CurrentWeight;
                progress.TargetWeight = body.TargetWeight;
                progress.TargetCals = body.TargetCals;
                progress.TargetCarbs = body.TargetCarbs;
                progress.TargetFat = body.TargetFat;
                progress.TargetProtein = body.TargetProtein;
            }
            
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
