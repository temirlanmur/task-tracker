namespace TaskTracker.WebAPI.APIModels
{
    public class ErrorAPIModel
    {
        public string Message { get; set; }

        public ErrorAPIModel(string message) { Message = message; }
    }
}
