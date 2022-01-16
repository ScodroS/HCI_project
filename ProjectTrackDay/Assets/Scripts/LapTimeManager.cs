using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimeManager : MonoBehaviour {

	// static because we have to reference these variables in another script
	public static int MinuteCount;
	public static int SecondCount;
	public static float MilliCount;
	public static string MilliDisplay;

	public GameObject MinuteBox;
	public GameObject SecondBox;
	public GameObject MilliBox;

	void Start() {
		Application.targetFrameRate = Screen.currentResolution.refreshRate;
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
	}

	void Update() {

		if (!LapComplete.FirstLapCheck) {
			MilliCount += Time.deltaTime * 10;
			MilliDisplay = MilliCount.ToString("F0");
			MilliBox.GetComponent<Text>().text = "" + MilliDisplay;

			if (MilliCount >= 10) {
				MilliCount = 0;
				SecondCount += 1;
			}

			if (SecondCount <= 9) {
				SecondBox.GetComponent<Text>().text = "0" + SecondCount + ".";
			} else {
				SecondBox.GetComponent<Text>().text = "" + SecondCount + ".";
			}

			if (SecondCount >= 60) {
				SecondCount = 0;
				MinuteCount += 1;
			}

			if (MinuteCount <= 9) {
				MinuteBox.GetComponent<Text>().text = "0" + MinuteCount + ":";
			} else {
				MinuteBox.GetComponent<Text>().text = "" + MinuteCount + ":";
			}
		} else {
			MilliBox.GetComponent<Text>().text = "0";
			SecondBox.GetComponent<Text>().text = "00"  + ".";
			MinuteBox.GetComponent<Text>().text = "00"  + ":";
		}
	}
}