using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    Text text;
    public int score;
	void Start () {
        score = PPrefs();
        text = GetComponent<Text>();
        text.fontSize = 14;
        if (PlayerPrefs.GetString("Language")=="ru_Ru") 
        text.text = "Поcледний лучший счет: "+PPrefs();
        else if (PlayerPrefs.GetString("Language") == "ch_Ch")
            text.text = "Last best score: " + PPrefs();
        else 
            text.text = "Last best score: " + PPrefs();

    }
    public int PPrefs()
    {
        return PlayerPrefs.GetInt("Score");
    }
   

	

}
