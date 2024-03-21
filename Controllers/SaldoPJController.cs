using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System;
using InPay__CuriousCat_BackEnd.Domain;
using InPay__CuriousCat_BackEnd.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http.HttpResults;

namespace InPay__CuriousCat_BackEnd.Controllers
{
    [ApiController]
    [Route("conta")]
    public class SaldoPJController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SaldoPJController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{jwt}")]
        public async Task<ActionResult<decimal>> GetSaldo(string conta)
        {
            // Inicia a transação
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                int numeroConta = int.Parse(conta);
                // Executa o UPDATE
                var updateSql = $@"
            UPDATE contas_pessoas_juridicas AS cpf 
            SET saldo = (
                SELECT SUM( 
                    CASE
                        WHEN t.t = 'R' THEN t.valor
                        WHEN t.t = 'P' THEN t.valor * -1
                        WHEN t.t = 'T' AND {numeroConta} = COALESCE(t.numerocontapf_origem, t.numerocontapj_origem) THEN t.valor * -1
                        WHEN t.t = 'T' AND {numeroConta} = COALESCE(t.numerocontapf_destino, t.numerocontapj_destino) THEN t.valor
                        ELSE 0 
                    END 
                )
                FROM transacoes AS t
                WHERE cpf.numero_conta = {numeroConta}
                AND (t.numerocontapf_origem = {numeroConta} OR t.numerocontapj_origem = {numeroConta} OR t.numerocontapj_destino = {numeroConta} OR t.numerocontapf_destino = {numeroConta})
            ) 
            WHERE cpf.numero_conta = {numeroConta};
        ";

                await _context.Database.ExecuteSqlRawAsync(updateSql);

                // Executa o SELECT
                var saldo = await _context.contas_pessoas_juridica
                    .FromSqlRaw($"SELECT numero_conta, coalesce(CAST(saldo AS numeric),0) as saldo FROM contas_pessoas_juridicas AS cpf WHERE cpf.numero_conta = {numeroConta}")
                    .FirstOrDefaultAsync();

                // Commit da transação
                await transaction.CommitAsync();

                if (saldo != null)
                {
                    return Ok(saldo);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                // Em caso de erro, faz rollback da transação
                await transaction.RollbackAsync();
                throw;
            }
        }

    }

}


return Created()