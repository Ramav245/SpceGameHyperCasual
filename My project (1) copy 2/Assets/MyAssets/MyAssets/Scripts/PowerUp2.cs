using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp2 : MonoBehaviour
{


   public GameObject bulletPrefab;

    private PowerTime PT; 
    private bool poweredUp = false;
    public float timer = 0; 


    public GameObject[] cars; 
    public CarSelector carSelector; 
    int currentCarIndex; 
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
            PT.playerSmallTime = 10f; 
        }
    }


    void Update()
    { 
        PT.playerSmallTime -= Time.deltaTime;

        if (PT.playerSmallTime > 0.0f && !poweredUp)
        {
            poweredUp = true;
            InvokeRepeating("LaunchProjectile", 0f, 0.3f);
        }
        else if (poweredUp && PT.playerSmallTime < 0)
        {
            CancelInvoke();
        }

    }
    
    void LaunchProjectile()
    {
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = chosenCar.transform.position;
    }






}
