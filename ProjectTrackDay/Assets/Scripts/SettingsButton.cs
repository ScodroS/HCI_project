using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    public Button SettingsBut;
    public GameObject GamePanel;
    public GameObject SettingsPanel;

    void Start()
    {
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        SettingsBut.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {   
        if(GamePanel.activeSelf){
            GamePanel.SetActive(false);
            SettingsPanel.SetActive(true);
        }
        else {
            SettingsPanel.SetActive(false);
            GamePanel.SetActive(true);
        }
    }
}
