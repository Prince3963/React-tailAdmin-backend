namespace MyDummyAPI.HelperServices
{
    public class ResponseServices<T>
    {
        public T? data {  get; set; }
        public string? message { get; set; }
        public bool status { get; set; } 
    }
}
