using System;
using CertifyJsonService.Models;
using System.Text.Json;
using static System.Diagnostics.Trace;

namespace CertifyJsonService
{
    public class ApiTestController<T>
    {
        private string url;
        private string? port;
        private HttpClient http = new();
        private static JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        public ApiTestController(string url, string port, string model)
        {
            this.url = $"{url}:{port}/api/{model}";
            WriteLine($"Url:{this.url}");
        }

        public async Task<IEnumerable<T>> TestList()
        {
            HttpRequestMessage req = new();
            req.RequestUri = new Uri(url);
            req.Method = HttpMethod.Get;
            HttpResponseMessage res = await http.SendAsync(req);
            var json = await res.Content.ReadAsStringAsync();
            if (res.StatusCode != System.Net.HttpStatusCode.OK)
                throw new HttpRequestException(json, null, res.StatusCode);
            IEnumerable<T> instances = JsonSerializer.Deserialize<T[]>(json, options)!;
            return instances;
        }
    }
}

