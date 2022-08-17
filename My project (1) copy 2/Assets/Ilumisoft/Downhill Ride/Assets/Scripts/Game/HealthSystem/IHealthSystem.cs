using UnityEngine.Events;

public interface IHealthSystem
{
    HealthChangedEvent OnHealthChanged { get; }
    
    UnityEvent OnHealthEmpty { get; }
    
    void ModifyHealth(int amount);
}