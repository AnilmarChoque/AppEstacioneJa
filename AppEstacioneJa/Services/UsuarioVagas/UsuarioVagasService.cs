using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEstacioneJa.Models;

namespace AppEstacioneJa.Services.UsuarioVagas
{
    public class UsuarioVagasService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://estacioneja.somee.com/EstacioneJa/UsuarioVaga";
        private string _token;

        public UsuarioVagasService(string token)
        {
            _request = new Request();
            _token = token;
        }

        public async Task<List<UsuarioVaga>> GetVagasAsync(int vagaId)
        {
            string urlComplementar = string.Format("/Vaga/{0}", vagaId);
            var vagas = await _request.GetAsync<List<UsuarioVaga>>(apiUrlBase + urlComplementar, _token);
            return vagas;
        }

        public async Task<int> ContarVagas1Async()
        {
            var Vagas = await GetVagasAsync(1);
            int contagem = Vagas.Count;
            return contagem;
        }

        public async Task<int> ContarVagas2Async()
        {
            var Vagas = await GetVagasAsync(2);
            int contagem = Vagas.Count;
            return contagem;
        }

        public async Task<int> ContarVagas3Async()
        {
            var Vagas = await GetVagasAsync(3);
            int contagem = Vagas.Count;
            return contagem;
        }

        public async Task<int> ContarVagas4Async()
        {
            var Vagas = await GetVagasAsync(4);
            int contagem = Vagas.Count;
            return contagem;
        }
    }
}
