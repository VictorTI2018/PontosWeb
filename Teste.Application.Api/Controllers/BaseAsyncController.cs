using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste.Core.Domain.Interfaces.Services;

namespace Teste.Application.Api.Controllers
{
    [ApiController]
    public class BaseAsyncController<TEntity, TKey, TEntityDto> : ControllerBase where TEntity: class
    {
        private readonly IServiceBase<TEntity, TKey> _serviceBase;
        private readonly IMapper _mapper;

        public BaseAsyncController(IServiceBase<TEntity, TKey> serviceBase, IMapper mapper)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _serviceBase.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(TKey id)
        {
            return Ok(await _serviceBase.GetByIdAsync(id));
        }

        /// <summary>
        /// Creates.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Criar novo item</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST 
        ///     {
        ///        "id": 1,
        ///        "name": "Item #1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TEntityDto dto)
        {
            try
            {
                TEntity dados = _mapper.Map<TEntityDto, TEntity>(dto);
                return Ok(await _serviceBase.SaveAsync(dados));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] TEntityDto dto)
        {
            try
            {
                TEntity dados = _mapper.Map<TEntityDto, TEntity>(dto);
                return Ok(await _serviceBase.UpdateAsync(dados));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(TKey id)
        {
            try
            {
                return Ok(await _serviceBase.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
