using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public Renderer meshRender;
    public float speedScroll = 0.05f;
    void Start()
    {
        
    }
    void Update()
    {
        
        meshRender.material.mainTextureOffset += new Vector2(0, speedScroll * Time.deltaTime);
    }
}
