using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class halfNot : MonoBehaviour
{
    public int bpm;
    public bool leftq;
    public GameObject cont;

    private void Awake()
    {
        cont = GameObject.FindGameObjectWithTag("GameController");
        StartCoroutine(beatMove());
        StartCoroutine(beatDes());
    }
    public void Update()
    {
        if (transform.position.y == -3.5f)
        {
            if (leftq && cont.GetComponent<Rhthm>().lefth)
            {
                cont.GetComponent<Rhthm>().point();
                Destroy(gameObject);
            } else if (!leftq && cont.GetComponent<Rhthm>().righth)
            {
                cont.GetComponent<Rhthm>().point();
                Destroy(gameObject);
            }

        }
    }
    public IEnumerator beatDes()
    {
        yield return new WaitForSeconds(11f * bpm / 60);
        Destroy(gameObject);
    }

    public IEnumerator beatMove()
    {
        yield return new WaitForSeconds(1f * bpm / 60);
        transform.position = transform.position + new Vector3(0, -1f, 0);
        StartCoroutine(beatMove());
    }
}
