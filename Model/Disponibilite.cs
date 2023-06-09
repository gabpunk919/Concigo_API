using System.Runtime.Serialization;

namespace Concigo_API.Model
{
    public class Disponibilite
    {
        public Disponibilite()
        {

        }
        public Disponibilite(int Id, DateTime date, bool estDispo, int  nombrePersonneMax)
        {
            this.Id = Id;
            this.date = date;
            this.estDispo = estDispo;
            this.estDispo = estDispo;
            this.nombrePersonneMax = nombrePersonneMax;
        }
      

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime date { get; set; }

        [DataMember]
        public bool estDispo { get; set; }

        [DataMember]
        public int nombrePersonneMax { get; set; }

    }
}
