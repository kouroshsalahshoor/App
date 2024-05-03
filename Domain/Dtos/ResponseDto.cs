namespace Domain.Dtos
{
    public class ResponseDto
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public object? Data { get; set; }
    }
}
