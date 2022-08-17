using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp1 : MonoBehaviour
{

    public PowerTime PT; 

    public GameObject[] cars; 
    public CarSelector carSelector; 
    int currentCarIndex; 

    private bool poweredUp = false;

    private GameObject chosenCar; 
    
    void Awake()
    {
        cars = carSelector.cars;
        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);
        chosenCar = cars[currentCarIndex];
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PT.gunShootingTime = 5.0f;
        }
    }

    void Update()
    { 
        PT.gunShootingTime -= Time.deltaTime;

        if (PT.gunShootingTime > 0.0f && !poweredUp)
        {
            poweredUp = true;
            doPowerUp();
        }
        else if (poweredUp && PT.gunShootingTime < 0)
        {
            doPowerEnd();
        }
    }

    void doPowerUp()
    {
        print("powered up");
        chosenCar.transform.localScale = new Vector3( chosenCar.transform.localScale.x/2, chosenCar.transform.localScale.y/2, chosenCar.transform.localScale.z/2);

    }

    void doPowerEnd()
    {
        print("not powered up");
        poweredUp = false;
                chosenCar.transform.localScale = new Vector3( chosenCar.transform.localScale.x*2, chosenCar.transform.localScale.y*2, chosenCar.transform.localScale.z*2);

    //reset to your normal values.
    }

}