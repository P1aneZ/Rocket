using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrace : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform rocket;
    void Start()
    {
        rocket = GameObject.Find("Rocket_0").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(rocket.position.x,rocket.position.y,rocket.position.z);
    }
}
