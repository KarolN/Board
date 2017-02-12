using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PgsBoard.Data.Entities
{
    public class List : IEntity<long>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        public Board Board { get; set; }

        public long BoardId { get; set; }

        public ICollection<Cart> Carts { get; set; }
    }
}