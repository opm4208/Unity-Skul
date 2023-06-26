using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class MapArray 
{
    public GameObject[] map = new GameObject[3];
}
public class Stage : MonoBehaviour
{
    public MapArray[] stageArray = new MapArray[5];

}
