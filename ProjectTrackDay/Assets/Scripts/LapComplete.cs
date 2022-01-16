using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour {

	public GameObject LapCompleteTrig;
	public GameObject HalfLapTrig;

	public GameObject MinuteDisplay;
	public GameObject SecondDisplay;
	public GameObject MilliDisplay;

	public static int BestMinuteCount = 0;
	public static int BestSecondCount = 0;
	public static float BestMilliCount = 0f;

	public GameObject LapTimeBox;

	public static bool FirstLapCheck = true;

	/*
	void Update(){
		Debug.Log(LapCompleteTrig.GetComponent<BoxCollider>().isTrigger.ToString());
	}
	*/

	private void OnTriggerEnter () {

		if (FirstLapCheck) {

			FirstLapCheck = false;
			LapTimeManager.MinuteCount = 0;
			LapTimeManager.SecondCount = 0;
			LapTimeManager.MilliCount = 0f;

			HalfLapTrig.SetActive(true);
			LapCompleteTrig.SetActive(false);

		} else {

			if (LapTimeManager.MinuteCount < BestMinuteCount 
				|| (LapTimeManager.MinuteCount == BestMinuteCount && LapTimeManager.SecondCount < BestSecondCount) 
				|| (LapTimeManager.MinuteCount == BestMinuteCount && LapTimeManager.SecondCount == BestSecondCount && LapTimeManager.MilliCount < BestMilliCount)
				|| (BestMinuteCount == 0 && BestSecondCount == 0 && BestMilliCount == 0f)) {
				//Debug.Log("I shouldn't be here... " + LapTimeManager.MinuteCount.ToString() + " < " + BestMinuteCount.ToString() + "?");
				if (LapTimeManager.SecondCount <= 9) {
					SecondDisplay.GetComponent<Text>().text = "0" + LapTimeManager.SecondCount + ".";
				} else {
					SecondDisplay.GetComponent<Text>().text = "" + LapTimeManager.SecondCount + ".";
				}
				if (LapTimeManager.MinuteCount <= 9) {
					MinuteDisplay.GetComponent<Text>().text = "0" + LapTimeManager.MinuteCount + ".";
				} else {
					MinuteDisplay.GetComponent<Text>().text = "" + LapTimeManager.MinuteCount + ".";
				}
				MilliDisplay.GetComponent<Text>().text = "" + LapTimeManager.MilliCount.ToString("F0");

				BestMinuteCount = LapTimeManager.MinuteCount; 
				BestSecondCount = LapTimeManager.SecondCount;
				BestMilliCount = LapTimeManager.MilliCount;

			}

			LapTimeManager.MinuteCount = 0;
			LapTimeManager.SecondCount = 0;
			LapTimeManager.MilliCount = 0f;

			HalfLapTrig.SetActive(true);
			LapCompleteTrig.SetActive(false);

			Debug.Log("I was here!");

		}
	}
}