using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVScroll : MonoBehaviour
{

    public float scrollSpeed = 0.5f;

    Renderer mat;
    Vector2 offset;
    public Vector2 scrollDirection = Vector2.right;


    private void Start()
    {
        mat = GetComponent<Renderer>();
        offset = mat.material.mainTextureOffset;

    }

    private void Update()
    {
        offset += scrollDirection.normalized * scrollSpeed * Time.deltaTime;
        mat.material.mainTextureOffset = offset;
    }
}
