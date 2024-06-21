using SuperHeroes.Interfaces;
using SuperHeroes.Models;
using SuperHeroes.DTOs;
using SuperHeroes.Configuracao;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuperpoderController
    {
        private readonly ISuperpoder _interfaceSuperpoder;

        public SuperpoderController(ISuperpoder InterfaceSuperpoder)
        {
            _interfaceSuperpoder = InterfaceSuperpoder;
        }

        [HttpGet]
        public async Task<object> ListaSuperpoderes()
        {
            return await _interfaceSuperpoder.ListarSuperpoderes();

        }

    }
}
