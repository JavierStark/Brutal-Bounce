using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button_Effect : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float scale = 0.95f;

	public void OnPointerDown(PointerEventData evenData)
	{
        transform.localScale = new Vector3(scale, scale, 1);
    }

    public void OnPointerUp(PointerEventData evenData)
	{
        transform.localScale = new Vector3(1, 1, 1);
	}
}