using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Money : MonoBehaviour
{
    // Start is called before the first frame update
        public const string Coins = "Coins";
    public float moneyAmount; 
    private float totalCash; 

    [SerializeField]
    private Text coinCounter; 

    void Start()
    {
        moneyAmount = 10000; 
        //moneyAmount = PlayerPrefs.GetFloat("Coins");
    }

    void Update()
    {
        coinCounter.text = moneyAmount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CoinScript>())
        { 
            Destroy(other.gameObject);
            increaseGems(); 
        }
    }

    public void increaseGems()
    {
        moneyAmount += 1; 
        PlayerPrefs.SetFloat("Coins", moneyAmount);
        PlayerPrefs.Save(); 
    }




















}
