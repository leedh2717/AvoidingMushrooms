using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class StageManager : MonoBehaviour
{   
    float phaseTimer = 0;

    public Player player;
    bool isMinusHp = true;

    void Start()
    {
        GameManager.instance.StagePhase = StagePhase.Phase1;
        GameManager.instance.StageLevel = StageLevel.Level1;
    }

    void Update()
    {
        StagePhaseSetting();
    }

    private void StagePhaseSetting()
    {
        if (!GameManager.instance.IsBoss && GameManager.instance.StagePhase == StagePhase.Phase3)
        {
            phaseTimer = 0;
        }

        phaseTimer += Time.deltaTime;

        if (phaseTimer > 40) // Phase 3
        {
            GameManager.instance.StagePhase = StagePhase.Phase3;
            GameManager.instance.IsBoss = true;
        }
        else if (phaseTimer > 20) // Phase 2
        {
            GameManager.instance.StagePhase = StagePhase.Phase2;
        }
        else // Phase 1
        {
            GameManager.instance.StagePhase = StagePhase.Phase1;
        }
        StartCoroutine(MinusHp(1));
    }

    IEnumerator MinusHp(int time)
    {
        if (isMinusHp)
        {
            isMinusHp = false;
            GameManager.instance.PlayerCurrentHp -= 1 + (int)GameManager.instance.StageLevel;
            StartCoroutine(PlusSecondsScore());
            yield return new WaitForSeconds(time);
            isMinusHp = true;
        }        
    }

    IEnumerator PlusSecondsScore()
    {
        GameManager.instance.Score += 1 + (int)GameManager.instance.StageLevel;
        yield return new WaitForSeconds(1);
    }

}
