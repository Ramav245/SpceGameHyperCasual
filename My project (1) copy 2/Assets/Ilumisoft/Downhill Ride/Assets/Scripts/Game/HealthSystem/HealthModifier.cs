using UnityEngine;

public class HealthModifier : MonoBehaviour
{
    [SerializeField] private int amount = -1;

    private void OnTriggerEnter(Collider other)
    {
        var healthSystem = other.GetComponentInParent<IHealthSystem>();

        if (InterfaceUtilities.IsNull(healthSystem) == false)
        {
            healthSystem.ModifyHealth(amount);
        }
    }
}