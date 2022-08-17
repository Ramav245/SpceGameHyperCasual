namespace Ilumisoft.Audio.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Slider))]
    public class SFXSlider : MonoBehaviour
    {
        private IAudioManager _audioManager;

        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _audioManager = InterfaceUtilities.FindObjectOfType<IAudioManager>();
        }

        private void Start()
        {
            //Apply sfx volume to slider
            _slider.value = _audioManager.SfxVolume;

            //Listen to value changes
            _slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(float value)
        {
            //Apply slider value to sfx volume
            _audioManager.SfxVolume = value;
        }
    }
}