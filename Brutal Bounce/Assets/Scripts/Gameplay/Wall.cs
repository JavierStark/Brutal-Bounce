using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    BoxCollider2D collider2D;
    RectTransform rectTransform;

    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        rectTransform = GetComponent<RectTransform>();

        SetColliderSize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetColliderSize()
    {
        collider2D.size = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
    }
}
