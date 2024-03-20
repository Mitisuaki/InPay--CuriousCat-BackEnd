using InPay__CuriousCat_BackEnd.Context;
using InPay__CuriousCat_BackEnd.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace InPay__CuriousCat_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RealizaTransacaoPFPJController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RealizaTransacaoPFPJController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CriarTransacao([FromBody] RealizaTransacaoPFPJ transacao)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($@"
                    insert into transacoes (numerocontapf_origem, numerocontapj_destino,
                        tipotransacao, data, valor, t) 
                    values ({transacao.numerocontapf_origem}, {transacao.numerocontapj_destino},
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
