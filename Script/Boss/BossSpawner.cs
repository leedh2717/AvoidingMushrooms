using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Define;

public class BossSpawner : MonoBehaviour
{
    public StageManager stage;

    [SerializeField]
    GameObject[] bossPrefab;
    [SerializeField]
    Transform canvasTr;
    [SerializeField]
    GameObject bossHpSlider;

    int stageLevel;


    void Start()
    {
        stageLevel = 1;
    }

    void Update()
    {
        // phase와 boss 소환상태 확인
        if (GameManager.instance.StagePhase == StagePhase.Phase3 && GameManager.instance.IsBoss)
        {
            if (stageLevel == (int)GameManager.instance.StageLevel + 1)
            {
                SpawnBoss();
                stageLevel++;
            }
        }
    }

    // 보스 스폰
    private void SpawnBoss()
    {
        GameObject BossClone = Instantiate(bossPrefab[(int)GameManager.instance.StageLevel], new Vector3(0, 2.5f, 0), Quaternion.identity);
        SpawnBossHpSlider(BossClone);
    }

    // 보스 hp slider생성
    private void SpawnBossHpSlider(GameObject boss)
    {
        GameObject sliderClone = Instantiate(bossHpSlider);
        sliderClone.transform.SetParent(canvasTr);
        sliderClone.transform.localScale = Vector3.one;

        // slider에서 보스 위치설정
        sliderClone.GetComponent<BossHpSlider>().SetUp(boss);
    }

}
