using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Define;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] bgm;

    public Slider volumeSlider;

    AudioSource bgmSource;

    bool isMusic;
    StagePhase stagePhase;

    void Start()
    {
        bgmSource = this.GetComponent<AudioSource>();
        stagePhase = GameManager.instance.StagePhase;
        bgmSource.volume = GameManager.instance.gameData.volumeValue;
    }

    void Update()
    {
        if (stagePhase != GameManager.instance.StagePhase)
        {
            stagePhase = GameManager.instance.StagePhase;
            isMusic = false;
        }

        if (!isMusic)
        {
            if (GameManager.instance.StagePhase == StagePhase.Phase1)
            {
                PlayMusic(0);
            }
            else if (GameManager.instance.StagePhase == StagePhase.Phase2)
            {
                PlayMusic(1);
            }
            else if (GameManager.instance.StagePhase == StagePhase.Phase3)
            {
                PlayMusic(2);
            }
        }
        
    }

    void PlayMusic(int num)
    {
        bgmSource.clip = bgm[num];
        bgmSource.Play();
        isMusic = true;
    }

    public void VolumeControll(float volume)
    {
        GameManager.instance.VolumeValue = volume;
        bgmSource.volume = GameManager.instance.gameData.volumeValue;
    }

}
