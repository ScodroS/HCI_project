using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;


public class SpeedCheck : MonoBehaviour
{

    public CarAIControl Police;
    public float SpeedLimit;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player"))
        {
           if(other.GetComponent<CarController>().CurrentSpeed > SpeedLimit) 
            {
                Police.enabled = true;
            }
        }
    }


}
