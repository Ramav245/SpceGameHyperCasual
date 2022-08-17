namespace Ilumisoft.Audio
{
    using UnityEngine;
    using UnityEngine.Audio;

    public class AudioManager : MonoBehaviour, IAudioManager
    {
        private const string MusicVolumeKey = "MusicVolume";
        private const string SfxVolumeKey = "SfxVolume";

        [SerializeField] private AudioMixer audioMixer = null;

        [SerializeField, HideInInspector] private float musicVolume = 1.0f;

        [SerializeField, HideInInspector] private float sfxVolume = 1.0f;

        public float MusicVolume
        {
            get => musicVolume;
            set => SetMusicVolume(value);
        }

        public float SfxVolume
        {
            get => sfxVolume;
            set => SetSfxVolume(value);
        }

        private void Awake()
        {
            LoadSettings();

            SetMusicVolume(musicVolume);
            SetSfxVolume(sfxVolume);
        }

        private void OnDisable()
        {
            SaveSettings();
        }

        private void LoadSettings()
        {
            if (PlayerPrefs.HasKey(MusicVolumeKey))
            {
                musicVolume = PlayerPrefs.GetFloat(key: MusicVolumeKey);
            }

            if (PlayerPrefs.HasKey(SfxVolumeKey))
            {
                sfxVolume = PlayerPrefs.GetFloat(key: SfxVolumeKey);
            }
        }

        public void SaveSettings()
        {
            PlayerPrefs.SetFloat(key: MusicVolumeKey, musicVolume);
            PlayerPrefs.SetFloat(key: SfxVolumeKey, sfxVolume);

            PlayerPrefs.Save();
        }

        private void SetMusicVolume(float volume)
        {
            volume = Mathf.Clamp01(volume);

            musicVolume = volume;

            audioMixer.SetFloat("Music Volume", AudioUtils.ConvertToDecibel(volume));
        }

        private void SetSfxVolume(float volume)
        {
            volume = Mathf.Clamp01(volume);

            sfxVolume = volume;

            audioMixer.SetFloat("SFX Volume", AudioUtils.ConvertToDecibel(volume));
        }
    }
}