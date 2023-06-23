using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class Head : MonoBehaviour
{
    public enum type{ Balance, Power, Speed};
    public Animator anim;
    public Sprite sprender;
    public static PlayerSkillAbstract skillA;
    public PlayerSkillAbstract skillB;
    public type curstate;
}
