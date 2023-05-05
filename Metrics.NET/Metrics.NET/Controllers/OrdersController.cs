using Metrics.NET.Metrics;
using Metrics.NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Metrics.NET.Controllers;

// [Route("api/[controller]")]
// [ApiController]
// public class OrdersController : ControllerBase
// {
//     private static readonly List<Order> _orders = new();
//     private static readonly List<ComputerComponent> _computerComponents = new();

//     public OrdersController()
//     {
//     }

//     [HttpPost("create-component")]
//     public IActionResult CreateComputerComponent(string name, double price)
//     {
//         var component = new ComputerComponent 
//         { 
//             Id = _computerComponents.Count + 1,
//             Name = name, 
//             Price = price 
//         };

//         _computerComponents.Add(component);

//         return Ok(component);
//     }

//     [HttpPost("create-order")]
//     public IActionResult CreateOrder([FromBody]List<int> componentIds)
//     {
//         var order = new Order
//         {
//             Id = _orders.Count + 1,
//             Items = _computerComponents.Where(c => componentIds.Contains(c.Id)).ToList()
//         };

//         _orders.Add(order);
//         return Ok(order);
//     }

//     [HttpPost("cancel-order/{orderId:int}")]
//     public IActionResult CancelOrder(int orderId)
//     {
//         var order = _orders.FirstOrDefault(o => o.Id == orderId);
//         if (order == null)
//         {
//             return NotFound($"OrderId {orderId} not found");
//         }
//         _orders.Remove(order);
//         return Ok("Order removed");
//     }

//     [HttpPost("checkout/{orderId:int}")]
//     public IActionResult Checkout(int orderId)
//     {
//         var order = _orders.FirstOrDefault(o => o.Id == orderId);
//         if (order == null)
//         {
//             return NotFound($"OrderId {orderId} not found");
//         }

//         return Ok("Order checked out");
//     }
// }