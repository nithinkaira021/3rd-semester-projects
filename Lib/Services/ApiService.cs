using Lib.Models;
using Newtonsoft.Json;
using System.Text;

public class WebApiService
{
    private readonly HttpClient _httpClient;

    public WebApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://localhost:7165/");
    }

    public async Task<List<Surfboard>> GetSurfboardsAsync(string? apiVersion = null)
    {
        string apiUrl = "api/surfboards";

        if (!string.IsNullOrEmpty(apiVersion) && (apiVersion == "1.0" || apiVersion == "2.0"))
        {
            apiUrl += $"?api-version={Uri.EscapeDataString(apiVersion)}";
        }

        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var surfboards = JsonConvert.DeserializeObject<List<Surfboard>>(jsonResponse);

        return surfboards;
    }

    public async Task<Surfboard> GetSurfboardByIdAsync(int id)
    {
        string apiUrl = $"api/surfboards/{id}";

        HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var surfboard = JsonConvert.DeserializeObject<Surfboard>(jsonResponse);

        return surfboard;
    }

    public async Task<Rental> PostSurfboardAsync(Rental rental)
    {
        // Convert the Rental object to JSON
        var jsonRequest = JsonConvert.SerializeObject(rental);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        // Send a POST request to the server
        HttpResponseMessage response = await _httpClient.PostAsync("api/rentals", content);
        response.EnsureSuccessStatusCode();

        // Read the response from the server
        var jsonResponse = await response.Content.ReadAsStringAsync();

        // Deserialize the JSON response to a Rental object
        var postedRental = JsonConvert.DeserializeObject<Rental>(jsonResponse);

        return postedRental;
    }
}
