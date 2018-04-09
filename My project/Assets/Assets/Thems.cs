using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thems : MonoBehaviour {

    string them;
    public SpriteRenderer Background;
    public Sprite[] BackgroundSprite;
    
    
    void Start () {
        them = PlayerPrefs.GetString("Them");
        
        switch (them)
        {
            case "Light": {
                    Background.GetComponent<SpriteRenderer>().sprite = BackgroundSprite[0];
                               break; }
            case "Sunset": {
                    Background.GetComponent<SpriteRenderer>().sprite = BackgroundSprite[1];
                     break; }
            case "LightDark": {
                    Background.GetComponent<SpriteRenderer>().sprite = BackgroundSprite[2];
                    break;
                }
            case "SunsetDark": {
                    Background.GetComponent<SpriteRenderer>().sprite = BackgroundSprite[3];
                    break;
                }
            default: {
                    PlayerPrefs.SetString("Them", "SunsetDark");
                    Background.GetComponent<SpriteRenderer>().sprite = BackgroundSprite[3];
                     break; }
        }
        
	}
	public void ChangeTheme()
    {
        Start();
    }	

}
