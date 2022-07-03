namespace JosephHungerman.UI.Static;

public static class ApiEndpoints
{
    public static Uri? ApiBaseUrl { get; set; }
    public static string? AboutEndpoint { get; set; } = "/about";
    public static string? ContactEndpoint { get; set; } = "/contact";
    public static string? QuoteEndpoint { get; set; } = "/quote";
    public static string? ResumeEndpoint { get; set; } = "/resume";
}