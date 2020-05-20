using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    public UITitle uiTitle;

    private void Awake()
    {
        this.Init();
    }
    public void Init()
    {
        Debug.LogFormat("Title::Init");
        this.uiTitle.Init();
    }
}
