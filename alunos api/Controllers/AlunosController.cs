using alunos_api.Models;
using alunos_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alunos_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]

        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        { 
        
        try
        {
           var alunos = await _alunoService.GetAlunos();
           return Ok(alunos);
        }
        catch     
        {
                //return BadRequest("Request Invalida");
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Alunos");
        }


        }


    }   
}