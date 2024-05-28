using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItemManager.Models.LostItems;
using ItemManager.Services;
using ItemManager.DTOs;

namespace ItemManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LostItemController : ControllerBase
    {
        private readonly ILostItemService _lostItemService;
        private readonly IMapper _mapper;

        public LostItemController(ILostItemService lostItemService, IMapper mapper)
        {
            _lostItemService = lostItemService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LostItemDTO>>> GetAllLostItems()
        {
            var items = await _lostItemService.GetAllAsync();
            var itemsDTO = _mapper.Map<IEnumerable<LostItemDTO>>(items);
            return Ok(itemsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LostItemDTO>> GetLostItemById(int id)
        {
            var item = await _lostItemService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            var itemDTO = _mapper.Map<LostItemDTO>(item);
            return Ok(itemDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddLostItem(LostItemDTO itemDTO)
        {
            var item = _mapper.Map<LostItem>(itemDTO);
            await _lostItemService.AddAsync(item);
            return CreatedAtAction(nameof(GetLostItemById), new { id = item.ItemId }, itemDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLostItem(int id, LostItemDTO itemDTO)
        {
            if (id != itemDTO.ItemId)
            {
                return BadRequest();
            }

            var item = _mapper.Map<LostItem>(itemDTO);
            await _lostItemService.AddAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveLostItem(int id)
        {
            await _lostItemService.DeleteAsync(id);
            return NoContent();
        }
    }
}
