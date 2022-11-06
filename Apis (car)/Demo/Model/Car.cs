using Demo.Valditions;
using System.ComponentModel.DataAnnotations;

namespace Demo.Model
{
    public class Car
    {
        [Range(0,20,ErrorMessage ="Not in the Range")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";

        [TimeValid]
        public DateTime OpenData { get; set; }

        [Required]
        [RegularExpression("^(Elctric|Gaz|Disel|Hybrid)$")]
        public string Type { get; set; } = "";
    }
}
