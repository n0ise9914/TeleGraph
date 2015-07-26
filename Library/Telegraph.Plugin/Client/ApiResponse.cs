namespace TeleGraph.Plugin.Client
{
    public class ApiResponse<T>
    {
        public bool Ok;
        public T ResultObject;
        public string Message;
        public int Code;
    }
}
