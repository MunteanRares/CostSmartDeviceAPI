using System.Net;
using CostSmartDeviceApi.Data;
using CostSmartDeviceApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CostSmartDeviceApi.Services
{
    public class DevicesService : IDevicesService
    {
        private readonly AppDbContext _context;
        private readonly float _costPerKwhEurope = 0.30f;

        public DevicesService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DeviceModel> GetAllDevices()
        {
            return _context.Devices.ToList();
        }

        public DeviceModel GetDevice(int id)
        {
            return _context.Devices.Find(id);
        }

        public PowerExpenseModel GetPowerExpense(int id)
        {
            DeviceModel? device = _context.Devices.Find(id);
            if (device == null)
            {
                return new PowerExpenseModel { CostPerDay = 0, CostPerWeek = 0, CostPerMonth = 0, CostPerYear = 0 };
            }

            float costPerDay = device.Watts * 24 / 1000 * _costPerKwhEurope;
            float costPerWeek = device.Watts * 24 * 7 / 1000 * _costPerKwhEurope;
            float costPerMonth = device.Watts * 24 * 30 / 1000 * _costPerKwhEurope;
            float costPerYear = device.Watts * 24 * 365 / 1000 * _costPerKwhEurope;

            return new PowerExpenseModel { CostPerDay = costPerDay, CostPerWeek = costPerWeek, CostPerMonth = costPerMonth, CostPerYear = costPerYear };
        }

        public void PostDevice(DeviceModel device)
        {
            _context.Devices.Add(device);
            _context.SaveChanges();
        }
    }
}
