using Concigo_API.DataProviders;
using Concigo_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Concigo_API.Controllers
{
    [ApiController]

    public class EvenementController : ControllerBase
    {
        [HttpGet]
        [Route("api/[controller]")]
        public List<Evenement> GetEvenements()
        {
            return SQLDataProviderEvenement.GetEvenements();
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Evenement GetEvenementById(int id)
        {
            return SQLDataProviderEvenement.GetEvenementById(id);
        }

        [HttpGet]
        [Route("api/[controller]/GetByNom")]
        public Evenement GetEvenementByNom(string nom)
        {
            return SQLDataProviderEvenement.GetEvenementByNom(nom);
        }

        [HttpGet]
        [Route("api/[controller]/GetByPrix")]
        public List<Evenement> GetEvenementByPrix(double prix)
        {
            return SQLDataProviderEvenement.GetEvenementByPrix(prix);
        }

        [HttpGet]
        [Route("api/[controller]/GetByDescription")]
        public Evenement GetEvenementByDescription(string description)
        {
            return SQLDataProviderEvenement.GetEvenementByDescription(description);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public bool AddEvenement(Evenement evenement)
        {
            return SQLDataProviderEvenement.AddEvenement(evenement);
        }

        [HttpPut]
        [Route("api/[controller]")]
        public bool UpdateEvenement(Evenement evenement)
        {
            return SQLDataProviderEvenement.ModifierEvenement(evenement);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public bool DeleteEvenement(int id)
        {
            return SQLDataProviderEvenement.DeleteEvenement(id);
        }
    }
}
