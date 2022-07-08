namespace AdoNetReflector
{
    public class ScalarResponse<T> : AdoNetResponse
    {
        public T Data { get; set; }
    }
}
