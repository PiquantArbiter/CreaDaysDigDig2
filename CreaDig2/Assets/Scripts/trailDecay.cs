using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trailDecay : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(decay());
    }
    private void Update()
    {
        
    }

    public IEnumerator decay()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
