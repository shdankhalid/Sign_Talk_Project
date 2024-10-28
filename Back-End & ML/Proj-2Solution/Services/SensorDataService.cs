using Entities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;

namespace Services
{
    public class SensorDataService : ISensorDataService
    {
        private readonly DataContext _context;

        public SensorDataService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SignClassification>> GetSensorsDataAsync()
        {
            return await _context.SignClassifications.ToListAsync();
        }

        public async Task<Sensor_Data> GetSensorDataAsync(int id)
        {
            return await _context.Sensors_data.FindAsync(id);
        }

        public async Task<bool> UpdateSensorDataAsync(int id, Sensor_Data sensorData)
        {
            if (id != sensorData.DataId)
            {
                return false;
            }

            _context.Entry(sensorData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorDataExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<SignClassification> AddSensorDataAsync(Sensor_Data sensorData)
        {
            _context.Sensors_data.Add(sensorData);
            await _context.SaveChangesAsync();

            int modeId = sensorData.ModeId;

            var sampleData = new WordDetector.ModelInput()
            {
                Sensor1 = sensorData.Sensor1_Value,
                Sensor2 = sensorData.Sensor2_Value,
                Sensor3 = sensorData.Sensor3_Value,
                Sensor4 = sensorData.Sensor4_Value,
                Sensor5 = sensorData.Sensor5_Value,
            };

            var result = WordDetector.Predict(sampleData);

            var signClassification = new SignClassification
            {
                Word = result.PredictedLabel,
                TimeStamp = DateTime.Now,
                SensorDataID = sensorData.DataId,
            };
            _context.SignClassifications.Add(signClassification);
            await _context.SaveChangesAsync();

            var symbol = result.PredictedLabel;
            var propertyInfo = typeof(Mode).GetProperty(symbol);
            if (propertyInfo != null)
            {
                var modeWord = _context.Modes
                                .Where(m => m.ModeId == modeId)
                                .Select(m => propertyInfo.GetValue(m, null))
                                .FirstOrDefault();
                signClassification.Word = modeWord?.ToString();
            }
            else
            {
                signClassification.Word = $"Symbol '{symbol}' property does not exist in the Modes table.";
            }

            return signClassification;
        }

        public async Task<bool> DeleteSensorDataAsync(int id)
        {
            var sensorData = await _context.Sensors_data.FindAsync(id);
            if (sensorData == null)
            {
                return false;
            }

            _context.Sensors_data.Remove(sensorData);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool SensorDataExists(int id)
        {
            return _context.Sensors_data.Any(e => e.DataId == id);
        }
    }
}
