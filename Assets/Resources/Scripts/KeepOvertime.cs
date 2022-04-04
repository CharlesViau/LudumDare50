using UnityEngine;

public class KeepOvertime : MonoBehaviour
{
    public static float timeDuration;
    private void Start()
    {
        timeDuration = TimeManager._elapsedTime;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
