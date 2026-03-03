namespace HospitalManagement.API.Models
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public List<ValidationError> Errors { get; set; } = new();
    }

    public class ValidationError
    {
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
