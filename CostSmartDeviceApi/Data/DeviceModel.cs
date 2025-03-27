namespace CostSmartDeviceApi.Data
{
    public class DeviceModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public float Volts { get; set; }
        public float Ampers { get; set; }
        public float Watts { get; set; }
    }
}