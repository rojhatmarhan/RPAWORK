using DATA.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using SERVICES.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly IDistributedCache _cache;
        public ProductController(ILogger<ProductController> logger, IProductService productService, IDistributedCache cache)
        {
            _logger = logger;
            _productService = productService;
            _cache = cache;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                //DISTRUBUTED CACHE
                //const string key = "";

                //var cachedItem = await _cache.GetStringAsync(key);

                //if (!string.IsNullOrEmpty(cachedItem))
                //    return Ok(JsonConvert.DeserializeObject<ENTITIES.Concrete.Product>(cachedItem));
                //else
                //{
                //    const string str = "";
                //    var data = await _productService.GetAllAsync();
                //    await _cache.SetStringAsync(key, JsonConvert.SerializeObject(data));
                //    return Ok(data);
                //}

                var data = await _productService.GetAllAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var datum = await _productService.GetAsync(id);
                return Ok(datum);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
