namespace Company.Ecommerce.Transversal.Common
{
    public class Response<T>
    {
        public T Data { get; set; } = default!;
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = default!;
    }
}
