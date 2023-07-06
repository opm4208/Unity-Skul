using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiControler : MonoBehaviour
{
    public Transform minimap;

    public void MinimapSeton()
    {
        minimap.gameObject.SetActive(true);
    }
    public void MinimapSetout()
    {
        minimap.gameObject.SetActive(false);
    }
}
