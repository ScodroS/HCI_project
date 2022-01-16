using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public enum Modes {
    Wheel,
    Tilt,
    Arrows
}

public class InputManager : MonoBehaviour
{

    public Button Wheel;
    public Button Tilt;
    public Button Arrows;

    public GameObject TiltMode;
    public GameObject WheelMode;
    public GameObject ArrowsMode;

    public GameObject WheelMinBox;
    public GameObject WheelSecBox;
    public GameObject WheelMilBox;

    public GameObject TiltMinBox;
    public GameObject TiltSecBox;
    public GameObject TiltMilBox;

    public GameObject ArrowsMinBox;
    public GameObject ArrowsSecBox;
    public GameObject ArrowsMilBox;

    private Modes Mode = Modes.Arrows;

    private int TiltMinutes;
    private int TiltSeconds;
    private float TiltMillis;

    private int WheelMinutes;
    private int WheelSeconds;
    private float WheelMillis;

    private int ArrowsMinutes;
    private int ArrowsSeconds;
    private float ArrowsMillis;

    public GameObject BestMin;
    public GameObject BestSec;
    public GameObject BestMil;

    // Start is called before the first frame update
    void Start()
    {
        buttonArrows();

        TiltMinutes = 0;
        TiltSeconds = 0;
        TiltMillis = 0f;
        WheelMinutes = 0;
        WheelSeconds = 0;
        WheelMillis = 0f;
        ArrowsMinutes = 0;
        ArrowsSeconds = 0;
        ArrowsMillis = 0f;
    }

    private void OnEnable() {
        //Register Button Events
        Wheel.onClick.AddListener(() => buttonWheel());
        Tilt.onClick.AddListener(() => buttonTilt());
        Arrows.onClick.AddListener(() => buttonArrows());
    }

    private void buttonArrows() {

        UpdateCurrentBest();
        UpdateFields();

        Arrows.interactable = false;
        Tilt.interactable = true;
        Wheel.interactable = true;

        if (CrossPlatformInputManager.AxisExists("Horizontal"))
            CrossPlatformInputManager.UnRegisterVirtualAxis("Horizontal");

        ArrowsMode.SetActive(true);
        WheelMode.SetActive(false);
        TiltMode.SetActive(false);

        Mode = Modes.Arrows;

        // set best lap (gameplay) as current best lap in mode (menu)
        if(ArrowsMinutes != 0 || ArrowsSeconds != 0 || ArrowsMillis != 0f) {
            SetBest(ArrowsMinutes, ArrowsSeconds, ArrowsMillis);
            updateBestFields(ArrowsMinutes, ArrowsSeconds, ArrowsMillis);
            Debug.Log("Entrato in SetBest per Arrows...");
        }
        else {
            SetBest(0, 0, 0f);
            updateBestFields(0, 0, 0f);
        }
    }

    private void buttonTilt() {

        UpdateCurrentBest();
        UpdateFields();

        Tilt.interactable = false;
        Arrows.interactable = true;
        Wheel.interactable = true;

        if (CrossPlatformInputManager.AxisExists("Horizontal")) 
            CrossPlatformInputManager.UnRegisterVirtualAxis("Horizontal");

        TiltMode.SetActive(true);
        WheelMode.SetActive(false);
        ArrowsMode.SetActive(false);

        Mode = Modes.Tilt;

        // set best lap (gameplay) as current best lap in mode (menu)
        if(TiltMinutes != 0 || TiltSeconds != 0 || TiltMillis != 0f) {
            SetBest(TiltMinutes, TiltSeconds, TiltMillis);
            updateBestFields(TiltMinutes, TiltSeconds, TiltMillis);
            Debug.Log("Entrato in SetBest per Tilt...");
        }
        else {
            SetBest(0, 0, 0f);
            updateBestFields(0, 0, 0f);
        }
    }

    private void buttonWheel() {

        UpdateCurrentBest();
        UpdateFields();

        Wheel.interactable = false;
        Arrows.interactable = true;
        Tilt.interactable = true;

        if (CrossPlatformInputManager.AxisExists("Horizontal")) 
            CrossPlatformInputManager.UnRegisterVirtualAxis("Horizontal");

        WheelMode.SetActive(true);
        ArrowsMode.SetActive(false);
        TiltMode.SetActive(false);

        Mode = Modes.Wheel;

        // set best lap (gameplay) as current best lap in mode (menu)
        if(WheelMinutes != 0 || WheelSeconds != 0 || WheelMillis != 0f) {
            SetBest(WheelMinutes, WheelSeconds, WheelMillis);
            updateBestFields(WheelMinutes, WheelSeconds, WheelMillis);
            Debug.Log("Entrato in SetBest per Wheels...");
        }
        else {
            SetBest(0, 0, 0f);
            updateBestFields(0, 0, 0f);
        }
    }

    public Modes getMode() {
        return Mode;
    }

    private void SetBest(int MinuteCount, int SecondCount, float MilliCount) {
		LapComplete.BestMinuteCount = MinuteCount;
		LapComplete.BestSecondCount = SecondCount;
		LapComplete.BestMilliCount = MilliCount;
	}

    private void UpdateCurrentBest() {
        if (Mode == Modes.Wheel) {
            if (LapComplete.BestMinuteCount < WheelMinutes 
				|| (LapComplete.BestMinuteCount == WheelMinutes && LapComplete.BestSecondCount < WheelSeconds) 
				|| (LapComplete.BestMinuteCount == WheelMinutes && LapComplete.BestSecondCount == WheelSeconds && LapComplete.BestMilliCount < WheelMillis)
                || (WheelMinutes == 0 && WheelSeconds == 0 && WheelMillis == 0f)) {
                    WheelMinutes = LapComplete.BestMinuteCount;
                    WheelSeconds = LapComplete.BestSecondCount;
                    WheelMillis = LapComplete.BestMilliCount;
            }
        } 
        else if (Mode == Modes.Tilt) {
            if (LapComplete.BestMinuteCount < TiltMinutes 
				|| (LapComplete.BestMinuteCount == TiltMinutes && LapComplete.BestSecondCount < TiltSeconds) 
				|| (LapComplete.BestMinuteCount == TiltMinutes && LapComplete.BestSecondCount == TiltSeconds && LapComplete.BestMilliCount < TiltMillis)
                || (TiltMinutes == 0 && TiltSeconds == 0 && TiltMillis == 0f)) {
                    TiltMinutes = LapComplete.BestMinuteCount;
                    TiltSeconds = LapComplete.BestSecondCount;
                    TiltMillis = LapComplete.BestMilliCount;
            }

        }
        else if (Mode == Modes.Arrows) {
            if (LapComplete.BestMinuteCount < ArrowsMinutes 
				|| (LapComplete.BestMinuteCount == ArrowsMinutes && LapComplete.BestSecondCount < ArrowsSeconds) 
				|| (LapComplete.BestMinuteCount == ArrowsMinutes && LapComplete.BestSecondCount == ArrowsSeconds && LapComplete.BestMilliCount < ArrowsMillis) 
                || (ArrowsMinutes == 0 && ArrowsSeconds == 0 && ArrowsMillis == 0f)){
                    ArrowsMinutes = LapComplete.BestMinuteCount;
                    ArrowsSeconds = LapComplete.BestSecondCount;
                    ArrowsMillis = LapComplete.BestMilliCount;
            }
        }
    }

    // update best lap fields for each mode (menu)
    private void UpdateFields() {
        if (Mode == Modes.Wheel) {
			WheelMilBox.GetComponent<Text>().text = "" + WheelMillis.ToString("F0");
            if (WheelSeconds <= 9) {
				WheelSecBox.GetComponent<Text>().text = "0" + WheelSeconds + ".";
			} else {
				WheelSecBox.GetComponent<Text>().text = "" + WheelSeconds + ".";
			}
            if (WheelMinutes <= 9) {
				WheelMinBox.GetComponent<Text>().text = "0" + WheelMinutes + ":";
			} else {
				WheelMinBox.GetComponent<Text>().text = "" + WheelMinutes + ":";
			}
        }
        else if (Mode == Modes.Tilt) {
            TiltMilBox.GetComponent<Text>().text = "" + TiltMillis.ToString("F0");
            if (TiltSeconds <= 9) {
				TiltSecBox.GetComponent<Text>().text = "0" + TiltSeconds + ".";
			} else {
				TiltSecBox.GetComponent<Text>().text = "" + TiltSeconds + ".";
			}
            if (TiltMinutes <= 9) {
				TiltMinBox.GetComponent<Text>().text = "0" + TiltMinutes + ":";
			} else {
				TiltMinBox.GetComponent<Text>().text = "" + TiltMinutes + ":";
			}
        }
        else if (Mode == Modes.Arrows) {
            ArrowsMilBox.GetComponent<Text>().text = "" + ArrowsMillis.ToString("F0");
            if (ArrowsSeconds <= 9) {
				ArrowsSecBox.GetComponent<Text>().text = "0" + ArrowsSeconds + ".";
			} else {
				ArrowsSecBox.GetComponent<Text>().text = "" + ArrowsSeconds + ".";
			}
            if (ArrowsMinutes <= 9) {
				ArrowsMinBox.GetComponent<Text>().text = "0" + ArrowsMinutes + ":";
			} else {
				ArrowsMinBox.GetComponent<Text>().text = "" + ArrowsMinutes + ":";
            }
        }
        Debug.Log("Update Fields reached end!");
    }

    // update text field of best lap in current mode (gameplay)
    private void updateBestFields(int Minutes, int Seconds, float Millis) {
        	BestMil.GetComponent<Text>().text = "" + Millis.ToString("F0");
            if (Seconds <= 9) {
				BestSec.GetComponent<Text>().text = "0" + Seconds + ".";
			} else {
				BestSec.GetComponent<Text>().text = "" + Seconds + ".";
			}
            if (Minutes <= 9) {
				BestMin.GetComponent<Text>().text = "0" + Minutes + ":";
			} else {
				BestMin.GetComponent<Text>().text = "" + Minutes + ":";
			}
    }
    // Update is called once per frame
}
