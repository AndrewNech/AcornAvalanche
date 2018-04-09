using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public GameObject settings;
    public GameObject GaOv;
    public GameObject Set;
    public GameObject communication;
    public GameObject communicationPers;
    public GameObject ButtonResume;
    public GameObject BestScore;
    public GameObject TextBeforeStart;
    public GameObject Video;
    public GameObject undersetting;
    Reaction react;
    Ellipse ellipse;

    public AudioSource tap;
   public bool pause = false;
   

  



    private void Start()
    {
        react = communication.GetComponent<Reaction>();
        ellipse = communicationPers.GetComponent<Ellipse>();

        if (PlayerPrefs.GetString("Language") == "ru_Ru")
            TextBeforeStart.GetComponent<Text>().text = "Нажмите, чтобы начать";
        else
            TextBeforeStart.GetComponent<Text>().text = "Tap to start";
        
    }
   

   
    public bool Pause  
    {get { return pause; }
    } private int score = 0;

    
public void GoHome()

    {
        SceneManager.LoadScene(0);
        Video.SetActive(false);
        Tap();
    } 
    public void Settings()
    {
        
        if (PlayerPrefs.GetString("Language") == "ru_Ru")
            ButtonResume.transform.Find("Text").GetComponent<Text>().text = "Продолжить";
        else
            ButtonResume.transform.Find("Text").GetComponent<Text>().text = "Resume";

        undersetting.SetActive(true);
        settings.SetActive(true);
        Set.SetActive(true);
    
        BestScore.SetActive(false);
        BestScore.SetActive(false);
        GaOv.SetActive(false);

        pause = true;
        
        
        
        
        Tap();
        
        
    }
    
   
    public void Update()
    {
        if (pause == true)
        {
            Time.timeScale = 0;
        }
        else if(pause == false)
        {
            Time.timeScale = 1f;
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pause == true)
                {
                    close();
                }
                else
                    GoHome();
            }
        }
    }
    public void restart()
    {
        Tap();
        SceneManager.LoadScene(2);
       
        
        
    }
    public void close()
    {
        if (react.End == false)
        {
            undersetting.SetActive(false);
            pause = false;
            settings.SetActive(false);
             GaOv.SetActive(true);
           
            BestScore.SetActive(true);
            Set.SetActive(false);
            Tap();
            ellipse.ButtonPause.SetActive(true);
        }
       
    }
    

    void Tap()
    {
        try
        {
            if (bool.Parse(PlayerPrefs.GetString("Music")))
            {
                tap.Play();
                ellipse.ButtonPause.SetActive(true);
            }
        }
        catch { }
    }

}
