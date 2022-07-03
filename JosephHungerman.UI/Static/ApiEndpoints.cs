namespace JosephHungerman.UI.Static;

public static class ApiEndpoints
{
    public static Uri? ApiBaseUrl { get; set; }
    public static string? AboutEndpoint { get; set; } = "/about/sections";
    public static string? ContactEndpoint { get; set; } = "/contact/sendmessage";
    public static string? QuoteEndpoint { get; set; } = "/quote/getall";
    public static string? ResumeEndpoint { get; set; } = "/resume";
}