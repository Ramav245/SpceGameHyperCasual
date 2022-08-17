using UnityEngine;

public class MobileGraphicSettings : MonoBehaviour
{
    [SerializeField, Range(0,4)]
    int vSyncCount = 0;

    [SerializeField]
    int targetFrameRate = 120;

    [SerializeField]
    float resolutionScalingFixedDPIFactor = 1;

    private void Awake()
    {
        if (Application.isMobilePlatform)
        {
            QualitySettings.vSyncCount = vSyncCount;
            QualitySettings.resolutionScalingFixedDPIFactor = resolutionScalingFixedDPIFactor;

            Application.targetFrameRate = targetFrameRate;
        }
    }

}
