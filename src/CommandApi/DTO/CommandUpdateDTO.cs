using System.ComponentModel.DataAnnotations;

namespace CommandApi.DTO
{
    public class CommandUpdateDTO
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Platform { get; set; }

        [Required]
        public string CommandLine { get; set; }

    }

}