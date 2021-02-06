using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MapChipUseCase : MonoBehaviour
{
    private MapChipPresenter mapChipPresenter = null;
    // Start is called before the first frame update
    void Start()
    {
        mapChipPresenter = GetComponent<MapChipPresenter>();
        mapChipPresenter.AddMapChip(0, 100, 0, TapCard);
        mapChipPresenter.AddMapChip(0, 0, 0, TapCard);
        // foreach (var i in System.Linq.Enumerable.Range(0,16))
        // {
        //     mapChipPresenter.AddMapChip(-270 + (i % 4) * 180, 270 - (i / 4) * 180, i, TapCard);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TapCard(int index)
    {
        mapChipPresenter.CardOpenAction(index);
    }
}
