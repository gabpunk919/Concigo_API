using Concigo_API.DataProviders;
using Concigo_API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Concigo_API.Controllers
{
  
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]

        [Route("api/[controller]/GetUser")]
        public List<User> Get()
        {
            return SQLDataProviderUser.GetUsers();
        }
        [HttpGet]

        [Route("api/[controller]/GetUserByEmailAndMdp")]
        public User Get(string email,string mdp)
        {
            return SQLDataProviderUser.GetUserByEmailAndMdp(email,mdp);
        }
        [HttpGet]
        [Route("api/[controller]/GetByID")]
        public User GetByID(int id)
        {
            return SQLDataProviderUser.GetUserById(id);
        }
        [HttpGet]
        [Route("api/[controller]/GetByNom")]
        public List<User> GetByNom(string nom)
        {
            return SQLDataProviderUser.GetUsersByNom(nom);

        }
        [HttpGet]
        [Route("api/[controller]/GetByPrenom")]

        public List<User> GetByPrenom(string prenom)
        {
            return SQLDataProviderUser.GetUsersByPrenom(prenom);
        }
        [HttpGet]
        [Route("api/[controller]/GetByEmail")]

        public List<User> GetByEmail(string email)
        {
            return SQLDataProviderUser.GetUserByEmail(email);

        }
        [HttpGet]
        [Route("api/[controller]/GetByTelephone")]

        public List<User> GetByTelephone(string telephone)
        {
            return SQLDataProviderUser.GetUserByTelephone(telephone);
        }
        [HttpGet]
        [Route("api/[controller]/GetByMdp")]

        public List<User> GetByMdp(string mdp)
        {
            return SQLDataProviderUser.GetUserByMdp(mdp);

        }
        [HttpPost]
        [Route("api/[controller]")]
        public bool Post(User user)
        {
            return SQLDataProviderUser.AddUser(user);
        }
        [HttpPut]
        [Route("api/[controller]")]
        public bool Put(User user)
        {
            return SQLDataProviderUser.UpdateUser(user);
        }
        [HttpDelete]
        [Route("api/[controller]")]
        public bool Delete(int id)
        {
            return SQLDataProviderUser.DeleteUser(id);
        }
    }
}
