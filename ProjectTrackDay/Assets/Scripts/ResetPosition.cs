using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPosition : MonoBehaviour
{
    public Button ResBut;
    public GameObject Mycar;
    public GameObject LapCompleteTrig;
	public GameObject HalfLapTrig;
    private Vector3 InitRot;
    private Vector3 InitPos;

    void Start()
    {
        // Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        ResBut.onClick.AddListener(TaskOnClick);
        InitPos = transform.position;
        InitRot = transform.eulerAngles;
    }

    void TaskOnClick()
    {   
        GetComponent<Rigidbody>().isKinematic = true;
        // transform.position = new Vector3(327.9f, 0.01f, 119.7f);
        // transform.eulerAngles = new Vector3(0, 90, 0);
        transform.position = InitPos;
        transform.eulerAngles = InitRot;

		LapTimeManager.MinuteCount = 0;
		LapTimeManager.SecondCount = 0;
		LapTimeManager.MilliCount = 0;
        LapComplete.FirstLapCheck = true;
        HalfLapTrig.SetActive(false);
        LapCompleteTrig.SetActive(true);

        // Debug.Log("You have clicked the reset button!");
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
