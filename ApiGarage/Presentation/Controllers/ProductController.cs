using Business.DTOs.Request;
using Business.DTOs.Response;
using Business.Services.Abstract;
using Business.Services.Common;
using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }
        /// <summary>
        /// Mehsulun yaradilmasi ucun
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// <ul>
        /// <li> Type : 0-New,1-Sold,2-Seld</li>
        /// </ul>
        /// </remarks>
        [HttpPost]
        public async Task<Response> CreateAsync(ProductCreateDto model)
        {
            return await service.CreateAsync(model);
        }
        /// <summary>
        /// Mueyyen id-li bir mehsulu tapmaq ucun
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get")]
        public async Task<Response<ProductDto>> GetAsync(int id)
        {
            return await service.getAsync(id);
        }

        [HttpGet("getAll")]

        public async Task<Response<List<ProductDto>>> GetAllAsync()
        {
            return await service.getAllAsync();
        }
        /// <summary>
        /// Mehsulu update etmek ucun
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest,Type =typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound,Type =typeof(Response))]
        public async Task<Response> UpdateAsync(int id,ProductUpdateDto model)
        {
            return await service.UpdateAsync(id, model);
        }

        [HttpDelete]
        public async Task<Response> Delete(int id)
        {
            return await service.DeleteAsync(id);
        }





    }
}
