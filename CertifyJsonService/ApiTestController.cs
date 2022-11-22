using System;
using CertifyJsonService.Models;
using System.Text.Json;
using static System.Diagnostics.Trace;

namespace CertifyJsonService
{
    public class ApiTestController<T>
    {
        private string url;
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

        public async Task<IEnumerable<T>> List()
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
        public async Task<T?> Get(int id)
        {
            HttpRequestMessage req = new();
            req.RequestUri = new Uri($"{url}/{id}");
            req.Method = HttpMethod.Get;
            HttpResponseMessage res = await http.SendAsync(req);
            var json = await res.Content.ReadAsStringAsync();
            if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
                return default(T);
            T t = System.Text.Json.JsonSerializer.Deserialize<T>(json, options)!;
            return t;
        }
        public async Task<T> Create(T t)
        {
            HttpRequestMessage req = new();
            var tSerialized = System.Text.Json.JsonSerializer.Serialize(t);
            req.RequestUri = new Uri($"{url}");
            req.Method = HttpMethod.Post;
            req.Content = new StringContent(tSerialized, System.Text.Encoding.UTF8, "application/json");
            req.Headers.Add("contentType", "application/json");
            HttpResponseMessage res = await http.SendAsync(req);
            var json = await res.Content.ReadAsStringAsync();
            if (res.StatusCode != System.Net.HttpStatusCode.Created)
                throw new HttpRequestException("Create failed!", null, res.StatusCode);
            T t2 = System.Text.Json.JsonSerializer.Deserialize<T>(json, options)!;
            return t2;
        }
        public async Task Change(int id, T t)
        {
            HttpRequestMessage req = new();
            var tSerialized = System.Text.Json.JsonSerializer.Serialize(t);
            req.RequestUri = new Uri($"{url}/{id}");
            req.Method = HttpMethod.Put;
            req.Content = new StringContent(tSerialized, System.Text.Encoding.UTF8, "application/json");
            req.Headers.Add("contentType", "application/json");
            HttpResponseMessage res = await http.SendAsync(req);
            if (res.StatusCode != System.Net.HttpStatusCode.NoContent)
                throw new HttpRequestException("Put failed!", null, res.StatusCode);
        }
        public async Task Remove(int id)
        {
            HttpRequestMessage req = new();
            req.RequestUri = new Uri($"{url}/{id}");
            req.Method = HttpMethod.Delete;
            HttpResponseMessage res = await http.SendAsync(req);
            if (res.StatusCode != System.Net.HttpStatusCode.NoContent)
                throw new HttpRequestException("Remove failed!", null, res.StatusCode);
        }
    }
}

