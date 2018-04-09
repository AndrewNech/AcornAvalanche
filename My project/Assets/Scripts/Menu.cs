using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
using System.Threading;

[System.Serializable]
public class Menu : MonoBehaviour {
    
    public GameObject Scroll;
    public GameObject score;
    public GameObject music;
    public GameObject communication;
    public GameObject information;
    bool mus;
    public AudioSource tap;
    SnapScrolling snap;
    string them;

  
    public GameObject communicationThemeSound;
    ThemeSound ChangeThemeSound;
   



    public GameObject[] HideMenu= new GameObject[4];
   

    private void Start()
    {
        
        ChangeThemeSound = communicationThemeSound.GetComponent<ThemeSound>();
       

       // mus = bool.Parse(PlayerPrefs.GetString("Music"));
        snap = communication.GetComponent<SnapScrolling>();

       

    }
    public void StartGame()
    {
        SceneManager.LoadScene(2);
        Tap();
    }
    
  
    public void Close(GameObject obj)
    {
        obj.SetActive(false);
        Tap();
    }
    public void Music()
    {
        try
        {
            mus = bool.Parse(PlayerPrefs.GetString("Music"));
                
        }
        catch { mus = true; }
        mus = !mus;
        PlayerPrefs.SetString("Music", mus.ToString());
        ChangeThemeSound.ChangeTheme();
        Tap();
    }
    public void Tap()
    {
        try
        {
            if (bool.Parse(PlayerPrefs.GetString("Music")))
            {
                tap.Play();
            }
        }
        catch { tap.Play(); }
    }
    public void Apply()
    {
        
       for(int i = 0; i < snap.panCount; i++)
        {
            if (snap.instPref[i].transform.Find("Image").GetComponent<Image>().color.a == 256)
            {
                them = snap.instPref[i].GetComponent<Image>().sprite.name;
                PlayerPrefs.SetString("Them", them);
            }
        }
        SceneManager.LoadScene(0);
       



    }
    public void Active(GameObject obj)
    {
        Tap();
        obj.SetActive(true);
    }
  public  void HIdeMemu()
    {
        for(int i = 0; i < HideMenu.Length; i++)
        {
            HideMenu[i].SetActive(!HideMenu[i].activeSelf);
        }
    }
   
}
