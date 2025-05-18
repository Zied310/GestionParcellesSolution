using System.ComponentModel.DataAnnotations;

namespace AM.Core.Domaine
{
    public class Parcelle
    {
        [Key]
        [StringLength(10, MinimumLength = 3)]
        public string Reference { get; set; }
        
        public double Superficie { get; set; }
        
        public string Localisation { get; set; }

        public TypeSol Sol { get; set; }

        //Foreign key to Cooperative
        public string CooperativeReference { get; set; }
        public virtual Cooperative Cooperative { get; set; }

        public virtual ICollection<Agriculture> Agricultures { get; set; }


    }
}
