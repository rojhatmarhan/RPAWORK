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
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IDistributedCache _cache;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService, IDistributedCache cache)
        {
            _logger = logger;
            _categoryService = categoryService;
            _cache = cache;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                //DISTRUBUTED CACHE

                //const string key = "";

                //var cachedItem = await _cache.GetStringAsync(key);

                //if (!string.IsNullOrEmpty(cachedItem))
                //    return Ok(JsonConvert.DeserializeObject<ENTITIES.Concrete.Category>(cachedItem));
                //else
                //{
                //    const string str = "";
                //    var data = await _categoryService.GetAllAsync();
                //    await _cache.SetStringAsync(key, JsonConvert.SerializeObject(data));
                //    return Ok(data);
                //}

                var data = await _categoryService.GetAllAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var datum = await _categoryService.GetAsync(id);
                return Ok(datum);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
