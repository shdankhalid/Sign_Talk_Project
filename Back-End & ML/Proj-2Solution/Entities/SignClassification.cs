using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class SignClassification
    {
        [Key]
        public int Id { get; set; }
        public string? Word { get; set; }
        public DateTime TimeStamp { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SensorDataID { get; set; } // Renamed from DataID to SensorDataID


        // Renamed from DataID to SensorDataID
        [JsonIgnore]
        public Sensor_Data? SensorData { get; set; }
    }
}
