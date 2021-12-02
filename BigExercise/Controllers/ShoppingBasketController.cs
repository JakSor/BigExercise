using AutoMapper;
using Data.DataAccessLayer;
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
    public class ShoppingBasketController : ControllerBase

    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<ShoppingBasket> _repo;
        public ShoppingBasketController(IBaseRepository<ShoppingBasket> repository, IMapper autoMapper)
        {
            _mapper = autoMapper;
            _repo = repository;
        }
        [HttpGet("GetListShoppingBasket")]
        public ActionResult<IEnumerable<ShoppingBasketDTO>> GetAllShoppingBasket()
        {
            var entity = _repo.GetTs();
            var dto = _mapper.Map<ShoppingBasketDTO>(entity);
            return Ok(dto);
        }

        [HttpGet("GetShoppingBasket")]
        public ActionResult<ShoppingBasketDTO> GetShoppingBasket(int id)
        {
            var dto = _mapper.Map<ShoppingBasketDTO>(_repo.GetTById(id));
            return Ok(dto);
        }
        [HttpPost("CreateShoppingBasket")]
        public ActionResult CreateShoppingBasket([FromBody] ShoppingBasketDTO dto)
        {
            var entity = _mapper.Map<ShoppingBasket>(dto);
            _repo.Insert(entity);
            return Ok();
        }

        [HttpPut("UpdateShoppingBasket")]
        public async Task<ActionResult> UpdateShoppingBasket(int id,[FromBody] ShoppingBasketDTO dto)
        {
             var entity =await _repo.GetTById(id);
            dto.Id = id;
            _mapper.Map(dto, entity);
            _repo.Update(entity);
            await _repo.Save();
            return Ok(dto);
        }
    
        [HttpDelete("DeleteShoppingBasket")]
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
