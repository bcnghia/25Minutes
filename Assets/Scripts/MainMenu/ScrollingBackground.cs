using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBackground : MonoBehaviour
{
    //public float speed;

    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;
    //[SerializeField] private Renderer bgRenderer;

    private void Update()
    {
        //bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);

        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x,_y) * Time.deltaTime,_img.uvRect.size);
    }
}
