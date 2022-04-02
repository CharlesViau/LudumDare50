using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    private Text woodCount;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        woodCount = GetComponent<Text>();
        woodCount.text = "0";

    }

    // Update is called once per frame
    void Update()
    {

        woodCount.text = (player.Inventory.GetItem(ItemType.Wood)).ToString();
    }
}
