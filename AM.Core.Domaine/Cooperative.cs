using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domaine
{
    public class Cooperative
    {
        [Key]
        [StringLength(10, MinimumLength = 3)]
        public string Reference { get; set; }

        public string Password { get; set; }

        [Required]
        [Phone]
        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }


        public ICollection<Parcelle> Parcelles { get; set; }



    }
}
