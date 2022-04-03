using UnityEngine;

public class VolumeSliderManager : MonoBehaviour
{
    private AudioSource audioSrc;

    private float audioVolume = 1.0f;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

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
