using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        //POST: api/produto/create
        [HttpPost]
        [Route("create")]
        public Produto Create(Produto produto)
        {
            produto.Nome += " alterado";
            return produto;
        }
    }
}