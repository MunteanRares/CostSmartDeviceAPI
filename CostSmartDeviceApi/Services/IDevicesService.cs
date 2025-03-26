using CostSmartDeviceApi.Data;
using CostSmartDeviceApi.Models;

namespace CostSmartDeviceApi.Services
{
    public interface IDevicesService
    {
        IEnumerable<DeviceModel> GetAllDevices();
        DeviceModel GetDevice(int id);
        PowerExpenseModel GetPowerExpense(int id);
        void PostDevice(DeviceModel device);
    }
}