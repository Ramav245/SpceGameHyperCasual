using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Find()
    {
        return FindObjectOfType<EventManager>();
    }
    
    public T GetEvent<T>() where T : IGameEvent
    {
        return GetComponentInChildren<T>(includeInactive:true);
    }
}
