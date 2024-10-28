using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Entities
{
    public class Sensor_Data
    {
        public Sensor_Data()
        {
            TimeStamp = DateTime.Now; // Initialize TimeStamp with the current date and time
            /*            user=new User();
            */
        }

        [Key]
        public int DataId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Sensor1_Value { get; set; }
        public int Sensor2_Value { get; set; }
        public int Sensor3_Value { get; set; }
        public int Sensor4_Value { get; set; }
        public int Sensor5_Value { get; set; }

        // Change UserID to nullable
        [Required(ErrorMessage = "Please, Enter the User id.")]
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        [JsonIgnore] // Ignore during JSON serialization to prevent cyclic references
        public User? user { get; set; }

        public SignClassification? SignClassification { get; set; }

        // Foreign key property for Mode
        [Required(ErrorMessage = "Please, select a mode.")]
        public int ModeId { get; set; }

        [ForeignKey("ModeId")]
        public Mode? Mode { get; set; }

        public static class JsonSerializationSettings
        {
            public static readonly JsonSerializerOptions Options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
        }
    }
}
