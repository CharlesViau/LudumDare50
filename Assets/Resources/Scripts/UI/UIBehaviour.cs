using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField]
    public Text woodCount;
    [SerializeField] public Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        woodCount.text = "0";

    }

    // Update is called once per frame
    void Update()
    {
        woodCount.text = (_player.Inventory.GetCountSpecificItem(ObjectType.Wood)).ToString();
    }

    void OnPickup()
    {
        
    }
}
