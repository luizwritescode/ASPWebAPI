using Microsoft.AspNetCore.Mvc;

using MODEL;
using BLL;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        
        [HttpGet(Name = "GetCliente")]
        public ActionResult<List<Cliente>> GetCliente()
        {
            try
            {
                List<Cliente> clientes = ClienteRepository.GetAll();

                if (clientes != null)
                    return Ok(clientes);

                return NotFound();
            }
            catch( Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

       
        

       
    }

}
