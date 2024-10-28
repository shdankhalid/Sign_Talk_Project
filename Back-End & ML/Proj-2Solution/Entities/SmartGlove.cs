using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities
{
    public class SmartGlove
    {
        [Key]
        public int Id { get; set; }
        public float Version { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }

        public int OwnerID { get; set; }
        [ForeignKey("OwnerID")] // Renamed from UserID to OwnerID
        [JsonIgnore]
        public User? Owner { get; set; }
    }
}
