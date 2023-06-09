using Concigo_API.DataProviders;
using Concigo_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Concigo_API.Controllers
{
    
    [ApiController]
    public class PartenaireController : ControllerBase
    {
        [HttpGet]
       
        [Route("api/[controller]/GetPartenaire")]
        public List<Partenaire> Get()
        {
            return SQLDataProviderPartenaire.GetPartenaire();
        }
        [HttpGet]
        [Route("api/[controller]/GetByID")]
        public Partenaire GetByID(int id)
        {
            return SQLDataProviderPartenaire.GetPartenaireById(id);
        }
        [HttpGet]
        [Route("api/[controller]/GetByNom")]
        public List<Partenaire> GetByNom(string nom)
        {
            return SQLDataProviderPartenaire.GetPartenaireByNom(nom);

        }
        [HttpGet]
        [Route("api/[controller]/GetByPrenom")]

        public List<Partenaire> GetByPrenom(string prenom)
        {
            return SQLDataProviderPartenaire.GetPartenaireByPrenom(prenom);
        }
        [HttpGet]
        [Route("api/[controller]/GetByEmail")]

        public List<Partenaire> GetByEmail(string email)
        {
            return SQLDataProviderPartenaire.GetPartenaireByEmail(email);

        }
        [HttpGet]
        [Route("api/[controller]/GetByTelephone")]

        public List<Partenaire> GetByTelephone(string telephone)
        {
            return SQLDataProviderPartenaire.GetPartenaireByTelephone(telephone);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public bool Post(Partenaire partenaire)
        {
            return SQLDataProviderPartenaire.AddPartenaire(partenaire);
        }
        [HttpPut]
        [Route("api/[controller]")]
        public bool Put(Partenaire partenaire)
        {
            return SQLDataProviderPartenaire.ModifierPartenaire(partenaire);
        }
        [HttpDelete]
        [Route("api/[controller]")]
        public bool Delete(int id)
        {
            return SQLDataProviderPartenaire.DeletePartenaire(id);
        }
    }
}
