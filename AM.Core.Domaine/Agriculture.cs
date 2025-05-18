using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domaine
{
    public class Agriculture
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime DatePlantation { get; set; }

        public DateTime DateRecolte { get; set; }

        public double PrixLocationParcelle { get; set; }

        // Relations
        public string AgriculteurCIN { get; set; }        
        public virtual Agriculteur Agriculteur { get; set; }

        public string ParcelleRef { get; set; }
        public virtual Parcelle Parcelle { get; set; }
    }
}
