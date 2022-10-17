using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foods;
    public GameObject[] mushrooms;

    bool isFoodSpawn = true;
    bool isMushroomSpawn = true;

    int randomLevelCount;

    float mushroomSpeed;

    public StageManager stage;

    [SerializeField]
    StagePhase stagePhase;
    [SerializeField]
    StageLevel stageLevel;
    

    void Start()
    {
    }

    void Update()
    {
        GameSpawnerSetting();
    }

    private void GameSpawnerSetting()
    {
        stageLevel = GameManager.instance.StageLevel;
        stagePhase = GameManager.instance.StagePhase;

        // 스테이지 레벨에 따른 설정값 셋팅
        switch (stageLevel)
        {
            case StageLevel.Level1:
                randomLevelCount = 2;
                mushroomSpeed = 5.0f;
                break;
            case StageLevel.Level2:
                randomLevelCount = 4;
                mushroomSpeed = 5.5f;
                break;
            case StageLevel.Level3:
                randomLevelCount = 6;
                mushroomSpeed = 6.0f;
                break;
            case StageLevel.Level4:
                randomLevelCount = 8;
                mushroomSpeed = 6.5f;
                break;
            case StageLevel.Level5:
                randomLevelCount = 10;
                mushroomSpeed = 7.0f;
                break;
        }

        // 스테이지 페이즈 설정
        if (stagePhase == StagePhase.Phase1)
        {
            if (isFoodSpawn)
                StartCoroutine(FoodSpawn(1, randomLevelCount));
            if (isMushroomSpawn)
                StartCoroutine(MushroomSpawn1(2, mushroomSpeed, randomLevelCount));
        }
        if (stagePhase == StagePhase.Phase2)
        {
            if (isFoodSpawn)
                StartCoroutine(FoodSpawn(1, randomLevelCount));
            if (isMushroomSpawn)
                StartCoroutine(MushroomSpawn2(2f, mushroomSpeed, randomLevelCount));
        }
        if (stagePhase == StagePhase.Phase3)
        {
            if (isFoodSpawn)
                StartCoroutine(FoodSpawn(4, randomLevelCount));
            if (isMushroomSpawn)
                StartCoroutine(MushroomSpawn3(2f, mushroomSpeed, randomLevelCount));
        }
    }

    // 음식 스포너
    IEnumerator FoodSpawn(float time, int randomCount)
    {
        isFoodSpawn = false;

        float posRandomNum = Random.Range(-2.46f, 1.57f);

        int foodRandomNum = Random.Range(0, randomCount);

        Instantiate(foods[foodRandomNum], new Vector3(posRandomNum, 5.3f, 0), Quaternion.identity);
        yield return new WaitForSeconds(time);

        isFoodSpawn = true;
    }

    // 버섯 스포너1
    IEnumerator MushroomSpawn1(float time, float speed, int randomCount)
    {
        isMushroomSpawn = false;

        float posRandomNum = Random.Range(-2.46f, 1.57f);

        int mushroomRandomNum = Random.Range(0, randomCount);

        GameObject mushroomPrefab = Instantiate(mushrooms[mushroomRandomNum], new Vector3(posRandomNum, 5.3f, 0), Quaternion.identity);
        mushroomPrefab.GetComponent<Mushroom>().Speed = speed;
        yield return new WaitForSeconds(time);

        isMushroomSpawn = true;
    }

    // 버섯 스포너2
    IEnumerator MushroomSpawn2(float time, float speed, int randomCount)
    {
        isMushroomSpawn = false;

        float posRandomNum1 = Random.Range(-2.46f, -0.44f);
        float posRandomNum2 = Random.Range(0.04f, 1.57f);

        int mushroomRandomNum1 = Random.Range(0, randomCount);
        int mushroomRandomNum2 = Random.Range(0, randomCount);

        GameObject mushroomPrefab1 = Instantiate(mushrooms[mushroomRandomNum1], new Vector3(posRandomNum1, 5.3f, 0), Quaternion.identity);
        mushroomPrefab1.GetComponent<Mushroom>().Speed = speed;

        yield return new WaitForSeconds(time / 2);

        GameObject mushroomPrefab2 = Instantiate(mushrooms[mushroomRandomNum2], new Vector3(posRandomNum2, 5.3f, 0), Quaternion.identity);
        mushroomPrefab2.GetComponent<Mushroom>().Speed = speed;

        yield return new WaitForSeconds(time / 2);

        isMushroomSpawn = true;
    }

    // 버섯 스포너3
    IEnumerator MushroomSpawn3(float time, float speed, int randomCount)
    {
        isMushroomSpawn = false;

        float posRandomNum1 = Random.Range(-2.46f, -1.24f);
        float posRandomNum2 = Random.Range(-0.76f, 0.65f);
        float posRandomNum3 = Random.Range(1.13f, 1.57f);

        int mushroomRandomNum1 = Random.Range(0, randomCount);
        int mushroomRandomNum2 = Random.Range(0, randomCount);
        int mushroomRandomNum3 = Random.Range(0, randomCount);

        GameObject mushroomPrefab1 = Instantiate(mushrooms[mushroomRandomNum1], new Vector3(posRandomNum1, 5.3f, 0), Quaternion.identity);
        mushroomPrefab1.GetComponent<Mushroom>().Speed = speed;
        yield return new WaitForSeconds(time / 3);

        GameObject mushroomPrefab2 = Instantiate(mushrooms[mushroomRandomNum1], new Vector3(posRandomNum2, 5.3f, 0), Quaternion.identity);
        mushroomPrefab2.GetComponent<Mushroom>().Speed = speed;
        yield return new WaitForSeconds(time / 3);

        GameObject mushroomPrefab3 = Instantiate(mushrooms[mushroomRandomNum1], new Vector3(posRandomNum3, 5.3f, 0), Quaternion.identity);
        mushroomPrefab3.GetComponent<Mushroom>().Speed = speed;
        yield return new WaitForSeconds(time / 3);

        isMushroomSpawn = true;
    }

}
