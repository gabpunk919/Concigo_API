using Concigo_API.DataProviders;
using Concigo_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Concigo_API.Controllers
{
    [ApiController]
    public class DisponibiliteController : ControllerBase
    {
        [HttpGet]
        [Route("api/[controller]")]
        public List<Disponibilite> GetDisponibilites()
        {
            return SQLDataProviderDisponibilite.GetDisponibilites();
        }
        [HttpGet]
        [Route("api/[controller]/idEvenement")]
        public List<Disponibilite> GetDisponibilitesIdEvenement(int idEvenement)
        {
            return SQLDataProviderDisponibilite.GetDisponibilitesByIdEvenement(idEvenement);
        }
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Disponibilite GetDisponibiliteById(int id)
        {
            return SQLDataProviderDisponibilite.GetDisponibiliteById(id);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public bool AddDisponibilite(Disponibilite disponibilite, int idEvenement)
        {
            return SQLDataProviderDisponibilite.AddDisponibilite(disponibilite, idEvenement);
        }

        [HttpPut]
        [Route("api/[controller]")]
        public bool UpdateDisponibilite(Disponibilite disponibilite)
        {
            return SQLDataProviderDisponibilite.ModifierDisponibilite(disponibilite);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public bool DeleteDisponibilite(int id)
        {
            return SQLDataProviderDisponibilite.DeleteDisponibilite(id);
        }
    }
}