using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Mode
    {
        [Key]
        public int ModeId { get; set; }
        public string? ModeName { get; set; }
        public string? A { get; set; } = "Waiting...";
        public string? B { get; set; } = "Waiting...";
        public string? C { get; set; } = "Waiting...";
        public string? D { get; set; } = "Waiting...";
        public string? E { get; set; } = "Waiting...";
        public string? F { get; set; } = "Waiting...";
        public string? G { get; set; } = "Waiting...";
        public string? H { get; set; } = "Waiting...";
        public string? I { get; set; } = "Waiting...";
        public string? J { get; set; } = "Waiting...";
        public string? K { get; set; } = "Waiting...";
        public string? L { get; set; } = "Waiting...";
        public string? M { get; set; } = "Waiting...";
        public string? N { get; set; } = "Waiting...";
    }
}
