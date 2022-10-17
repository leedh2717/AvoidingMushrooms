using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Destroy(gameObject, 0.2f);
        audioSource.volume = GameManager.instance.gameData.volumeValue;
    }

    void Update()
    {
        
    }
}
