using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var battleCardMng = GetComponent<BattleCardManager>();
        battleCardMng.SetCard(BattleCardManager.CardType.Weapon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
