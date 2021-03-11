using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Linq;

public class BattleCardManager : MonoBehaviour
{
    public enum CardType
    {
        Wizard,
        Armor,
        Item,
        Magic,
        Npc,
        Weapon
    }
    //  配布するカードのプレハブ
    [SerializeField] private List<GameObject> _cardLists = new List<GameObject>();
    [SerializeField] private GameObject _parent = null;

    private List<GameObject> _handCard = new List<GameObject>();

    public void SetCard(CardType cardType)
    {
        var obj = _parent.Add(_cardLists[(int) cardType]);
        _handCard.Add(obj);
    }
}
