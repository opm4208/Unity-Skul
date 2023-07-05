using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

public abstract class Instantiate : MonoBehaviour
{
    protected GameObject prefab;
    protected string path;
    protected virtual void Awake()
    {
        PathName();
        prefab = GameManager.Resource.Load<GameObject>(path);
    }

    protected abstract void PathName();
}
