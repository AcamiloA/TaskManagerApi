namespace AndresAlarcon.TaskManager.Application.Contracts
{
    public interface IClaimsTokenService
    {
        Guid IdRol { get; }
        Guid IdUser { get; }
        string Name { get; }
    }
}
