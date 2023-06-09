using Concigo_API.DataProviders;
using Concigo_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Concigo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        [HttpGet]
        [Route("api/[controller]")]
        public List<Reservation> GetReservation()
        {
            return SQLDataProviderReservation.GetReservation();
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public Reservation GetReservationById(int id)
        {
            return SQLDataProviderReservation.GetReservationById(id);
        }
        [HttpGet]
        [Route("api/[controller]/ByUser/{id}")]
        public Reservation GetReservationByIdUser(int idUser)
        {
            return SQLDataProviderReservation.GetReservationByIdUser(idUser);
        }
        [HttpPost]
        [Route("api/[controller]")]
        public bool AddReservation(Reservation reserv, int idUser)
        {
            return SQLDataProviderReservation.AddReservation(reserv, idUser);
        }

        [HttpPut]
        [Route("api/[controller]")]
        public bool UpdateReservation(Reservation reserv)
        {
            return SQLDataProviderReservation.ModifierReservation(reserv);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public bool DeleteReservation(int id)
        {
            return SQLDataProviderReservation.DeleteReservation(id);
        }
    }
}
