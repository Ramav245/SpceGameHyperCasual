namespace Ilumisoft.Audio.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Slider))]
    public class MusicSlider : MonoBehaviour
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
            //Apply music volume to slider
            _slider.value = _audioManager.MusicVolume;

            //Listen to value changes
            _slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(float value)
        {
            //Apply slider value to music volume
            _audioManager.MusicVolume = value;
        }
    }
}