using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class Reaction : MonoBehaviour {

    [SerializeField] private GameObject Obstacles;
    
    public bool key = false;
    public bool rekey = false; 
    public bool start = false;
    public  float forkey = 0;
    public float timer = 0;
    public float tr = 26;
    public float speed = -3.0f;
    public int index = 0;
    
    [SerializeField] public bool End = false;
  
    public  int score = 7;
    public int ir;
    private float tik = 3; private float tak =1;
    public int prob = 1;
    public int prob2 = 1;
    public bool onetap = true; public AudioSource jump;
    GameOver GOv;
    
    [SerializeField] bool music;
    public GameObject communication;
    public GameObject Score;
    public GameObject TextBeforeStart;
    public GameObject[] DiffObs = new GameObject[8];
    public GameObject shield;
    private GameObject SecondShield;
    public GameObject [] Obs;

    int scet = 0;//ограничитеть для трех в ряд
    int scet2 = 0;

    bool FirstLet = true;

   


   

    int NubmberRand = 7;//Контроль появления 3х в ряд

    public void   OnMouseDown() 
    {
        if (End == false)
            if (onetap == true)
            {
                onetap = false;
                if (forkey == 0)
                { key = true; forkey = 1; if (music)jump.Play(); }
                else if (key == false)
                { rekey = true; forkey = 0; if(music)jump.Play(); }
            }
        start = true;
        TextBeforeStart.SetActive(false);

       
       
        
    }
   
    void Start () {
        
        if (PlayerPrefs.GetString("Music") == "True")
        {
            music = true;
        }
        else if (PlayerPrefs.GetString("Music") == "False")
        {
            music = false;
        }
        Obs = new GameObject[8];
        ir = Random.Range(1, 3);
         StartCoroutine(Inst());
        
        GOv = communication.GetComponent<GameOver>();

    }
    IEnumerator Inst()
    {
        if(index ==8)
            index = 0;

        yield return new WaitForSeconds(0);

        if (start==true)
        { if (FirstLet == true)
        {
            yield return new WaitForSeconds(0.5f);
            FirstLet = false;
        }
        else
            yield return new WaitForSeconds( Random.Range(tak,tik));
            if (ir == 1)
            {

                if (prob < 3)
                {
                    if (prob2 > 1) { prob2 = 1; }
                    Obs[index] = Instantiate(Obstacles, new Vector3(-1.64f, 5.6f, -3), Quaternion.identity) as GameObject; prob++;
                }
                else { Obs[index] = Instantiate(Obstacles, new Vector3(1.64f, 5.6f, -3), Quaternion.identity) as GameObject; prob = 1; }

            }
            else
            {

                if (prob2 < 3)
                { if (prob > 1) { prob = 1; } Obs[index] = Instantiate(Obstacles, new Vector3(1.64f, 5.6f, -3), Quaternion.identity) as GameObject; prob2++; }
                else { Obs[index] = Instantiate(Obstacles, new Vector3(-1.64f, 5.6f, -3), Quaternion.identity) as GameObject; prob2 = 1; }

            }
             Destroy(Obs[index], 5); // Удаление через 5 сек
            if (index < 8)
                index++;
        }
        
        Repeat();
    
    }
    IEnumerator difficult()
    {
        yield return new WaitForSeconds(tak+0.5f);
        DiffObs[0] = Instantiate(Obstacles, new Vector3(1.64f, 5.6f, -3), Quaternion.identity) as GameObject;
        DiffObs[2] = Instantiate(Obstacles, new Vector3(0f, 5.6f, -3), Quaternion.identity) as GameObject;
        DiffObs[1] = Instantiate(Obstacles, new Vector3(-1.64f, 5.6f, -3), Quaternion.identity) as GameObject;

        Destroy(DiffObs[0], 5);//Удаление через 5 сек
        Destroy(DiffObs[1], 5);
        Destroy(DiffObs[2], 5);
        scet = 4;
        Repeat();

    }
    IEnumerator Shield()
    {
        yield return new WaitForSeconds(Random.Range(tak, tik));
        if(Random.RandomRange(0,2)==0)
        SecondShield = Instantiate(shield, new Vector3(1.84f, 5.6f, -3) , Quaternion.identity) as GameObject;
        else SecondShield = Instantiate(shield, new Vector3(-1.847f, 5.6f, -3), Quaternion.identity) as GameObject;

        Destroy(SecondShield, 5);
        scet2 = 4;

        Repeat();
    }

    void Repeat()
    {
        scet--;
        scet2--;
        int r;
        if (NubmberRand == 4)
            r = Random.Range(0, 3);
        else r = Random.Range(0, 2); 

        if ((score / 7) > 100)
            switch (Random.Range(1, NubmberRand))
            {
                case 3: { if (scet < 1)
                        { StartCoroutine(difficult()); }
                        else
                        { StartCoroutine(Inst()); }
                        break; }
                case 4:
                    {
                        {
                            if (scet2 < 1 && r==0)
                            { StartCoroutine(Shield()); }
                            else
                            { StartCoroutine(Inst()); }
                            break;
                        }
                    }
                default:
                    {
                        ir = Random.Range(1, 3);
                        StartCoroutine(Inst());
                        break;
                    }
            }
        else
        {
            ir = Random.Range(1, 3);
            StartCoroutine(Inst());
        }
    }


    void Update() {
        if (start == true)
        {
            
                timer += Time.deltaTime;
            tr = 1+Mathf.RoundToInt(timer);
            if (tr % 10 == 0 && speed>-15)// ускорение блоков
            {
                speed -= 0.5f * Time.deltaTime;

            }
            if (tr % 15 == 0 && tik >1f) // расстояние между блоками максимальное
            {
                    tik -= 0.5f;
            }
            if (tr % 25 == 0 && tak> 0.5f)// расстояние между блоками минимальное
            {
                 tak -= 0.5f;
            }  //Расстояние в 1 сек

            if (GOv.Pause == false && End == false)
             {
                score++;
                if (score % 1400 == 0 && Ellipse.speed < 13) { Ellipse.speed += 1; }// ускорение прыжка
                Score.GetComponent<Text>().text = ""+score / 7;
               
            }
            
            try
            {
                if (DiffObs[0] != null && DiffObs[1] != null && DiffObs[2] != null)//Удаление одного из 3х в ряд
                {
                    int r = Random.Range(0, 2);
                    if (DiffObs[r].transform.position.y < 2.7f)
                    {
                        Destroy(DiffObs[r]);
                    }
                }
            }
            catch { }
        } 

        if (End == false)
            //try
            {
                for (int i = 0; i < Obs.Length; i++)
                {
                    try
                    {

                        Obs[i].transform.position = Vector3.MoveTowards(Obs[i].transform.position, new Vector3(Obs[i].transform.position.x, -6, -3), Time.deltaTime * -speed);
                    }
                    catch { }
                }  
                    for(int i =0;i<DiffObs.Length;i++)
                        try
                        {
                                DiffObs[i].transform.position = Vector3.MoveTowards(DiffObs[i].transform.position, new Vector3(DiffObs[i].transform.position.x, -6, -3),
                                  -speed * Time.deltaTime  );
                        }
                        catch { }

                    try
                    {
                        
                        
                            SecondShield.transform.position = Vector3.MoveTowards(SecondShield.transform.position, new Vector3(SecondShield.transform.position.x, -6, -3), Time.deltaTime * -speed);
                        
                    }
                    catch { }
                
            }
            //catch { }
        else
        {
            PPrefs();
        }
        
        if((score/7)% 200 == 0 && NubmberRand>4)
        {
            NubmberRand--;
        }
    }
    public void PPrefs()
    {
        if (PlayerPrefs.GetInt("Score")< (score / 7))
        PlayerPrefs.SetInt("Score", score / 7);
    }
}
