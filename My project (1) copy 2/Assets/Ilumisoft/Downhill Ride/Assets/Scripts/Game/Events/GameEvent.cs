using UnityEngine;
using UnityEngine.Events;

public class GameEvent : MonoBehaviour, IGameEvent
{
    [SerializeField]
    private UnityEvent onInvoke = new UnityEvent();
    
    public void AddListener(UnityAction call)
    {
        onInvoke.AddListener(call);
    }

    public void RemoveListener(UnityAction call)
    {
        onInvoke.RemoveListener(call);
    }
    
    public void Invoke()
    {
        onInvoke.Invoke();
    }
}
