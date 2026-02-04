using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastNot : MonoBehaviour
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
        if (transform.position.y == -3.5f)
        {
            if (player.transform.position.x == transform.position.x)
            {
                cont.GetComponent<Rhthm>().point();
                Destroy(gameObject);
            }

        }
    }
    public IEnumerator beatDes()
    {
        yield return new WaitForSeconds(11f * (1f / (bpm / 60f)));
        //Destroy(gameObject);
    }

    public IEnumerator beatMove()
    {
        yield return new WaitForSeconds(0.5f * (1f / (bpm / 60f)));
        transform.position = transform.position + new Vector3(0, -1f, 0);
        StartCoroutine(beatMove());
    }
}
