using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 1, 0));
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, -1, 0));
        }
    }
}
