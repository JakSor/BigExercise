using AutoMapper;
using BigExercise.Logger;
using Data.DataAccessLayer;
using Domain;
using Domain.Parameters;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase

    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repo;
        private readonly ILoggerManager _logger;

        public ProductController(IProductRepository repository, IMapper autoMapper, ILoggerManager logger)
        {
            _mapper = autoMapper;
            _repo = repository;
            _logger = logger;
        }
        

        [HttpGet("GetAllProducts")]
        //toDo: filter en paginatie in zelfde 
       
        public async Task<ActionResult<ProductListDTO>> GetAllProducts([FromQuery] ProductParameters productParameters)
        {
            try
            {
                var products = await _repo.GetProducts(productParameters);
                _logger.LogInfo($"Returned {productParameters.PageSize} products from database. Page number :{productParameters.PageNumber}   ");
                var result = new ProductListDTO(); 
                foreach (var product in products)
                {
                    result.ProductDTOs.Add(_mapper.Map<ProductDTO>(product));
                }
                result.CountProducts = _repo.ReturnCount();
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not get list of products. {ex.Message}");
                
                return StatusCode(500, "Internal Server error");
            }
        }

        [AllowAnonymous]
        [HttpGet("GetProductDetails")]
        public ActionResult<ProductDTO> GetProduct(int id)
        {
            var ProductDTO = _mapper.Map<ProductDTO>(_repo.GetTById(id));
                return Ok(ProductDTO);
        }
        
        [HttpPost("CreateProduct")]
  
        public ActionResult CreateProduct([FromBody] ProductDTO productDTO)
        {
            try
            {

                if (productDTO == null)
                {
                    _logger.LogError("Product object sent from client is null.");
                    return BadRequest("Product object is null");
                }

                if (productDTO.IsFood)
                {
                    var product = _mapper.Map<Food>(productDTO);
                    _repo.Insert(product);
                    _repo.Save();
                    return Ok();
                }
                else
                {
                    var product = _mapper.Map<NonFood>(productDTO);
                    _repo.Insert(product);
                    _repo.Save();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
                
            }

        }
        [AllowAnonymous]

        [HttpPut("UpdateProduct")]
        public ActionResult UpdateProduct([FromBody] ProductDTO dto)
        {
            var entityToUpdate = _mapper.Map<Product>(dto);
            _repo.Update(entityToUpdate);
            _repo.Save();
            return Ok(dto);
        }

      

        [HttpDelete("DeleteProduct")]
        public ActionResult Delete(int id)
        {
            var entity = _repo.GetTById(id);
            if(entity != null)
            {
                _repo.Delete(id);
                _repo.Save();
            }
            return Ok();
            //todo paginatie/filter
        }
    }
}
