using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class LangSystem : MonoBehaviour
{

    public GameObject[] buttons = new GameObject[7];

    public Image langBttnImage;
    public Sprite[] flags;

    private string json;
    public static lang lng = new lang();

    public GameObject comunicanionMenu;
    Menu MenuSound;

    string[] LangArray = { "ru_Ru", "en_En","ch_Ch" };

    int langIndex;
    private void Start()
    {
        try {
            MenuSound = comunicanionMenu.GetComponent<Menu>();
        }
        catch { }
        
        }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Language"))
        {
            if (Application.systemLanguage == SystemLanguage.Russian || Application.systemLanguage == SystemLanguage.Ukrainian || Application.systemLanguage == SystemLanguage.Belarusian)
            {
                PlayerPrefs.SetString("Language", "ru_Ru");
            }
            else if(Application.systemLanguage == SystemLanguage.Chinese)
            {
                PlayerPrefs.SetString("Language", "ch_Ch");
            }
            else PlayerPrefs.SetString("Language", "en_En");
        }
        LangLoad();
        try {
            for (int i = 0; i < buttons.Length; i++)
            { 
                buttons[i].transform.Find("Text").GetComponent<Text>().text = lng.menu[i];
            }
        }
            catch
        {
            buttons[0].transform.Find("Text").GetComponent<Text>().text = lng.gameprocess[0];
            buttons[1].GetComponent<Text>().text = lng.gameprocess[1];
            buttons[2].GetComponent<Text>().text = lng.gameprocess[2];
        }
        
    }

    void LangLoad()
    {

        //TextAsset filejson = Resources.Load<TextAsset>(PlayerPrefs.GetString("Language"));
        //        lng = JsonUtility.FromJson<lang>(filejson.text);

#if UNITY_ANDROID && !UNITY_EDITOR
        string path = Path.Combine(Application.streamingAssetsPath, "Languages/" + PlayerPrefs.GetString("Language") + ".json");
        WWW reader = new WWW(path);
        while (!reader.isDone) { }
        json = reader.text;
         lng = JsonUtility.FromJson<lang>(json);
        

#endif
#if UNITY_EDITOR
        json = File.ReadAllText(Application.streamingAssetsPath+"/Languages/"+PlayerPrefs.GetString("Language")+".json");
        lng = JsonUtility.FromJson<lang>(json);
        print(PlayerPrefs.GetString("Language"));

        

#endif
    }
public void SwitchButton()
{
        if (PlayerPrefs.GetString("Language") == "ru_Ru") // костыль
        {
            langIndex = 1;
        }
        else if(PlayerPrefs.GetString("Language") == "en_En")
        {
            langIndex = 2;
        }
        if (langIndex != LangArray.Length)
            langIndex++;
        else langIndex = 1;
        
        PlayerPrefs.SetString("Language", LangArray[langIndex-1]);
        LangLoad();
        MenuSound.Tap();
        for (int i = 0; i < buttons.Length; i++)
            buttons[i].transform.Find("Text").GetComponent<Text>().text = lng.menu[i];

    }
    

}

public class lang
{
    public string[] menu = new string[7];
    public string[] gameprocess = new string[3];
}

