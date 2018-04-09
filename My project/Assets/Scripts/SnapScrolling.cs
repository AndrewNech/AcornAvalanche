using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class SnapScrolling : MonoBehaviour {
    [Range(1,50)]

    [Header("Controllers")]
      public int panCount;
    [Range(0, 500)]
    public int Offset;
    [Range(0f, 20f)]
    public float snapSpeed;
    [Range(0f, 20f)]
    public float scaleOffset;
    [Range(1f, 20f)]
    public float scaleSpeed;
    
   

    
    [Header("Other Object")]
    public GameObject prefab;
    public ScrollRect scrollRect;

    public Sprite[]  Themes; 
    public GameObject[] instPref;
    private Vector2[] posPrefs;
    private Vector2[] pansScale;
    

    private RectTransform contentRect;
    private Vector2 contentVector;
    public int seealectedPanID;
    public bool isScrolling;

    Image checkImage;


    void Start () {

        contentRect = GetComponent<RectTransform>();
        instPref = new GameObject[panCount];
        posPrefs = new Vector2[panCount];
        pansScale = new Vector2[panCount];
       

		for (int i =0; i < panCount; i++)
        {
            instPref[i] = Instantiate(prefab,transform,false);
            instPref[i].GetComponent<UnityEngine.UI.Image>().sprite = Themes[i];
            if (i == 0) continue;
            instPref[i].transform.localPosition = new Vector2(instPref[i - 1].transform.localPosition.x + prefab.GetComponent<RectTransform>().sizeDelta.x+Offset,
                instPref[i].transform.localPosition.y);
            posPrefs[i] = -instPref[i].transform.localPosition;
        }
        


    }
    //private void FixedUpdate() Было изначально, при перезапуске сцены не работает.
    void Update() //Работает при перезапуске сцены, возможна потеря производительности
    {
        if (contentRect.anchoredPosition.x>=posPrefs[0].x && !isScrolling|| contentRect.anchoredPosition.x<= posPrefs[posPrefs.Length - 1].x && !isScrolling)
        { 
            scrollRect.inertia = false;
        }
        float nearestPos = float.MaxValue;
        for (int i = 0; i < panCount; i++)
        {
            float distance = Mathf.Abs(contentRect.anchoredPosition.x - posPrefs[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                seealectedPanID = i;



            }
            float scale = Mathf.Clamp(1 / (distance / Offset) * scaleOffset, 0.1f, 0.5f);
            pansScale[i].x = Mathf.SmoothStep(instPref[i].transform.localScale.x, scale, scaleSpeed * Time.fixedDeltaTime);
            pansScale[i].y = Mathf.SmoothStep(instPref[i].transform.localScale.y, scale, scaleSpeed * Time.fixedDeltaTime);
            instPref[i].transform.localScale = pansScale[i];

        }
        for (int i = 0; i < panCount; i++)
        {
             if (i==seealectedPanID )
            {
                Image first = instPref[i].transform.Find("Image").GetComponent<Image>();
                first.color = new Color(first.color.r, first.color.g, first.color.b, 256);
            }
            else
            {
                Image second = instPref[i].transform.Find("Image").GetComponent<Image>();
                second.color = new Color(second.color.r, second.color.g, second.color.b, 0);
            }
        }
       
        float scrollVelosity = Mathf.Abs(scrollRect.velocity.x);
        if (scrollVelosity < 200 && !isScrolling) scrollRect.inertia = false;

        if (isScrolling || scrollVelosity > 200) return;
        contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, posPrefs[seealectedPanID].x, snapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contentVector;

        



    }
    public void Scrolling (bool scroll)
    {
        isScrolling = scroll;
        if (scroll) scrollRect.inertia = true;

    }
}
