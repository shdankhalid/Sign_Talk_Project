using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace Proj_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sensor_DataController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ISensorDataService _sensorDataService;

        public Sensor_DataController(ISensorDataService sensorDataService, DataContext context)
        {
            _sensorDataService = sensorDataService;
            _context = context;
        }

        // GET: api/Sensor_Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SignClassification>>> GetSensors_data()
        {
            var result = await _sensorDataService.GetSensorsDataAsync();
            return Ok(result);
        }

        // GET: api/Sensor_Data/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor_Data>> GetSensor_Data(int id)
        {
            var result = await _sensorDataService.GetSensorDataAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // PUT: api/Sensor_Data/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensor_Data(int id, Sensor_Data sensor_Data)
        {
            var result = await _sensorDataService.UpdateSensorDataAsync(id, sensor_Data);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // POST: api/Sensor_Data
        [HttpPost]
        public async Task<ActionResult<SignClassification>> PostSensor_Data(Sensor_Data sensor_Data)
        {
            if (_context.Sensors_data == null)
            {
                return Problem("Entity set 'DataContext.Sensors_data'  is null.");
            }
            _context.Sensors_data.Add(sensor_Data);
            await _context.SaveChangesAsync();


            int modeId = sensor_Data.ModeId;


            //Load sample data
            var sampleData = new WordDetector.ModelInput()
            {
                Sensor1 = sensor_Data.Sensor1_Value,
                Sensor2 = sensor_Data.Sensor2_Value,
                Sensor3 = sensor_Data.Sensor3_Value,
                Sensor4 = sensor_Data.Sensor4_Value,
                Sensor5 = sensor_Data.Sensor5_Value,

            };
            //Load sample data
            /*var sampleData = new WordDetector.ModelInput()
            {
                Sensor1 = 50F,
                Sensor2 = 60F,
                Sensor3 = 65F,
                Sensor4 = 50F,
                Sensor5 = 50F,
            };

            //Load model and predict output
            var result = WordDetector.Predict(sampleData);*/


            //Load model and predict output
            var result = WordDetector.Predict(sampleData);

            var signClassification = new SignClassification
            {
                Word = result.PredictedLabel,
                TimeStamp = DateTime.Now,
                SensorDataID = sensor_Data.DataId,
            };
            _context.SignClassifications.Add(signClassification);
            await _context.SaveChangesAsync();

            /* return CreatedAtAction("GetSensor_Data", new { id = sensor_Data.DataId }, sensor_Data);*/
            /*return CreatedAtAction("GetSensor_Data", new { id = sensor_Data.DataId }, result.PredictedLabel);*/

            var symbol = result.PredictedLabel;
            var propertyInfo = typeof(Mode).GetProperty(symbol);
            if (propertyInfo != null)
            {

                var modeWord = _context.Modes
                                .Where(m => m.ModeId == modeId)
                                .Select(m => propertyInfo.GetValue(m, null))
                                .FirstOrDefault();
                return CreatedAtAction("GetSensor_Data", new { id = sensor_Data.DataId }, modeWord);

            }
            else
                return Problem($"Symbol '{symbol}' property does not exist in the Modes table.");
        }

        // DELETE: api/Sensor_Data/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensor_Data(int id)
        {
            var result = await _sensorDataService.DeleteSensorDataAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
