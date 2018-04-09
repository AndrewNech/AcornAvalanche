using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeGUI : MonoBehaviour {

    string them;

    public GameObject []GUI;
    public Sprite[] BackgroundSprite;
    void Start () {

        them = PlayerPrefs.GetString("Them");

        switch (them)
        {
            case "Light":
                {
                    for(int i =0;i<GUI.Length;i++)
                    GUI[i].GetComponent<Image>().sprite = BackgroundSprite[0];
                    break;
                }
            case "Sunset":
                {
                    for (int i = 0; i < GUI.Length; i++)
                        GUI[i].GetComponent<Image>().sprite = BackgroundSprite[1];
                    break;
                }
            case "LightDark":
                {
                    for (int i = 0; i < GUI.Length; i++)
                        GUI[i].GetComponent<Image>().sprite = BackgroundSprite[2];
                    break;
                }
            case "SunsetDark":
                {
                    for (int i = 0; i < GUI.Length; i++)
                        GUI[i].GetComponent<Image>().sprite = BackgroundSprite[3];
                    break;
                }
            default:
                {
                    for (int i = 0; i < GUI.Length; i++)
                        GUI[i].GetComponent<Image>().sprite = BackgroundSprite[0];
                    break;
                }
        }
    }


    public void ChangeTheme()
    {
        Start();
    }
}
