using UnityEngine;

public class HighscoreSystem : MonoBehaviour, IHighscoreSystem
{
    private const string PlayerPrefsKey = "Highscore";

    private float _highscore = 0;
private Money money; 
    public float Highscore
    {
        get => _highscore;
        set
        {
            _highscore = value;
        }
    }

    private void Awake()
    {
        LoadHighscore();
    }

    private void LoadHighscore()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsKey))
        {
            _highscore = PlayerPrefs.GetFloat(PlayerPrefsKey);
            
        }
    }


}
