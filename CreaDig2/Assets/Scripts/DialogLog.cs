using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DialogLog : MonoBehaviour
{
    public TextAsset ThisScenDia;
    public List<snippet> diaRray;
    public int plaInDia;

    public int max;

    public GameObject can;
    public TextMeshProUGUI t;
    public TextMeshProUGUI n;

    string[] coloeurs = { "pink", "red", "orange", "yellow", "green", "blue", "purple" };
    public Color[] coeulors = { new Color(0.929f, 0.431f, 0.522f,1f), Color.red, new Color(0.949f, 0.569f, 0.129f,1f), Color.yellow, Color.green, Color.blue, Color.magenta };

    GameObject darlingEmo;

    public Transform leftpos;
    public Transform rightpos;

    public GameObject Ballerina;
    public GameObject mac;
    public GameObject conOne;
    public GameObject conTwo;
    public GameObject conThree;

    public GameObject BalNeu;
    public GameObject BalHap;
    public GameObject BalSad;
    public GameObject BalAng;

    public GameObject MacNeu;
    public GameObject MacHap;
    public GameObject MacSad;
    public GameObject MacAng;

    public GameObject OneNeu;
    public GameObject OneHap;
    public GameObject OneSad;
    public GameObject OneAng;

    public GameObject TwoNeu;
    public GameObject TwoHap;
    public GameObject TwoSad;
    public GameObject TwoAng;

    public GameObject ThrNeu;
    public GameObject ThrHap;
    public GameObject ThrSad;
    public GameObject ThrAng;

    // Start is called before the first frame update
    void Start()
    {
        retrieve();
    }

    // Update is called once per frame
    void Update()
    {
        if(plaInDia < 0)
        {
            can.SetActive(false);
        }
        else if (plaInDia < max)
        {
            can.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && plaInDia < max)
        {
            Switch();
        }
        else if(Input.GetKeyDown(KeyCode.Space) && plaInDia >= max)
        {
            can.SetActive(false);
        }
    }

    public void retrieve()
    {
        string uncon = ThisScenDia.text;
        string[] bits = uncon.Split('#');
        foreach (string bit in bits)
        {
            string[] toCon = bit.Split('&');
            snippet t = new snippet
            (
                toCon[0],
                toCon[1],
                Convert.ToBoolean(toCon[2]),
                toCon[3],
                toCon[4],
                toCon[5]
            );
            diaRray.Add(t);
        }
        Debug.Log("thest");
    }

    public void Switch()
    {

        plaInDia++;

        n.text = diaRray[plaInDia].name;
        t.text = diaRray[plaInDia].saying;
        foreach(string c in coloeurs)
        {
            if(diaRray[plaInDia].color == c)
            {
                t.color = coeulors[Array.IndexOf(coloeurs, c)];
                n.color = coeulors[Array.IndexOf(coloeurs, c)];
            }
        }
        Destroy(darlingEmo);
        if(diaRray[plaInDia].sprite == "Bal")
        {
            if (diaRray[plaInDia].leftSide)
            {
                
                if(diaRray[plaInDia].emot == "neutral")
                {
                    darlingEmo = Instantiate(BalNeu, leftpos);
                } else if (diaRray[plaInDia].emot == "happy")
                {
                    darlingEmo = Instantiate(BalHap, leftpos);
                }
                else if (diaRray[plaInDia].emot == "sad")
                {
                    darlingEmo = Instantiate(BalSad, leftpos);
                }
                else if (diaRray[plaInDia].emot == "angry")
                {
                    darlingEmo = Instantiate(BalAng, leftpos);
                }
            }
            else
            {
                if (diaRray[plaInDia].emot == "neutral")
                {
                    darlingEmo = Instantiate(BalNeu, rightpos);
                }
                else if (diaRray[plaInDia].emot == "happy")
                {
                    darlingEmo = Instantiate(BalHap, rightpos);
                }
                else if (diaRray[plaInDia].emot == "sad")
                {
                    darlingEmo = Instantiate(BalSad, rightpos);
                }
                else if (diaRray[plaInDia].emot == "angry")
                {
                    darlingEmo = Instantiate(BalAng, rightpos);
                }
            }
        } else if (diaRray[plaInDia].sprite == "Mac")
        {
            if (diaRray[plaInDia].leftSide)
            {
                if (diaRray[plaInDia].emot == "neutral")
                {
                    darlingEmo = Instantiate(MacNeu, leftpos);
                }
                else if (diaRray[plaInDia].emot == "happy")
                {
                    darlingEmo = Instantiate(MacHap, leftpos);
                }
                else if (diaRray[plaInDia].emot == "sad")
                {
                    darlingEmo = Instantiate(MacSad, leftpos);
                }
                else if (diaRray[plaInDia].emot == "angry")
                {
                    darlingEmo = Instantiate(MacAng, leftpos);
                }
            }
            else
            {
                if (diaRray[plaInDia].emot == "neutral")
                {
                    darlingEmo = Instantiate(MacNeu, rightpos);
                }
                else if (diaRray[plaInDia].emot == "happy")
                {
                    darlingEmo = Instantiate(MacHap, rightpos);
                }
                else if (diaRray[plaInDia].emot == "sad")
                {
                    darlingEmo = Instantiate(MacSad, rightpos);
                }
                else if (diaRray[plaInDia].emot == "angry")
                {
                    darlingEmo = Instantiate(MacAng, rightpos);
                }
            }
        }
        else if (diaRray[plaInDia].sprite == "One")
        {
            if (diaRray[plaInDia].leftSide)
            {
                if (diaRray[plaInDia].emot == "neutral")
                {
                    darlingEmo = Instantiate(OneNeu, leftpos);
                }
                else if (diaRray[plaInDia].emot == "happy")
                {
                    darlingEmo = Instantiate(OneHap, leftpos);
                }
                else if (diaRray[plaInDia].emot == "sad")
                {
                    darlingEmo = Instantiate(OneSad, leftpos);
                }
                else if (diaRray[plaInDia].emot == "angry")
                {
                    darlingEmo = Instantiate(OneAng, leftpos);
                }
            }
            else
            {
                if (diaRray[plaInDia].emot == "neutral")
                {
                    darlingEmo = Instantiate(OneNeu, leftpos);
                }
                else if (diaRray[plaInDia].emot == "happy")
                {
                    darlingEmo = Instantiate(OneHap, leftpos);
                }
                else if (diaRray[plaInDia].emot == "sad")
                {
                    darlingEmo = Instantiate(OneSad, leftpos);
                }
                else if (diaRray[plaInDia].emot == "angry")
                {
                    darlingEmo = Instantiate(OneAng, leftpos);
                }
            }
        }
        else if (diaRray[plaInDia].sprite == "Two")
        {
            if (diaRray[plaInDia].leftSide)
            {
                if (diaRray[plaInDia].emot == "neutral")
                {
                    darlingEmo = Instantiate(BalNeu, leftpos);
                }
                else if (diaRray[plaInDia].emot == "happy")
                {
                    darlingEmo = Instantiate(BalHap, leftpos);
                }
                else if (diaRray[plaInDia].emot == "sad")
                {
                    darlingEmo = Instantiate(BalSad, leftpos);
                }
                else if (diaRray[plaInDia].emot == "angry")
                {
                    darlingEmo = Instantiate(BalAng, leftpos);
                }
            }
            else
            {
                if (diaRray[plaInDia].emot == "neutral")
                {
                    darlingEmo = Instantiate(BalNeu, leftpos);
                }
                else if (diaRray[plaInDia].emot == "happy")
                {
                    darlingEmo = Instantiate(BalHap, leftpos);
                }
                else if (diaRray[plaInDia].emot == "sad")
                {
                    darlingEmo = Instantiate(BalSad, leftpos);
                }
                else if (diaRray[plaInDia].emot == "angry")
                {
                    darlingEmo = Instantiate(BalAng, leftpos);
                }
            }
        }
        else if (diaRray[plaInDia].sprite == "Thr")
        {
            if (diaRray[plaInDia].leftSide)
            {
                if (diaRray[plaInDia].emot == "neutral")
                {
                    darlingEmo = Instantiate(BalNeu, leftpos);
                }
                else if (diaRray[plaInDia].emot == "happy")
                {
                    darlingEmo = Instantiate(BalHap, leftpos);
                }
                else if (diaRray[plaInDia].emot == "sad")
                {
                    darlingEmo = Instantiate(BalSad, leftpos);
                }
                else if (diaRray[plaInDia].emot == "angry")
                {
                    darlingEmo = Instantiate(BalAng, leftpos);
                }
            }
            else
            {
                if (diaRray[plaInDia].emot == "neutral")
                {
                    darlingEmo = Instantiate(BalNeu, leftpos);
                }
                else if (diaRray[plaInDia].emot == "happy")
                {
                    darlingEmo = Instantiate(BalHap, leftpos);
                }
                else if (diaRray[plaInDia].emot == "sad")
                {
                    darlingEmo = Instantiate(BalSad, leftpos);
                }
                else if (diaRray[plaInDia].emot == "angry")
                {
                    darlingEmo = Instantiate(BalAng, leftpos);
                }
            }
        }
        


    }
}



    [Serializable]
    public class snippet
    {
        public string name;
        public string sprite;
        public bool leftSide;
        public string color;
        public string saying;
        public string emot;

        public snippet(string t, string p, bool l, string c, string s, string e)
    {
        name = t;
        sprite = p;
        leftSide = l;
        color = c;
        saying = s;
        emot = e;

    }
    }

