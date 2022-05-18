using API.Models.Order;
using DATA.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICES.Abstract;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService, IOrderDetailService orderDetailService, IUserService userService, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var token = Request.Headers["authorization"].ToString();

                if (String.IsNullOrEmpty(token))
                    throw new Exception("Yetkiniz alanı dışındasınız. !");

                var users = await _userService.GetAllAsync();
                var user = users.Where(x => x.Session == Guid.Parse(token)).FirstOrDefault();

                if (user == null)
                    throw new Exception("Lütfen oturum açınız !");

                var data = await _orderService.GetAllAsync(user.Id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var token = Request.Headers["authorization"].ToString();

                if (String.IsNullOrEmpty(token))
                    throw new Exception("Yetkiniz alanı dışındasınız. !");

                var users = await _userService.GetAllAsync();
                var user = users.Where(x => x.Session == Guid.Parse(token)).FirstOrDefault();

                if (user == null)
                    throw new Exception("Lütfen oturum açınız !");

                var datum = await _orderService.GetAsync(user.Id, id);
                return Ok(datum);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Order([FromBody] Order order)
        {
            try
            {
                var token = Request.Headers["authorization"].ToString();

                if (String.IsNullOrEmpty(token))
                    throw new Exception("Yetkiniz alanı dışındasınız. !");

                var users = await _userService.GetAllAsync();
                var user = users.Where(x => x.Session == Guid.Parse(token)).FirstOrDefault();

                if (user == null)
                    throw new Exception("Lütfen oturum açınız !");

                if (order == null)
                    throw new Exception("Siparişiniz oluşturulurken hata oluştu !");

                Guid guid = Guid.NewGuid();

                ENTITIES.Concrete.Order o = new ENTITIES.Concrete.Order()
                {
                    Id = guid,
                    Description = order.Description,
                    Date = order.Date < new DateTime(1903,3, 19) ? DateTime.Now : order.Date,
                    UserId = user.Id
                };

                List<ENTITIES.Concrete.OrderDetail> odlist = new List<ENTITIES.Concrete.OrderDetail>();

                foreach (var item in order.OrderDetails)
                {
                    odlist.Add(new ENTITIES.Concrete.OrderDetail()
                    {
                        OrderId = guid,
                        Piece = item.Piece,
                        ProductId = item.ProductId
                    });
                }


                bool orderAdded = await _orderService.AddAsync(o);
                bool orderDetailAdded = await _orderDetailService.AddRangeAsync(odlist);

                if (orderDetailAdded && orderAdded)
                    await _unitOfWork.SaveAsync();
                else
                    throw new Exception("Sipari alınırken hata oluştu !");

                return Ok("Siparinişiniz başarıyla alındı");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}