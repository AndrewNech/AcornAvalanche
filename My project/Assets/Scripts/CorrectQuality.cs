using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectQuality : MonoBehaviour {

    private static bool qualitySeted = false;

    void Awake()
    {
        if (!qualitySeted)
        {
            qualitySeted = true;
            SetCorrectQuality();
        }
    }

    void SetCorrectQuality()
    {
        int width = Screen.height > Screen.width ? Screen.height : Screen.width;


        string[] names = QualitySettings.names;
        int i = 0;
        while (i < names.Length)
        {
            Debug.Log(names[i]);
            i++;
        }

#if UNITY_ANDROID
        float screenScale = width / 1024;
        if (screenScale > 0.6f)
        {
            QualitySettings.SetQualityLevel(1);
        }
        if (screenScale <= 0.6f && screenScale > 0.35f)
        {
            QualitySettings.SetQualityLevel(3);
        }

        if (screenScale <= 0.35f)
        {
            QualitySettings.SetQualityLevel(4);
        }
#elif UNITY_IPHONE
     //слабые айфоны
        QualitySettings.SetQualityLevel(iPhone.generation == iPhoneGeneration.iPhone3G || iPhone.generation == iPhoneGeneration.iPhone3GS ? 2: 0);
#else
        QualitySettings.SetQualityLevel (0);
#endif
    }
}

