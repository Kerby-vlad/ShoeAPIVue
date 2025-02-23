﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Core;
using Shop.Data.Models;
using Shop.Data.ViewModels;
using Shop.Services.Contracts;

namespace Shop.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OrderController : Controller
    {

        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }
        
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        
        [Admin]
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await _service.GetById(id));
        }

        
        [Authorize]
        [HttpGet("get-by-user")]
        public async Task<IActionResult> GetByUser(long id)
        {
            return Ok(await _service.GetByUser(id));
        }

        // [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> Add(Order order)
        {
            if (order == null)
            {
                return BadRequest("Null entity");
            }

            order.IsPaid = false;
            return Ok(await _service.Add(order));
        }

        [Authorize]
        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateStatus(short status, long id)
        {
            if (status==0)
            {
                return BadRequest("Null status");
            }

            await _service.UpdateStatus(status, id);
            return Ok();
        }

        [Authorize]
        [HttpPut("change-isPaid")]
        public async Task<IActionResult> ChangeIsPaid(bool isPaid, long id)
        {
            await _service.ChangePaidTrigger(isPaid, id);
            return Ok();
        }
    }
}