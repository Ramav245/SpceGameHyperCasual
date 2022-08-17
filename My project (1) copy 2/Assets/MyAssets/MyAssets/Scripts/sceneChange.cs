using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;








public class sceneChange : MonoBehaviour
{

    [SerializeField]private string sceneName;

    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
        //EnemyDriver.GameOver = false; 
        //ResetGame.RestartPlayer = true; 
    }
}
