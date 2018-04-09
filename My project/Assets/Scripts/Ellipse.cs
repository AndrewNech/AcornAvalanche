using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ellipse : MonoBehaviour
{
    public GameObject pers;
    public GameObject settings;
    public GameObject communication;
    public GameObject ButtonResume;
    public GameObject ButtonPause;
    public GameObject communicationGameOver;
    public GameObject comunicationWithScore;
    public  GameObject Shield;

    bool b = false;
    float x;
    public bool rekey2;
    public bool key2;
    public bool napravlenie = true;
    public bool napravlenie2 = true;

    public static bool shield;

    Reaction React;
    GameOver gameOver;
    Score BestScore;

    public AudioSource Crash;
    public static  int speed;
    
    public Vector3 left = new Vector3(-2.18f, -2.95f, -3);//Координаты точки возле левой стены 
    public Vector3 Right = new Vector3(2.17f, -2.9f, -3);//Координаты точки возле правой стены

    void Start()
    {
        
        x = pers.transform.position.x;
        React = communication.GetComponent<Reaction>();

        gameOver = communicationGameOver.GetComponent<GameOver>();
        shield = false;
        speed = 10;

        BestScore = comunicationWithScore.GetComponent<Score>();
    }

   
    void Update()
    {
       

        key2 = React.key;
        rekey2 = React.rekey;

        if (key2 == true && rekey2 == true) key2 = false;
        if (key2 == true)
        {
            if (x < 1.70f)
            {
                x = x + Time.deltaTime * speed;
                pers.transform.position = new Vector3(x, ((1 - (Mathf.Pow(x, 2) / (2.4f * 2.4f))) * 0.9f - 3.340304f), -3f);
            }
            else
            {
                key2 = false; React.key = key2; React.onetap = true;
                pers.transform.position = Right;
            }
        }
        if (rekey2 == true)
        {
            if (x > -1.70f)
            {
                x = x - Time.deltaTime * speed;
                pers.transform.position = new Vector3(x, ((1 - (Mathf.Pow(x, 2) / (2.4f * 2.4f))) * 0.9f - 3.340304f), -3f);
            }
            else
            {
                transform.position = left; React.onetap = true;
                rekey2 = false; React.rekey = rekey2; 
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Acorn(Clone)" && !shield)
        {
            try
            {
                gameOver.pause = true;
                Destroy(collision.gameObject);
                gameOver.undersetting.SetActive(true); ;
                settings.SetActive(!settings.activeSelf);
                ButtonResume.SetActive(false);
                
            }
             catch { }
            
            try {
                if(bool.Parse(PlayerPrefs.GetString("Music")))
                Crash.Play(); }
            catch { }
            
            ButtonPause.SetActive(false);
            React.End = true;
           





        }
        else if(collision.gameObject.name == "Acorn(Clone)" && shield)
        {
            shield = false;
            Shield.SetActive(false);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "shield(Clone)")
        {
            Shield.SetActive(true);
            shield = true;
            Destroy(collision.gameObject);
        }
    }
}
