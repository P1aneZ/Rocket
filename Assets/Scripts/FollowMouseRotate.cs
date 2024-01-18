using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseRotate : MonoBehaviour
{
    public float mouseX;
    public float sensitivity; //  Û±Í¡È√Ù∂»
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {

        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseX = Mathf.Clamp(mouseX, -1, 1);
        transform.Rotate(0, 0,-mouseX);
    }
}
