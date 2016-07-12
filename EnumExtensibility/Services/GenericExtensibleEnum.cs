namespace EnumExtensibility.Services
{
    public interface IGenericExtensibleEnum<in TRequest, out TResponse>
    {
        bool CanHandle(TRequest request);
        TResponse Handle(TRequest request);
    }
}
