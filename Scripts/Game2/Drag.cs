using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Image _image;
    public Vector3 _oldPosition;
    public bool droppedOnValidZone = false;
    public bool isPlacedCorrectly = false;
    void Start()
    {
        _image = GetComponent<Image>();
        _oldPosition = _image.rectTransform.localPosition;
    }

    private void ResetPosition()
    {
        _image.rectTransform.localPosition = _oldPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        droppedOnValidZone = false;                  
        transform.SetAsLastSibling();                 

        var temp = _image.color;
        temp.a = 0.5f;
        _image.color = temp;
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var temp = _image.color;
        temp.a = 1f;
        _image.color = temp;

        if (droppedOnValidZone)
        {
            _image.raycastTarget = false;           
            _oldPosition = _image.rectTransform.localPosition;  
        }
        else
        {
            ResetPosition();
            _image.raycastTarget = true;
        }
    }
}