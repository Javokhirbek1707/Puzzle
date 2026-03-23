using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] _cardsToPickFrom;
    private List<GameObject> _spawnItem;
    private List<GameObject> _cards;
    private List<GameObject> _shuffledCards = new List<GameObject>();
    [SerializeField] 
    private int _numberOfPairs;
    [SerializeField] 
    private bool _isRepeated;

    void Start()
    {
        ItemSpawnTime();
    }

    private void ItemSpawnTime()
    {
        _spawnItem = new List<GameObject>();
        _cards = _cardsToPickFrom.ToList();

        for (int i = 0; i < _numberOfPairs; i++)
        {
            int RNG = Random.Range(0, _cards.Count);
            _spawnItem.Add(_cards[RNG]);
            if(!_isRepeated)
            {
                _cards.RemoveAt(RNG);
            }
        }

        foreach (GameObject card in _spawnItem)
        {
            _shuffledCards.Add(card);
            _shuffledCards.Add(card);
        }

        for (int i = 0; i < _shuffledCards.Count; i++)
        {
            var r = Random.Range(i, _shuffledCards.Count);
            var temp = _shuffledCards[i];
            _shuffledCards[i] = _shuffledCards[r];
            _shuffledCards[r] = temp;
            Instantiate(_shuffledCards[i], transform);
        }
    }

    public int PairsToWin()
    {
        return _numberOfPairs;
    }
}

