using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour
{
    [SerializeField] private List<Sprite> cardSprites = new List<Sprite>();

    private bool _isSurface = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeSprite()
    {
        _isSurface = !_isSurface;
        GetComponent<SpriteRenderer>().sprite = _isSurface ? cardSprites[0] : cardSprites[1];
    }
}
