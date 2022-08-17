namespace Ilumisoft.Audio
{
    public interface IAudioManager
    {
        float MusicVolume { get; set; }
        float SfxVolume { get; set; }
        void SaveSettings();
    }
}