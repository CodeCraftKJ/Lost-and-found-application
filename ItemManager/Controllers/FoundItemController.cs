using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItemManager.Models.FoundItems;
using ItemManager.Services;
using ItemManager.DTOs;

namespace ItemManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoundItemController : ControllerBase
    {
        private readonly IFoundItemService _foundItemService;
        private readonly IMapper _mapper;

        public FoundItemController(IFoundItemService foundItemService, IMapper mapper)
        {
            _foundItemService = foundItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoundItemDTO>>> GetAllFoundItems()
        {
            var items = await _foundItemService.GetAllAsync();
            var itemsDTO = _mapper.Map<IEnumerable<FoundItemDTO>>(items);
            return Ok(itemsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FoundItemDTO>> GetFoundItemById(int id)
        {
            var item = await _foundItemService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            var itemDTO = _mapper.Map<FoundItemDTO>(item);
            return Ok(itemDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddFoundItem(FoundItemDTO itemDTO)
        {
            var item = _mapper.Map<FoundItem>(itemDTO);
            await _foundItemService.AddAsync(item);
            return CreatedAtAction(nameof(GetFoundItemById), new { id = item.ItemId }, itemDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFoundItem(int id, FoundItemDTO itemDTO)
        {
            if (id != itemDTO.ItemId)
            {
                return BadRequest();
            }

            var item = _mapper.Map<FoundItem>(itemDTO);
            await _foundItemService.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveFoundItem(int id)
        {
            await _foundItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}
