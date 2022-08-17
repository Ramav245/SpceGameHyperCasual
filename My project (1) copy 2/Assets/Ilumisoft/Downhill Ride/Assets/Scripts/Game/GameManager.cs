using Ilumisoft.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private IScoreSystem _scoreSystem;

    private IHighscoreSystem _highscoreSystem;

    private SceneManager _sceneManager;
    
    private EventManager _eventManager;

    private GameEvent _gameOverEvent;

    private void Awake()
    {
        _eventManager = FindObjectOfType<EventManager>();
        _sceneManager = FindObjectOfType<SceneManager>();

        _scoreSystem = InterfaceUtilities.FindObjectOfType<IScoreSystem>();
        _highscoreSystem = InterfaceUtilities.FindObjectOfType<IHighscoreSystem>();
    }

    private void Start()
    {
        _gameOverEvent = _eventManager.GetEvent<GameOverEvent>();
        _gameOverEvent.AddListener(OnGameOver);

        _scoreSystem.ResetScore();

        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        _scoreSystem.ModifyScore(5 * Time.deltaTime);
    }

    private void OnGameOver()
    {
        //GameOver should only be triggered once
        _gameOverEvent.RemoveListener(OnGameOver);

        //Stop game time
        Time.timeScale = 0.0f;

        //Update highscore
        if (_scoreSystem.Score > _highscoreSystem.Highscore)
        {
            _highscoreSystem.Highscore = _scoreSystem.Score;
        }

        //Load game over scene after 1 second
        _sceneManager.LoadSceneDelayed("Game Over", delay: 1.0f);
    }
}