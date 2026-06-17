using System.Net.Http.Json;

namespace ChurchAdminMVP.Client.Services;

public class AuthService
{
    private readonly HttpClient _http;

    public AuthService(HttpClient http)
    {
        _http = http;
    }

    public async Task<(bool Success, string Message)> RegisterAsync(string email, string password)
    {
        var response = await _http.PostAsJsonAsync("api/Auth/register", new { email, password });
        if (response.IsSuccessStatusCode)
            return (true, "Registration successful");

        return (false, "Registration failed. Email may already be in use.");
    }

    public async Task<(bool Success, string Token, string Message)> LoginAsync(string email, string password)
    {
        var response = await _http.PostAsJsonAsync("api/Auth/login", new { email, password });
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<LoginResult>();
            return (true, result?.Token ?? string.Empty, "Login successful");
        }

        return (false, string.Empty, "Invalid email or password");
    }
}

public class LoginResult
{
    public string Token { get; set; } = string.Empty;
}
