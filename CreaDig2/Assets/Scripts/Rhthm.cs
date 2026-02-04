using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using TMPro;

public class Rhthm : MonoBehaviour
{
    public float bpm;

    public GameObject chara;
    public GameObject trail;
    public int pos; 

    public Vector3 goal;

    public bool moveleft;
    public bool moveright;

    public GameObject basnote;
    public GameObject hanote;

    public Transform left;
    public Transform halfLeft;
    public Transform midd;
    public Transform halfRight;
    public Transform rigt;

    public int points;

    public TextAsset song;
    public List<string> noties;
    public List<int> timings;
    public int notPos;
    public int notMax;

    public TextMeshProUGUI poiText;

    // Start is called before the first frame update
    void Start()
    {
        receive();
        StartCoroutine(baseNote(noties[notPos], timings[notPos]));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) && pos != -1)
        {
            chara.transform.position = chara.transform.position + new Vector3(-3, 0, 0);
            if(pos == 1)
            {
                Instantiate(trail, halfRight);
            }
            else
            {
                Instantiate(trail, halfLeft);
            }
            
            pos--;
        } else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) && pos != 1)
        {
            chara.transform.position = chara.transform.position + new Vector3(3, 0, 0);
            if (pos == -1)
            {
                Instantiate(trail, halfLeft);
            }
            else
            {
                Instantiate(trail, halfRight);
            }
            pos++;
        }

    }

    public void receive()
    {
        string[] notes = song.text.Split('&');
        foreach(string note in notes)
        {
            string[] com = note.Split('#');
            noties.Add(com[0]);
            timings.Add(Convert.ToInt32(com[1]));

        }
    }

    public IEnumerator baseNote(string n, int t)
    {
        yield return new WaitForSeconds(t * bpm / 60);
        if (n == "left")
        {
            Instantiate(basnote, left);
        } else if(n == "mid")
        {
            Instantiate(basnote, midd);
        }
        else if (n == "right")
        {
            Instantiate(basnote, rigt);
        }
        else if (n == "ml")
        {
            Instantiate(hanote, halfLeft);
        }
        else if (n == "mr")
        {
            Instantiate(hanote, halfRight);
        }
        notPos++;
        
        if(notPos != notMax)
        {
            StartCoroutine(baseNote(noties[notPos], timings[notPos]));
        }
        
    }


    public void point()
    {
        points++;
        poiText.text = "Points:" + points;
    }
}
