using System.Diagnostics.CodeAnalysis;
namespace barbershop.model
{
    public class DefaultResponseDto<T>
    {
        public bool success { get; set; } = false;
        public string message { get; set; } = string.Empty;
        [MaybeNull]
        public T? result { get; set; } = default;
    }
}
