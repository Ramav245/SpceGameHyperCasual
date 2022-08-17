using System;
using UnityEngine;

public class ScoreSystem : MonoBehaviour, IScoreSystem
{
    private const string PlayerPrefsKey = "Score";
    private Money money; 
    private float _score;

    private ScoreChangedEvent onScoreChanged = new ScoreChangedEvent();
    
    public float Score => _score;

    public ScoreChangedEvent OnScoreChanged => onScoreChanged;

    private void Awake()
    {
        LoadScore();
    }

    public void ModifyScore(float amount)
    {
        _score += amount;
        OnScoreChanged.Invoke(_score, amount);
    }

    public void ResetScore()
    {
        _score = 0;
    }

    private void LoadScore()
    {
        if (PlayerPrefs.HasKey(PlayerPrefsKey))
        {
            _score = PlayerPrefs.GetFloat(PlayerPrefsKey);
        }
    }

    private void SaveScore()
    {
        PlayerPrefs.SetFloat(PlayerPrefsKey, _score);
    }
    
    private void OnDisable()
    {
        SaveScore();
    }
}
