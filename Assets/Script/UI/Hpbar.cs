using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    public TMP_Text tmp;
    public Player player;
    Slider slider;
    private void Awake()
    {
        tmp = GetComponent<TMP_Text>();
        slider = transform.gameObject.GetComponentInParent<Slider>();
    }
    private void Start()
    {
        player = GameManager.Player;
    }
    private void Update()
    {
        tmp.text = $"{player.hp} / {player.maxHp}";
        slider.value =  player.hp/ player.maxHp;
    }
}
