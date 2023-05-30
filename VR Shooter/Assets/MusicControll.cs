using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControll : MonoBehaviour
{

    public Slider VolumeSlider;
    public GameObject MusicObj;
    private float Volume = 1f;
    private AudioSource AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        MusicObj = GameObject.FindWithTag("Music");
        AudioSource = MusicObj.GetComponent<AudioSource>();
        AudioSource.Play();
        Volume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = Volume;
        VolumeSlider.value = Volume;
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = Volume;
        PlayerPrefs.SetFloat("volume",Volume);
    }

    public void UpdateVolume(float newVolume)
    {
        Volume = newVolume;
    }
}
