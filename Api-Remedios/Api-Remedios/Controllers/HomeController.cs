using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
public class HomeController : Controller
{
    private readonly HttpClient _httpClient;

    public HomeController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetRemedios> Get()
    {
        var response = await _httpClient.GetAsync("https://api.example.com/mydata");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<GetRemedios>();
    }
}

public class GetRemedios
{
    public string Data { get; set; }
}