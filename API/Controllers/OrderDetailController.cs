using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Abstract;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly ILogger<OrderDetailController> _logger;
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(ILogger<OrderDetailController> logger, IOrderDetailService orderDetailService)
        {
            _logger = logger;
            _orderDetailService = orderDetailService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                //var token = Request.Headers["authorization"].ToString();

                //if (String.IsNullOrEmpty(token))
                //    throw new Exception("Yetkiniz alanı dışındasınız. !");

                //var users = await _userService.GetAllAsync();
                //var user = users.Where(x => x.Session == Guid.Parse(token)).FirstOrDefault();

                //if (user == null)
                //    throw new Exception("Lütfen oturum açınız !");

                var data = await _orderDetailService.GetAsync(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
