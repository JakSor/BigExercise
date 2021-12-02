using AutoMapper;
using Domain;
using Domain.Parameters;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingBasketItemController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IBaseRepository<ShoppingBasketItem> _repo;
        public ShoppingBasketItemController(IBaseRepository<ShoppingBasketItem> repository, IMapper autoMapper)
        {
            _mapper = autoMapper;
            _repo = repository;
        }
        [HttpGet("GetListShoppingBasketItem")]
        public ActionResult<IEnumerable<ShoppingBasketItemDTO>> GetAllShoppingBasketItem()
        {
            var entity = _repo.GetTs();
            var dto = _mapper.Map<ShoppingBasketItemDTO>(entity);
            return Ok(dto);
        }

        [HttpGet("GetShoppingBasketItem")]
        public ActionResult<ShoppingBasketItemDTO> GetShoppingBasketItem(int id)
        {
            var dto = _mapper.Map<ShoppingBasketItemDTO>(_repo.GetTById(id));
            return Ok(dto);
        }
        [HttpPost("CreateShoppingBasketItem")]
        public ActionResult CreateShoppingBasketItem([FromBody] ShoppingBasketItemDTO dto)
        {
            var entity = _mapper.Map<ShoppingBasketItem>(dto);
            _repo.Insert(entity);
            return Ok();
        }
        
        [HttpPut("UpdateShoppingBasketItem")]
        public async Task<ActionResult> UpdateShoppingBasketItem(int id, [FromBody] ShoppingBasketDTO dto)
        {
            var entity = await _repo.GetTById(id);
            dto.Id = id;
            _mapper.Map(dto, entity);
            _repo.Update(entity);
            _repo.Save();
            return Ok(dto);
        }
        [HttpDelete("DeleteShoppingBasketItem")]
        public ActionResult Delete(int id)
        {
            var entity = _repo.GetTById(id);
            if (entity != null)
            {
                _repo.Delete(id);
                _repo.Save();
            }
            return Ok();

        }
    }
}
