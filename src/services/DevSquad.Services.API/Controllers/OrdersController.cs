using DevSquad.Modules.Application.Inputs;
using DevSquad.Modules.Application.UseCases.PlaceOrder;
using Marraia.Notifications.Base;
using Marraia.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DevSquad.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        private readonly IPlaceOrderUseCase _orders;

        public OrdersController(
            INotificationHandler<DomainNotification> notification,
            IPlaceOrderUseCase order)
            : base(notification)
        {
            _orders = order;
        }

        [HttpPost]
        [Authorize("Orders")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CreateProductAsync([FromBody] PlaceOrderInput input)
        {
            var result = await _orders
                                    .Execute(input)
                                    .ConfigureAwait(false);

            return CreatedContent("", result);
        }

        [HttpGet("{id}")]
        [Authorize("Orders")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        //[ProducesResponseType(typeof(TaxIntegration), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var result = await _orders
                                    .GetOrderByIdAsync(id)
                                    .ConfigureAwait(false);

            return OkOrNotFound(result);
        }

    }
}
