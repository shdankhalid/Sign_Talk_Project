using Entities;

namespace ServiceContracts
{
    public interface ISensorDataService
    {
        Task<IEnumerable<SignClassification>> GetSensorsDataAsync();
        Task<Sensor_Data> GetSensorDataAsync(int id);
        Task<bool> UpdateSensorDataAsync(int id, Sensor_Data sensorData);
        Task<SignClassification> AddSensorDataAsync(Sensor_Data sensorData);
        Task<bool> DeleteSensorDataAsync(int id);
        bool SensorDataExists(int id);
    }
}
