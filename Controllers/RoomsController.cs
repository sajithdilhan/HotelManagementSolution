﻿using CoreLibrary;
using CoreLibrary.Entities;
using CoreLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManagementSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly ILogger<RoomsController> _logger;
        private readonly IHotelRoomDataService _hotelRoomDataService;

        public RoomsController(ILogger<RoomsController> logger, IHotelRoomDataService hotelRoomDataService)
        {
            _logger = logger;
            _hotelRoomDataService = hotelRoomDataService;
        }

        // GET: api/<RoomsController>
        [HttpGet("/GetAllRooms")]
        public IActionResult GetAllRooms()
        {
            try
            {
                var allRooms = _hotelRoomDataService.List();
                return Ok(allRooms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("/GetAllAvailableRooms")]
        public IActionResult GetAllAvailableRooms()
        {
            try
            {
                Expression<Func<IHotelRoom, bool>> predicate = (hotelRoom => hotelRoom.Status == RoomStatusExtensions.Status_Available);
                var availableRooms = _hotelRoomDataService.List(predicate);
                if (availableRooms.Any())
                {
                    return Ok(availableRooms);
                }
                return Ok("No rooms available!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost("/AssignRoom")]
        public IActionResult AssignRoom()
        {
            try
            {
                var roomNumber = _hotelRoomDataService.AssignRoom();
                if (!string.IsNullOrEmpty(roomNumber))
                {
                    return Ok(roomNumber);
                }
                else
                {
                    return Ok("No rooms available!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("/Checkout")]
        public IActionResult Checkout(string roomNumber)
        {
            try
            {
                if (!string.IsNullOrEmpty(roomNumber))
                {
                    bool success = _hotelRoomDataService.Checkout(roomNumber);
                    if (success)
                    {
                        return Ok("Checkout Success!");
                    }
                    return BadRequest("Checkout failed!");
                }
                return BadRequest("Checkout failed!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost("/SetClean")]
        public IActionResult SetClean(string roomNumber)
        {
            try
            {
                if (!string.IsNullOrEmpty(roomNumber))
                {
                    bool success = _hotelRoomDataService.SetClean(roomNumber); ;
                    if (success)
                    {
                        return Ok("SetClean Success!");
                    }
                    return BadRequest("SetClean failed!");
                }
                return BadRequest("SetClean failed!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost("/SetOutOfService")]
        public IActionResult SetOutOfService(string roomNumber)
        {
            try
            {
                if (!string.IsNullOrEmpty(roomNumber))
                {
                    bool success = _hotelRoomDataService.SetOutOfService(roomNumber);
                    if (success)
                    {
                        return Ok("Set out of service success!");
                    }
                    return BadRequest("SetOutOfService failed!");
                }
                return BadRequest("SetOutOfService failed!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
