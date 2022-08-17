using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float speed = 50.0f;
    private Rigidbody rb;
    private Vector3 screenBounds;

    public GameObject explosion;

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}