using System.Runtime.Serialization;

namespace Concigo_API.Model
{
    [DataContract]
    public class User
    {
        public User()
        {

        }
        public User(int Id, string nom, string prenom, string telephone, string email,string mdp)
        {
            this.Id = Id;
            this.nom = nom;
            this.prenom = prenom;
            this.telephone = telephone;
            this.email = email;
            this.mdp = mdp;
       
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
        [DataMember]
        public string mdp { get; set; }
        [DataMember]
        public Reservation reservation { get; set; }

    }
}
