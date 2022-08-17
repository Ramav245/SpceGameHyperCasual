using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp4 : MonoBehaviour
{


    public GameObject bulletPrefab;

   
    private bool poweredUp = false;
    public float timer = 0; 


    public GameObject[] cars; 
    public CarSelector carSelector; 
    int currentCarIndex; 
    private GameObject chosenCar;
    private PowerTime PT; 

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
            PT.coinMultiplier = 10f; 
        }
    }


    void Update()
    { 
        PT.coinMultiplier -= Time.deltaTime;

        if (PT.coinMultiplier > 0.0f && !poweredUp)
        {
            poweredUp = true;
            InvokeRepeating("LaunchProjectile", 0f, 0.3f);
        }
        else if (poweredUp && PT.coinMultiplier < 0)
        {
            CancelInvoke();
        }

    }

    void LaunchProjectile()
    {
        GameObject a = Instantiate(bulletPrefab) as GameObject;
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        GameObject c = Instantiate(bulletPrefab) as GameObject;
        a.transform.position = chosenCar.transform.position + new Vector3(1.4f,0f,0.5f);
        b.transform.position = chosenCar.transform.position;
        c.transform.position = chosenCar.transform.position + new Vector3(-1.4f,0f,0.5f);
        

    }






}
