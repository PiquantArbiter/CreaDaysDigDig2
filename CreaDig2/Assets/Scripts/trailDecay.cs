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
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Lerp(1, 0, Time.deltaTime);
        transform.localScale = scale;
    }

    public IEnumerator decay()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
