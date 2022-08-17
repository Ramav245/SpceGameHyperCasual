using UnityEngine;

public static class InterfaceUtilities
{
    public static bool IsNull<T>(T obj) where T : class
    {
        return obj == null || obj.Equals(null);
    }

    public static T FindObjectOfType<T>() where T : class
    {
        var behaviours = Object.FindObjectsOfType<MonoBehaviour>();

        foreach (var behaviour in behaviours)
        {
            if (behaviour is T requestedBehaviour)
            {
                return requestedBehaviour;
            }
        }

        return null;
    }
}