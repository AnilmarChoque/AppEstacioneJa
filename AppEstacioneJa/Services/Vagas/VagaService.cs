using AppEstacioneJa.Models;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstacioneJa.Services.Vagas
{
    public class VagaService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://estacioneja.somee.com/EstacioneJa/Vagas";

        private string _token;

        public VagaService(string token)
        {
            _request = new Request();
            _token = token;
        }

        public async Task<int> PostVagaAsync(Vaga v)
        {
            return await _request.PostReturnIntTokenAsync(apiUrlBase, v, _token);
        }

        public async Task<ObservableCollection<Vaga>> GetVagaAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Vaga> listaVagas = await
            _request.GetAsync<ObservableCollection<Models.Vaga>>(apiUrlBase + urlComplementar,
            _token);
            return listaVagas;
        }
        public async Task<Vaga> GetVagaAsync(int vagaId)
        {
            string urlComplementar = string.Format("/{0}", vagaId);
            var vaga = await _request.GetAsync<Models.Vaga>(apiUrlBase +
            urlComplementar, _token);
            return vaga;
        }
        public async Task<int> PutVagaAsync(Vaga v)
        {
            var result = await _request.PutAsync(apiUrlBase, v, _token);
            return result;
        }
        public async Task<int> DeleteVagaAsync(int vagaId)
        {
            string urlComplementar = string.Format("/{0}", vagaId);
            var result = await _request.DeleteAsync(apiUrlBase + urlComplementar, _token);
            return result;
        }
    }
}
