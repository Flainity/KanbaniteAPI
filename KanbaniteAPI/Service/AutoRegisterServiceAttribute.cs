namespace KanbaniteAPI.Service;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class AutoRegisterServiceAttribute(ServiceLifetimeType lifetime) : Attribute
{
    public ServiceLifetimeType Lifetime { get; } = lifetime;
}