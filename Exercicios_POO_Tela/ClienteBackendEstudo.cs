using System.Text;
using System.Text.Json;

namespace Exercicios_POO_Tela
{
    public class ClienteBackendEstudo
    {
        private static readonly HttpClient _http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5080"),
            Timeout = TimeSpan.FromSeconds(10)
        };

        private static readonly JsonSerializerOptions _opcoes =
            new JsonSerializerOptions(JsonSerializerDefaults.Web);

        // POST /api/sessoes
        public async Task<bool> RegistrarSessaoAsync(object sessao)
        {
            string json = JsonSerializer.Serialize(sessao, _opcoes);
            using var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage resposta = await _http.PostAsync("/api/sessoes", conteudo);
            return resposta.IsSuccessStatusCode;
        }

        // GET /api/sessoes
        public async Task<string> ObterSessoesAsync()
        {
            return await _http.GetStringAsync("/api/sessoes");
        }

        // GET /api/relatorio/{nomeDiscente}
        public async Task<string> ObterRelatorioAsync(string nomeDiscente)
        {
            return await _http.GetStringAsync("/api/relatorio/" + Uri.EscapeDataString(nomeDiscente));
        }
    }
}