using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Anim : MonoBehaviour {

    public Sprite[] JumpRight=new Sprite[4];
   
    public Sprite[] JumpRightDark = new Sprite[4];
   

    public Sprite[] Stay = new Sprite[2];

    public GameObject communicationReact;
    Reaction reaction;
    Ellipse ellipse;

    

    public GameObject Personage;
   

    

    private void Start()
    {
        reaction = communicationReact.GetComponent<Reaction>();
        ellipse = gameObject.GetComponent<Ellipse>();
        
       
    }


    void Update () {
        if (!reaction.onetap)
        {
            if (ellipse.key2)
            {
                if (PlayerPrefs.GetString("Them") == "Light" || PlayerPrefs.GetString("Them") == "Sunset")
                {
                    if (Personage.transform.position.x > -2.18 && Personage.transform.position.x < -1.40f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRight[0];
                    }
                    else if (Personage.transform.position.x > -1.40f && Personage.transform.position.x < -0.50f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRight[1];
                    }
                    else if (Personage.transform.position.x > -0.50f && Personage.transform.position.x < 0.30f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRight[2];
                    }
                    else if (Personage.transform.position.x > 0.30f && Personage.transform.position.x < 1.3f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRight[3];
                    }
                    else if (Personage.transform.position.x > 1.3f && Personage.transform.position.x < 2)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRight[4];
                    }
                }
                else
                {
                    if (Personage.transform.position.x > -2.18 && Personage.transform.position.x < -1.40f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRightDark[0];
                    }
                    else if (Personage.transform.position.x > -1.40f && Personage.transform.position.x < -0.50f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRightDark[1];
                    }
                    else if (Personage.transform.position.x > -0.50f && Personage.transform.position.x < 0.30f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRightDark[2];
                    }
                    else if (Personage.transform.position.x > 0.30f && Personage.transform.position.x < 1.3f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRightDark[3];
                    }
                    else if (Personage.transform.position.x > 1.3f && Personage.transform.position.x < 2)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRightDark[4];
                    }
                }
            }
            else 
            {
                if (PlayerPrefs.GetString("Them") == "Light" || PlayerPrefs.GetString("Them") == "Sunset")
                {
                    if (Personage.transform.position.x < 2.16f && Personage.transform.position.x > 1.4f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRight[0];
                    }
                    else if (Personage.transform.position.x > 0.53f && Personage.transform.position.x < 1.4f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRight[1];
                    }
                    else if (Personage.transform.position.x > -0.34f && Personage.transform.position.x < 0.53f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRight[2];
                    }
                    else if (Personage.transform.position.x > -1.20f && Personage.transform.position.x < -0.34f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRight[3];
                    }
                    else if (Personage.transform.position.x > -2f && Personage.transform.position.x < -1.20f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRight[4];
                    }
                }
                else
                {
                   if (Personage.transform.position.x < 2.16f && Personage.transform.position.x > 1.4f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRightDark[0];
                    }
                    else if (Personage.transform.position.x > 0.53f && Personage.transform.position.x < 1.4f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRightDark[1];
                    }
                    else if (Personage.transform.position.x > -0.34f && Personage.transform.position.x < 0.53f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRightDark[2];
                    }
                    else if (Personage.transform.position.x > -1.20f && Personage.transform.position.x < -0.34f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRightDark[3];
                    }
                    else if (Personage.transform.position.x > -2f && Personage.transform.position.x < -1.20f)
                    {
                        Personage.GetComponent<SpriteRenderer>().sprite = JumpRightDark[4];
                    }
                }
            }
 }
        if (PlayerPrefs.GetString("Them") == "Light" || PlayerPrefs.GetString("Them") == "Sunset")
        {
            if (Personage.transform.position.x > 2)
            {
                Personage.GetComponent<SpriteRenderer>().sprite = Stay[0];
                Personage.transform.localScale = new Vector3(-0.3f, 0.3f, 1);
            }
            if (Personage.transform.position.x < -2)
            {
                Personage.GetComponent<SpriteRenderer>().sprite = Stay[0];
                Personage.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            }
        }
        else
        {
            if (Personage.transform.position.x > 2)
            {
                Personage.GetComponent<SpriteRenderer>().sprite = Stay[1];
                Personage.transform.localScale = new Vector3(-0.3f, 0.3f, 1);
            }
            if (Personage.transform.position.x < -2)
            {
                Personage.GetComponent<SpriteRenderer>().sprite = Stay[1];
                Personage.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            }
        }

	}
}
