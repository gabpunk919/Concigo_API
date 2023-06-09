using System.Runtime.Serialization;

namespace Concigo_API.Model
{
    [DataContract]
    public class Partenaire
    {
        public Partenaire()
        {

        }
        public Partenaire(int Id, string nom,string prenom,string telephone, string email)
        {
            this.Id = Id;
            this.nom = nom;
            this.prenom = prenom;
            this.telephone = telephone;
            this.email = email;
             
        }
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string nom { get; set; }

        [DataMember]
        public string prenom { get; set; }
        [DataMember]
        public string telephone { get; set; }
        [DataMember]
        public string email { get; set; }


    }
}
