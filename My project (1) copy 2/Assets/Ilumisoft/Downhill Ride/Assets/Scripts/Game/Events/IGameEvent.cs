using UnityEngine.Events;

public interface IGameEvent
{
    void AddListener(UnityAction call);
    void RemoveListener(UnityAction call);
    void Invoke();
}