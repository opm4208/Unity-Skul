using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Slam : MonoBehaviour
{
    public float SlamSpeed=1;
    public Coroutine handMove;
    private void Start()
    {
        HandSlam();
    }
    public void HandSlam()
    {
        handMove = StartCoroutine(HandMove());
    }

    IEnumerator HandMove()
    {
        Vector3 player = GameManager.Player.transform.position;
        while (true)
        {
            transform.Translate((player - transform.position) * SlamSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
