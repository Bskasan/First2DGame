using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.Events;

public class Collector : MonoBehaviour
{

    //List of Collectibles
    [SerializeField] private List<Collectible> _collectibles;
    [SerializeField] private UnityEvent _onCollectionComplete;
    [Header("Door Sprites")]
    [SerializeField] private Sprite _openMid;
    [SerializeField] private Sprite _openTop;

    [SerializeField] private SpriteRenderer _rendererTop;
    [SerializeField] private SpriteRenderer _rendererMid;


    private TMP_Text _remainingText;
    private Canvas _canvasGem;

    void Start()
    {
        _remainingText = GetComponentInChildren<TMP_Text>();
        _canvasGem = GetComponentInChildren<Canvas>();
    }

    
    void Update()
    {
        int countRemaining = 0;
        // it is better to use this foreach for performance.
        foreach (var collectible in _collectibles) 
        {
            if (collectible.isActiveAndEnabled)
                countRemaining++;
        }
        //for every item in this collection, look at them. check them they're true.
        //if (_collectibles.Any(t => t.gameObject.activeSelf == true))
        //    return;

        //Recommended way
        _remainingText?.SetText(countRemaining.ToString());
        // Other way;
        //_remainingText.text = countRemaining.ToString();

        if (countRemaining > 0)
            return;
                            
        Debug.Log("Got All Gems");
        _onCollectionComplete.Invoke();
    }

    private void OnValidate()
    {
        //Linq -- Distinct() will find only unique references.
        _collectibles = _collectibles.Distinct().ToList();
    }

    public void OpenGemDoor() 
    {
        _canvasGem.enabled = false;

        _rendererMid.sprite = _openMid;
        _rendererTop.sprite = _openTop;
    }
}
