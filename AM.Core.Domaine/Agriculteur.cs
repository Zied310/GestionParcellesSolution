using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domaine
{
    public class Agriculteur
    {
        [Key]
        public string CIN { get; set; }
        
        public string Password { get; set; }
               
        public string PrenomNom { get; set; }

        [Required]
        [Phone]
        public string Telephone { get; set; }

        public string Email { get; set; }

        public DateTime DateNaissance { get; set; }

        public virtual ICollection<Agriculture> Agricultures { get; set; }
    }
}
