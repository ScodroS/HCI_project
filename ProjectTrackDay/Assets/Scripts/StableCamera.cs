using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableCamera : MonoBehaviour
{
    public GameObject Mycar;
    public float CarX;
    public float CarY;
    public float CarZ;

    // Update() called once per frame
    void FixedUpdate()
    {
        CarX = Mycar.transform.eulerAngles.x;
        CarY = Mycar.transform.eulerAngles.y;
        CarZ = Mycar.transform.eulerAngles.z;
        transform.eulerAngles = new Vector3 (CarX < 180? CarX+99/100*CarX:CarX-CarX, CarY, CarZ - CarZ);
    }
}
