using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighscoreText : MonoBehaviour
{
    private IHighscoreSystem _highscoreSystem;

    private Text _highscoreText;
    private Money money; 
    private void Awake()
    {
        _highscoreSystem = InterfaceUtilities.FindObjectOfType<IHighscoreSystem>();
        _highscoreText = GetComponent<Text>();
    }

    private void Start()
    {
        _highscoreText.text = money.moneyAmount.ToString();
    }






}
