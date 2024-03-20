using InPay__CuriousCat_BackEnd.Context;
using InPay__CuriousCat_BackEnd.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace InPay__CuriousCat_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RealizaTransacaoPJPJController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RealizaTransacaoPJPJController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CriarTransacao([FromBody] RealizaTransacaoPJPJ transacao)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($@"
                    insert into transacoes (numerocontapj_origem, numerocontapj_destino,
                        tipotransacao, data, valor, t) 
                    values ({transacao.numerocontapj_origem}, {transacao.numerocontapj_destino},
                            {transacao.tipotransacao}, now(), {transacao.valor}, 'T')
                ");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
