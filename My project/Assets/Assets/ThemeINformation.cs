using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeINformation : MonoBehaviour {
    string them;
   
    public GameObject ButtonInformation;
    public Sprite[] SpriteButton;
    

    void Start()
    {
        them = PlayerPrefs.GetString("Them");

        switch (them)
        {
            case "Light":
                {
                    ButtonInformation.GetComponent<Image>().sprite = SpriteButton[0];
                    break;
                }
            case "Sunset":
                {
                    ButtonInformation.GetComponent<Image>().sprite = SpriteButton[0];
                    break;
                }
            case "LightDark":
                {
                    ButtonInformation.GetComponent<Image>().sprite = SpriteButton[1];
                    break;
                }
            case "SunsetDark":
                {
                    ButtonInformation.GetComponent<Image>().sprite = SpriteButton[1];
                    break;
                }
            default:
                {
                    ButtonInformation.GetComponent<Image>().sprite = SpriteButton[0];
                    break;
                }
        }

    }
    public void ChangeTheme()
    {
        Start();
    }

}
