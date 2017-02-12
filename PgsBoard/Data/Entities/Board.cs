using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PgsBoard.Data.Entities
{
    public class Board : IEntity<long>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ApplicationUser Owner { get; set; }

        public string OwnerId { get; set; }

        public ICollection<List> Lists { get; set; }
    }
}