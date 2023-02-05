using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour
{

    /**
     * Script to randomize the pitch and volume of keyboard clicking sound
     */

    public AudioClip[] sounds;
    private AudioSource source;

    [Range(0.1f,0.5f)]
    public float volumeChangeMultiplier = 0.2f;
    [Range(0.1f, 0.5f)]
    public float pitchChangeMultiplier = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            randomizeKeyboardSound();
        }
    }

    public void randomizeKeyboardSound()
    {
        source.volume = Random.Range(1 - volumeChangeMultiplier, 1);
        source.pitch = Random.Range(1 - pitchChangeMultiplier, 1 + pitchChangeMultiplier);
        source.PlayOneShot(source.clip);
    }
}
