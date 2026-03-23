using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drop : MonoBehaviour, IDropHandler
{
    private Image _thisImage;

    void Start()
    {
        _thisImage = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        Drag drag = eventData.pointerDrag.GetComponent<Drag>();
        if (drag == null) return;

        if (CompareTag("CollectForAnimal") && eventData.pointerDrag.CompareTag("Animal") ||CompareTag("CollectForBird") && eventData.pointerDrag.CompareTag("Bird"))
        {
            drag.droppedOnValidZone = true;

            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;

            if (!drag.isPlacedCorrectly)
            {
                drag.isPlacedCorrectly = true;
                BirdvsAnimalManager.Instance.RegisterCorrectDrop();
            }
        }
    }
    
}