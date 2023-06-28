using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    TMP_Text tmp;
    Player player;
    Slider slider;
    private void Awake()
    {
        tmp = GetComponent<TMP_Text>();
        player = GameManager.Player;
        slider = transform.gameObject.GetComponentInParent<Slider>();
    }
    private void Update()
    {
        tmp.text = $"{player.hp} / {player.maxHp}";
        slider.value = player.maxHp/player.hp;
    }
}
