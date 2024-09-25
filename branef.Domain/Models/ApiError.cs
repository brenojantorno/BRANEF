namespace branef.Domain.Models
{
    public class ApiError(string? statusCode, string? message, string? details)
    {
        public string? StatusCode { get; set; } = statusCode;
        public string? Message { get; set; } = message;
        public string? Details { get; set; } = details;
    }
}
