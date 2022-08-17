using UnityEngine;
using UnityEngine.UI;

public class PU_Two : MonoBehaviour
{
    private Money money; 

    private PowerTime PT; 
    
    public Text improvement; 
    public Text powerupCost;


    private float costOfPowerUp1; 
    private float costOfPowerUp2; 
    private float costOfPowerUp3; 
    private float costOfPowerUp4; 
    private float costOfPowerUp5; 

    public Slider slider1; 
    public Slider slider2; 
    public Slider slider3; 
    public Slider slider4; 
    public Slider slider5; 






    void Awake()
    {
        money = FindObjectOfType<Money>();
        PT = FindObjectOfType<PowerTime>();
        PT.gunShootingTime = PlayerPrefs.GetFloat("PU_TIME");
        PT.playerSmallTime = PlayerPrefs.GetFloat("player_small_time");

        costOfPowerUp1 = PlayerPrefs.GetFloat("CostOfPowerUp1");
        costOfPowerUp2 = PlayerPrefs.GetFloat("CostOfPowerUp2");
        costOfPowerUp3 = PlayerPrefs.GetFloat("CostOfPowerUp3");
        costOfPowerUp4 = PlayerPrefs.GetFloat("CostOfPowerUp4");
        costOfPowerUp5 = PlayerPrefs.GetFloat("CostOfPowerUp5");
    }

    void Update()
    {
        improvement.text = PT.gunShootingTime.ToString() + "sec"; 
        powerupCost.text = costOfPowerUp1.ToString() + "gems"; 
    }

    //Gun shooting time Powerup increase
     public void increasePowerUpGunShootingTime()
    {
        if(money.moneyAmount >= costOfPowerUp1)
        {

            //increase powerup and save
            costOfPowerUp1 += 5;
            PlayerPrefs.SetFloat("CostOfPowerUp1", costOfPowerUp1);



            //decrease cash
            money.moneyAmount -= costOfPowerUp1; 
            PlayerPrefs.SetFloat("Coins", money.moneyAmount);

            //increase powerup
            PT.gunShootingTime += 1.5f; 
            PlayerPrefs.SetFloat("PU_TIME", PT.gunShootingTime);

            //move slider
            slider1.value += PT.gunShootingTime;
        }
    }

    public void increasePlayerSmallTime()
    {
        if(money.moneyAmount >= costOfPowerUp2)
        {
            //decrease cash
            money.moneyAmount -= costOfPowerUp2;
            PlayerPrefs.SetFloat("Coins", money.moneyAmount);

            //increase powerup
            PT.playerSmallTime += 1.5f;
            PlayerPrefs.SetFloat("player_small_time", PT.playerSmallTime); 

            //move slider
            slider2.value += PT.playerSmallTime;

        }
    }

    public void tripleShootTimePowerUp()
    {
        if(money.moneyAmount >= costOfPowerUp3)
        {
            //decrease cash
            money.moneyAmount -= costOfPowerUp3;
            PlayerPrefs.SetFloat("Coins", money.moneyAmount);

            //increase powerup
            PT.tripleShootingTime += 1.5f;
            PlayerPrefs.SetFloat("player_small_time", PT.tripleShootingTime); 

            //move slider
            slider3.value += PT.tripleShootingTime;

        }
    }



}
