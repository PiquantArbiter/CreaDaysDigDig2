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

    public bool lefth;
    public bool righth;

    public GameObject basnote;
    public GameObject hanote;
    public GameObject fanote;

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
                righth = true;
                StartCoroutine(dec(righth));
            }
            else
            {
                Instantiate(trail, halfLeft);
                lefth = true;
                StartCoroutine(dec(lefth));
            }
            
            pos--;
        } else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) && pos != 1)
        {
            chara.transform.position = chara.transform.position + new Vector3(3, 0, 0);
            if (pos == -1)
            {
                Instantiate(trail, halfLeft);
                lefth = true;
                StartCoroutine(dec(lefth));
            }
            else
            {
                Instantiate(trail, halfRight);
                righth = true;
                StartCoroutine(dec(righth));
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
            GameObject q = Instantiate(hanote, halfLeft);
            q.GetComponent<halfNot>().leftq = true;
        }
        else if (n == "mr")
        {
            GameObject q = Instantiate(hanote, halfRight);
            q.GetComponent<halfNot>().leftq = false;
        }
        else if (n == "laft")
        {
            Instantiate(fanote, left);
        }
        else if (n == "raght")
        {
            Instantiate(fanote, rigt);
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

    public IEnumerator dec(bool b)
    {
        yield return new WaitForSeconds(1);
        b = false;
    }
}
