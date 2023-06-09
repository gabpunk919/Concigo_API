using Concigo_API.DataProviders;
using Concigo_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Concigo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoLinkController : ControllerBase
    {
        [HttpGet(Name = "GetPhotoLink")]
        public List<PhotoLink> Get(int id)
        {
            return SQLDataProviderPhotoLink.GetPhotoLink(id);
        }
        [HttpPost(Name = "PostPhotoLink")]
        public bool Post(PhotoLink photoLink, int id_evenement)
        {
            return SQLDataProviderPhotoLink.AddPhotoLink( photoLink,  id_evenement);
        }
        [HttpPut(Name = "PutPhotoLink")]
        public bool Put(PhotoLink photoLink)
        {
            return SQLDataProviderPhotoLink.ModifierPhotoLink(photoLink);
        }
        [HttpDelete(Name = "DelPhotoLink")]
        public bool Delete(int id)
        {
            return SQLDataProviderPhotoLink.DeletePhotoLink(id);
        }
    }
}
