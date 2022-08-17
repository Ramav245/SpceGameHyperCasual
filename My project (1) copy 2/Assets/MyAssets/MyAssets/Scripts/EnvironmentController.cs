using UnityEngine;

public class EnvironmentController : MonoBehaviour
{


       public GameObject[] cars; 
    public CarSelector carSelector; 
    int currentCarIndex; 

    private GameObject chosenCar; 

    private Vector3 _offset;

    private Vector3 _position;
    


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
