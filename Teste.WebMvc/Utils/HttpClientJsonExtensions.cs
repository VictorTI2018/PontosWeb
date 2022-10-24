

using System.Net.Http.Headers;
using System.Text.Json;

namespace Teste.WebMvc.Utils
{
    public static class HttpClientJsonExtensions
    {
        private static MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");


        public static async Task<T> ReadContentAsync<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Ocorreu um problema na chamada da api: {response.ReasonPhrase}");

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


        }

        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T dados)
        {
            var dataAsString = JsonSerializer.Serialize(dados);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;

            return httpClient.PostAsync(url, content);
        }

        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T dados)
        { 
            var dataAsString = JsonSerializer.Serialize(dados);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = contentType;

            return httpClient.PutAsync(url, content);
        }
    }
}
