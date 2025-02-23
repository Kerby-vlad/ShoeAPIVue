﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Core;
using Shop.Data.Models;
using Shop.Services.Contracts;

namespace Shop.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StoreController: Controller
    {
        private readonly IStoreService _service;

        public StoreController(IStoreService service)
        {
            _service = service;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById(long id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpGet("get-by-good")]
        public async Task<IActionResult> GetByGood(long goodId)
        {
            return Ok(await _service.GetByAvailableGood(goodId));
        }

        [Admin]
        [HttpPost("add")]
        public async Task<IActionResult> Add(Store store)
        {
            if (store == null)
            {
                return BadRequest("Null entity");
            }

            return Ok(await _service.Add(store));
        }


        [Admin]
        [HttpPut("update")]
        public async Task<IActionResult> Update(Store store)
        {
            if (store == null)
            {
                return BadRequest("Null entity");
            }

            await _service.Update(store);
            return Ok();
        }

        [Admin]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.Delete(id);
            return Ok();
        }
        
    }
}