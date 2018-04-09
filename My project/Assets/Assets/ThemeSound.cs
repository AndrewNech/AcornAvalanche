using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThemeSound : MonoBehaviour {

  

    public Sprite[] MusicSprite;
    public GameObject ButtonMusic;

    string them;


    void Start () {
        

        switch (PlayerPrefs.GetString("Them"))
        {
            case "Light":
                {
                    if (bool.Parse(PlayerPrefs.GetString("Music")))
                    {
                        ButtonMusic.GetComponent<Image>().sprite = MusicSprite[0];
                    }
                    else
                    {
                        ButtonMusic.GetComponent<Image>().sprite = MusicSprite[1];
                    }
                    break;
                }
            case "Sunset":
                {

                    if (bool.Parse(PlayerPrefs.GetString("Music")))
                    {
                        ButtonMusic.GetComponent<Image>().sprite = MusicSprite[0];
                    }
                    else
                    {
                        ButtonMusic.GetComponent<Image>().sprite = MusicSprite[1];
                    }
                    break;
                }
            case "LightDark":
                {

                    if (bool.Parse(PlayerPrefs.GetString("Music")))
                    {
                        ButtonMusic.GetComponent<Image>().sprite = MusicSprite[2];
                    }
                    else
                    {
                        ButtonMusic.GetComponent<Image>().sprite = MusicSprite[3];
                    }
                    break;
                }
            case "SunsetDark":
                {

                    if (bool.Parse(PlayerPrefs.GetString("Music")))
                    {
                        ButtonMusic.GetComponent<Image>().sprite = MusicSprite[2];
                    }
                    else
                    {
                        ButtonMusic.GetComponent<Image>().sprite = MusicSprite[3];
                    }
                    break;
                }
            default:
                { 
                        ButtonMusic.GetComponent<Image>().sprite = MusicSprite[2];
                    
                    break;
                }
        }
    }


    public void ChangeTheme()
    {
        Start();
    }
}
