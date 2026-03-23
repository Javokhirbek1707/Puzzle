using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerDownHandler
{

    /*[SerializeField] private int _itemID;
    [SerializeField] private Image _coverImage;
    [SerializeField] private MatchItem _itemMatch;

    void Start()
    {
        _itemMatch = GameObject.Find("Game_Manager").GetComponent<MatchItem>();
        if (_itemMatch == null)
            Debug.LogError("MatchItem is null");
    }

    public int ReturnItemID()
    {
        return _itemID;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _itemMatch.Match(this.gameObject);
        UncoverItem();
    }

    private void UncoverItem()
    {
        _coverImage.gameObject.SetActive(false);
    }

    public void CoverItem(bool matched)
    {
        if (matched == false)
            _coverImage.gameObject.SetActive(true);
    }*/

    [SerializeField] private int _itemID;
    [SerializeField] private Image _coverImage;
    private MatchItem _itemMatch;

    void Start()
    {
        _itemMatch = MatchItem.Instance;

        if (_itemMatch == null)
            Debug.LogError("MatchItem Instance is null! Make sure Game_Manager exists in the scene.");
    }

    public int ReturnItemID()
    {
        return _itemID;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_itemMatch != null)
        {
            _itemMatch.Match(this.gameObject);
            UncoverItem();
        }
    }

    private void UncoverItem()
    {
        _coverImage.gameObject.SetActive(false);
    }

    public void CoverItem(bool matched)
    {
        if (matched == false)
            _coverImage.gameObject.SetActive(true);
    }
}
