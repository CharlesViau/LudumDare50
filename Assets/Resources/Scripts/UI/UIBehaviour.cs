using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBehaviour : MonoBehaviour
{
    public static int staticWoodCount = 0;
    public TextMeshProUGUI woodCount;
    [SerializeField] public Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        woodCount.text = "0";
    }

    public void Awake()
    {
        woodCount = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        woodCount.text = staticWoodCount.ToString();
        //why the fuck would that not work
        //if (staticWoodCount >= _player.Inventory._capacity)
        if (staticWoodCount >= 3)
            woodCount.color = Color.red;
        else
            woodCount.color = Color.white;
    }

}
