using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PgsBoard.Dtos
{
    public class CreateBoardDto
    {
        [DisplayName("Nazwa")]
        [Required]
        public string Name { get; set; }
        [DisplayName("Opis")]
        [Required]
        public string Description { get; set; }
    }
}