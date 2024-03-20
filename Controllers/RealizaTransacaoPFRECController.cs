﻿using Microsoft.AspNetCore.Mvc;
using InPay__CuriousCat_BackEnd.Domain;
using InPay__CuriousCat_BackEnd.Context;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace InPay__CuriousCat_BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RealizaTransacaoPFRECController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RealizaTransacaoPFRECController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CriarTransacao([FromBody] RealizaTransacaoPFREC transacao)
        {
            try
            {
                await _context.Database.ExecuteSqlInterpolatedAsync($@"
                    insert into transacoes (numerocontapf_origem, tipotransacao, data, valor, t) 
                    values ({transacao.numerocontapf_origem}, {transacao.tipotransacao}, now(), {transacao.valor}, 'R')
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