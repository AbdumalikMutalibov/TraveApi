using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraveApi.DataLayer;
using TraveApi.Dtos;

namespace TraveApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public TravelController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
      
        [HttpPost]
        public async  Task<IActionResult> CreateHuman(CreateHumanDto createHumanDto)
        {
            if (await dbContext.Humans.AnyAsync(h => h.Fullname.ToLower() == createHumanDto.Fullname.ToLower()))
                return BadRequest("Human with this name already exists");
            var human = await dbContext.Humans.AddAsync(new Entity.Human
            {
                Id = Guid.NewGuid(),
                Fullname = createHumanDto.Fullname,
                Travelprice = createHumanDto.Travelprice,
                TravelData = createHumanDto.TravelData,
                Age = createHumanDto.Age,
                Data = createHumanDto.Data,
                GroupId = createHumanDto.GroupId,
            });

            await dbContext.SaveChangesAsync(); 
            return Ok(human.Entity.Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetHumans([FromQuery] string search)
        {
            var humanSearch = dbContext.Humans.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                humanSearch = humanSearch. Where(h =>
                h.Fullname.ToLower() .Contains (search.ToLower()));
            var travel = await humanSearch.
                Select(h => new GetHumanDto(h))
                .ToListAsync();
            return Ok(travel);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHuman([FromRoute] Guid id)
        {
            var HumanID = await dbContext.Humans
                .Where(h => h.Id == id)
                .FirstOrDefaultAsync();
            if (HumanID is null)
                return NotFound();
            return Ok(new GetHumanDto(HumanID));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]Guid id,
            UpdateHumanDto dto)
        {
            var HumanId = await dbContext.Humans
                .FirstOrDefaultAsync(h => h.Id == id);
            
            if (HumanId is null)
                return NotFound();
           
            HumanId.Fullname = dto.Fullname;
            HumanId.Travelprice = dto.Travelprice;
            HumanId.Age = dto.Age;
            HumanId.GroupId = dto.GroupId;
            HumanId.TravelData = dto.TravelData;

            await dbContext.SaveChangesAsync();
            return Ok(HumanId.Id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var HumanId = await dbContext.Humans.FirstOrDefaultAsync(h => h.Id == id);
            if (HumanId is null)
                return NotFound();

            dbContext.Humans.Remove(HumanId);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
