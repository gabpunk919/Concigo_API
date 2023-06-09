using System.Runtime.Serialization;

namespace Concigo_API.Model
{
    [DataContract]
    public class PhotoLink
    {
        public PhotoLink()
        {

        }
        public PhotoLink(int Id, string link)
        {
            this.Id = Id;
            this.link = link;

        }
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string link { get; set; }

    }
}
