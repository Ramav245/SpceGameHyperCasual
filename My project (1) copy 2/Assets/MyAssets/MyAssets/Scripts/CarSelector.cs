using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MonoBehaviour
{


    public GameObject[] cars; 
    public int currentCarIndex = 0; 



    void Awake()
    {
        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);
    }

    void Start()
    {

        foreach (GameObject car in cars)
        {
            car.SetActive(false);
        }

        cars[currentCarIndex].SetActive(true);



    }
    
}
