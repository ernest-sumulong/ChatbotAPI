using System.ComponentModel.DataAnnotations;

namespace ChatbotAPI.Models
{
    public class Procedure
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Step { get; set; }


    }
}
