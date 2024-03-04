namespace LaborationVG.Services;

public class ExchangeRateService
{
    private readonly HttpClient _http;
    public double Rate => GetUsdToEuro(ExchangeResponse!);
    public Exchange? ExchangeResponse { get; set; }

    public ExchangeRateService(HttpClient http)
    {
        _http = http;
        Task.Run(Get);
    }

    public async Task Get()
    {
        _http.DefaultRequestHeaders.Add("X-Api-Key", "2kyxbsi6zqPCYQ5Pr4Xmwg==gaGzoPawJJdH76tV");
        var response = await _http.GetAsync("https://api.api-ninjas.com/v1/exchangerate?pair=USD_EUR");
        ExchangeResponse = await response.Content.ReadFromJsonAsync<Exchange>();
    }

    public double GetUsdToEuro(Exchange exchange)
    {                       
        if (exchange is not null)
        {
            return exchange.Exchange_rate;
        }
        else
        {
            throw new Exception("Something went wrong with the exchangeService");
        }
    }
}

public class Exchange 
{
    public string? Currency_pair { get; set; }
    public double Exchange_rate { get; set; }
}
