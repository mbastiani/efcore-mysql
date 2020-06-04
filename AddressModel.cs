using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efcore_mysql
{
    [Table("Addresses")]
    public class AddressModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Cep { get; set; }
        public string Street { get; set; }
        public long PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual PersonModel Person { get; set; }
    }
}