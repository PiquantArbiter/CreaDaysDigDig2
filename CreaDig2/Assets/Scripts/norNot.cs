using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class norNot : MonoBehaviour
{
    public int bpm;
    public GameObject player;
    public GameObject cont;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cont = GameObject.FindGameObjectWithTag("GameController");
        StartCoroutine(beatMove());
        StartCoroutine(beatDes());
    }
    public void Update()
    {
        if(transform.position.y == -3.5f)
        {
            if(player.transform.position.x == transform.position.x)
            {
                cont.GetComponent<Rhthm>().point();
                Destroy(gameObject);
            }
            
        }
    }
    public IEnumerator beatDes()
    {
        yield return new WaitForSeconds(10f*bpm/60);
        Destroy(gameObject);
    }

    public IEnumerator beatMove()
    {
        yield return new WaitForSeconds(1 * bpm / 60);
        transform.position = transform.position + new Vector3(0, -1f, 0);
        StartCoroutine(beatMove());
    }
}
