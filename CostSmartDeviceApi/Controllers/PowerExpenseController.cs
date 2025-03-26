using CostSmartDeviceApi.Data;
using CostSmartDeviceApi.Models;
using CostSmartDeviceApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CostSmartDeviceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerExpenseController : ControllerBase
    {
        private readonly IDevicesService _service;

        public PowerExpenseController(IDevicesService service)
        {
            _service = service;
        }

        [HttpGet("GetPowerExpense/{id}")]
        public PowerExpenseModel GetPowerExpense(int id)
        {
            return _service.GetPowerExpense(id);
        }

        [HttpGet("GetAllDevices")] 
        public IEnumerable<DeviceModel> GetAllDevices()
        {
            return _service.GetAllDevices();
        }

        [HttpGet("GetDevice/{id}")]
        public DeviceModel GetDevice(int id)
        {
            return _service.GetDevice(id);
        }

        [HttpPost("PostDevice")]
        public void PostDevice(DeviceModel device)
        {
            _service.PostDevice(device);
        }
    }
}
