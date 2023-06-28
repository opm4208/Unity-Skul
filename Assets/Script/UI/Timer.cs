using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    private TMP_Text tmp;
    private float time;
    private int times;
    private string[] timer = new string[3];

    private void Awake()
    {
        tmp = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        time+= Time.deltaTime;
        times = (int)time;
        timer[0] = times % 60 < 10 ? $"0{times % 60}" : $"{times % 60}";
        timer[1] = times / 60 % 60 < 10 ? $"0{times / 60 % 60}" : $"{times / 60 % 60}";
        timer[2] = times / 3600 < 10 ? $"0{times / 3600}" : $"{times / 3600}";
        tmp.text = $"{timer[2]} : {timer[1]} : {timer[0]}";
    }
}
