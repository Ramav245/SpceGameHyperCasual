using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class CameraFollow : MonoBehaviour
{
    public GameObject[] cars; 
    public CarSelector carSelector; 
    int currentCarIndex; 
    private Vector3 _offset;
    private Vector3 _position;

    private GameObject chosenCar; 

       void Awake()
    {
        cars = carSelector.cars;
        currentCarIndex = PlayerPrefs.GetInt("SelectedCar", 0);
        chosenCar = cars[currentCarIndex];


        _position = transform.position;
        _offset = chosenCar.transform.position - _position;
    }

    void LateUpdate()
    {   

        _position.z = (chosenCar.transform.position - _offset).z;
        transform.position = _position;
    }
}
