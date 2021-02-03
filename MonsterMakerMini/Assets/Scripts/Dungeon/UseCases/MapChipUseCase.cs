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
        mapChipPresenter.AddMapChip(0, 0, 1, TapCard);
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
