using CoreLibrary.Entities;
using CoreLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
        public IEnumerable<IHotelRoom> GetAllRooms()
        {
            return _hotelRoomDataService.List();
        }

        [HttpGet("/GetAllAvailableRooms")]
        public IEnumerable<IHotelRoom> GetAllAvailableRooms()
        {
            Expression<Func<IHotelRoom, bool>> predicate = (hotelRoom => hotelRoom.Status == CoreLibrary.RoomStatus.Available);
            return _hotelRoomDataService.List(predicate);
        }

        [HttpPost("/AssignRoom")]
        public string AssignRoom()
        {
            return _hotelRoomDataService.AssignRoom();
        }

        [HttpPost("/Checkout")]
        public IActionResult Checkout(string roomNumber)
        {
            IActionResult result = null;
            if (!string.IsNullOrEmpty(roomNumber))
            {
               bool success = _hotelRoomDataService.Checkout(roomNumber);
                if (success)
                {
                    return Ok(result);
                }
                return BadRequest("Checkout failed!");
            }
            return BadRequest("Checkout failed!");
        }

        [HttpPost("/SetClean")]
        public IActionResult SetClean(string roomNumber)
        {
            IActionResult result = null;
            if (!string.IsNullOrEmpty(roomNumber))
            {
                bool success = _hotelRoomDataService.SetClean(roomNumber); ;
                if (success)
                {
                    return Ok(result);
                }
                return BadRequest("SetClean failed!");
            }
            return BadRequest("SetClean failed!");
        }

        [HttpPost("/SetOutOfService")]
        public IActionResult SetOutOfService(string roomNumber)
        {
            IActionResult result = null;
            if (!string.IsNullOrEmpty(roomNumber))
            {
                bool success = _hotelRoomDataService.SetOutOfService(roomNumber);
                if (success)
                {
                    return Ok(result);
                }
                return BadRequest("SetOutOfService failed!");
            }
            return BadRequest("SetOutOfService failed!");
        }
    }
}
