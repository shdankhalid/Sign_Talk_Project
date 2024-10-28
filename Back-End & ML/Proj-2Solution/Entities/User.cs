using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public User()
        {
            SmartGloves = new List<SmartGlove>();
            SensorData = new List<Sensor_Data>();
        }

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool Gender { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

        // Add additional properties as needed
        public ICollection<SmartGlove> SmartGloves { get; set; }
        public ICollection<Sensor_Data> SensorData { get; set; }
    }
}
