namespace Church_Management_Service.GenericResponse
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }

        public string? Message { get; set; }
        public string[] ErrorMessage { get; set; }

        public ApiResponse(bool success, T data, string? Message = null, string[] errorMessage = null)
        {
            Success = success;
            Data = data;
            this.Message = Message;
            ErrorMessage=errorMessage;  
        }
    }

    public class ApiResponseList<T>
    {
        public bool Success { get; set; }
        public List<T> Data { get; set; }

        public string? Message { get; set; }

        public ApiResponseList(bool success, List<T> data, string? Message = null)
        {
            Success = success;
            Data = data;
            this.Message = Message;
        }

    }
}
