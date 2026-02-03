using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rhthm : MonoBehaviour
{
    public float bpm;

    public GameObject chara;

    public Vector3 goal;

    public bool moveleft;
    public bool moveright;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) && !moveleft)
        {
            moveleft = true;
            goal = chara.transform.position + new Vector3(-3, 0, 0);
        } else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) && !moveleft)
        {
            moveleft = true;
            goal = chara.transform.position + new Vector3(3, 0, 0);
        }
        if (moveleft)
        {
            
            chara.transform.position = Vector2.Lerp(chara.transform.position, goal, Time.deltaTime);
            if(chara.transform.position == goal)
            {
                moveleft = false;
            }
        }
    }

    public IEnumerator baseNote()
    {
        yield return new WaitForSeconds(bpm*4/60);
    }

    public void move(bool dirL)
    {
        if (dirL)
        {
            goal = chara.transform.position + new Vector3(-1, 0, 0);
        }
        else
        {
            goal = chara.transform.position + new Vector3(1, 0, 0);
        }
        float t = 0;
        while(t <= 1)
        {
            if (t <= 0.5)
            {
                t = -Mathf.Sqrt(0.25f - Time.deltaTime * Time.deltaTime) + 0.5f;
            }
            else
            {
                t = Mathf.Sqrt(0.25f - (Time.deltaTime - 1) * (Time.deltaTime - 1)) + 0.5f;
            }
            chara.transform.position = Vector2.Lerp(transform.position, goal, t);
        }
        
    }
}
