namespace Domain.Dtos
{
    public class ResponseDto
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public List<string> Errors { get; set; } = new();
        public int StatusCode { get; set; }
        public object? Data { get; set; }
    }
}
