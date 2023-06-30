using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    protected ElderEnt elderEnt;
    protected Transform stampPosition;
    protected Coroutine stampReady;
    protected void Start()
    {
        elderEnt = transform.parent.GetComponent<ElderEnt>();
    }

    protected IEnumerator StampReady()
    {
        while (true)
        {
            Debug.Log(stampPosition);
            transform.Translate((stampPosition.position - transform.position).normalized *3 * Time.deltaTime);
            yield return null;
            if ((stampPosition.position.y - transform.position.y) < 0.01f)
                StopCoroutine(stampReady);
        }
    }
 
}
