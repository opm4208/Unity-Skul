using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private TMP_Text tmp;
    private void Awake()
    {
        tmp = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        tmp.text = GameManager.PortalManager.monsterCount.ToString();
    }
}
