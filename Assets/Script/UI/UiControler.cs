using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiControler : MonoBehaviour
{
    public Transform minimap;
    public GameObject subIconFrame;
    public GameObject subIcon;
    public GameObject subSkil1;
    public GameObject subSkil2;
    public GameObject subSkilIcon1;
    public GameObject subSkilIcon2;

    public RawImage MainIcon;
    public RawImage SubIcon;
    public RawImage MainSkilIcon1;
    public RawImage MainSkilIcon2;
    public RawImage SubSkilIcon1;
    public RawImage SubSkilIcon2;

    public Texture tempIcon;
    public Texture tempSkill1;
    public Texture tempSkill2;

    public void MinimapSeton()
    {
        minimap.gameObject.SetActive(true);
    }
    public void MinimapSetout()
    {
        minimap.gameObject.SetActive(false);
    }
    public void GetSkul()
    {
        subIconFrame.SetActive(true);
        subSkil1.SetActive(true);
        subSkil2.SetActive(true);
        subIcon.SetActive(true);
        subSkilIcon1.SetActive(true);
        subSkilIcon2.SetActive(true);
        TempImage();
    }
    public void TempImage()
    {
        tempIcon = MainIcon.texture;
        MainIcon.texture = SubIcon.texture;
        SubIcon.texture = tempIcon;

        tempSkill1 = MainSkilIcon1.texture;
        tempSkill2 = MainSkilIcon2.texture;
        MainSkilIcon1.texture = SubSkilIcon1.texture;
        MainSkilIcon2.texture = SubSkilIcon2.texture;
        SubSkilIcon1.texture = tempSkill1;
        SubSkilIcon2.texture = tempSkill2;
    }
}
