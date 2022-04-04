using UnityEngine;

public class VolumeSliderManager : MonoBehaviour
{
    private AudioSource audioSrc;

    private float audioVolume = 1.0f;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    public static float audioVolume = 1.0f;

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = audioVolume;
    }
    public void ChangeVolume(float vol)
    {
        audioVolume = vol;
    }
}
