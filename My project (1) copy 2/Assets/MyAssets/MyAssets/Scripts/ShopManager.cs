using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class ShopManager : MonoBehaviour
{


    public GameObject[] carModels; 
    public int currentCarIndex = 0; 
    public CarBlueprint[] cars; 
    public Button buyButton; 

    private HighscoreSystem HS;




    void Start()
    {


        foreach(CarBlueprint car in cars)
        {
            if(car.price == 0)
            {
                car.isUnlocked = true;
            }
            else
            {
                car.isUnlocked = PlayerPrefs.GetInt(car.name, 0) == 0 ? false: true;
            }
        }







        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);
        foreach (GameObject car in carModels)
        {

            car.SetActive(false);
        }

        carModels[currentCarIndex].SetActive(true);
    }
    

    public void ChangeNext()
    {
        carModels[currentCarIndex].SetActive(false);
        currentCarIndex++;
        if(currentCarIndex == carModels.Length)
        {
            currentCarIndex = 0; 
        }
        carModels[currentCarIndex].SetActive(true);
        CarBlueprint c = cars[currentCarIndex];

        if(!c.isUnlocked)
        {
            return; 
        }
    
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
    }

public void ChangePrev()
    {
        carModels[currentCarIndex].SetActive(false);
        currentCarIndex--;
        if(currentCarIndex == -1)
        {
            currentCarIndex = carModels.Length -1; 
        }
        carModels[currentCarIndex].SetActive(true);
        CarBlueprint c = cars[currentCarIndex];

        if(!c.isUnlocked)
        {
            return; 
        }




        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
    }

    void Update()
    {
        UpdateUI(); 
    }

    void UpdateUI()
    {
        CarBlueprint c = cars[currentCarIndex];
        if(c.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<Text>().text = "Buy-" + c.price;

            if(c.price <= PlayerPrefs.GetFloat("Highscore", 0))
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false; 
            }

        }
    }


    public void UnlockCar()
    {
        CarBlueprint c = cars[currentCarIndex];

        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("SelectedCar", currentCarIndex);
        c.isUnlocked = true; 
        PlayerPrefs.SetFloat("Highscore", PlayerPrefs.GetFloat("HighScore",0)-c.price);
    }

/* POWER UP UPGRADES */ 























}
