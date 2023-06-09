using System.Runtime.Serialization;

namespace Concigo_API.Model
{
    [DataContract]
    public class Evenement
    {
        public Evenement()
        {

        }
        public Evenement(int Id, string Nom, string Description, double Prix, string TypeEvenement)
        {
            this.Id = Id;
            this.Nom = Nom; 
            this.Description = Description; 
            this.Prix = Prix;   
            this.TypeEvenement = TypeEvenement;
        }
        [DataMember]
        public List<PhotoLink> photos { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public double Prix { get; set; }

        [DataMember]
        public string TypeEvenement { get; set; }

      
    }
}
