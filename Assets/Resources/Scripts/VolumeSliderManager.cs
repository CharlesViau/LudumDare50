using UnityEngine;

public class VolumeSliderManager : MonoBehaviour
{
    private AudioSource audioSrc;
    public static float audioVolume = 1.0f;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = audioVolume;
    }
}
