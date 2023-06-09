using System.Runtime.Serialization;

namespace Concigo_API.Model
{
    [DataContract]
    public class Reservation
    {
        public Reservation()
        {

        }
        public Reservation(int Id, DateTime date, int nombrePersonne)
        {
            this.Id = Id;
            this.date = date;
            this.nombrePersonne = nombrePersonne;
           
          

        }
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime date { get; set; }

        [DataMember]
        public int nombrePersonne { get; set; }
        [DataMember]
        public Disponibilite disponibilite { get; set; }
        [DataMember]
        public Evenement evenement { get; set; }

    }
}
