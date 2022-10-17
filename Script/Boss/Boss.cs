using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    void Start()
    {
        switch (GameManager.instance.StageLevel)
        {
            case Define.StageLevel.Level1:
                GameManager.instance.BossHp = 500;
                GameManager.instance.BossCurrentHp = GameManager.instance.BossHp;
                break;
            case Define.StageLevel.Level2:
                GameManager.instance.BossHp = 1500;
                GameManager.instance.BossCurrentHp = GameManager.instance.BossHp;
                break;
            case Define.StageLevel.Level3:
                GameManager.instance.BossHp = 3000;
                GameManager.instance.BossCurrentHp = GameManager.instance.BossHp;
                break;
            case Define.StageLevel.Level4:
                GameManager.instance.BossHp = 5000;
                GameManager.instance.BossCurrentHp = GameManager.instance.BossHp;
                break;
            case Define.StageLevel.Level5:
                GameManager.instance.BossHp = 100000000;
                GameManager.instance.BossCurrentHp = GameManager.instance.BossHp;
                break;
        }
        
    }

    void Update()
    {
        if (GameManager.instance.BossCurrentHp <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.IsBoss = false;
            if (GameManager.instance.StageLevel != Define.StageLevel.Level5)
            {
                GameManager.instance.StageLevel += 1;
            }
            
            switch (GameManager.instance.StageLevel)
            {
                case Define.StageLevel.Level1:
                    GameManager.instance.Score += 1000;
                    break;
                case Define.StageLevel.Level2:
                    GameManager.instance.Score += 2000;
                    break;
                case Define.StageLevel.Level3:
                    GameManager.instance.Score += 3000;
                    break;
                case Define.StageLevel.Level4:
                    GameManager.instance.Score += 4000;
                    break;
                case Define.StageLevel.Level5:
                    GameManager.instance.Score += 5000;
                    break;
            }
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            GameManager.instance.BossCurrentHp -= GameManager.instance.PlayerAttack;
            switch (GameManager.instance.StageLevel)
            {
                case Define.StageLevel.Level1:
                    GameManager.instance.Score += 2;
                    break;
                case Define.StageLevel.Level2:
                    GameManager.instance.Score += 3;
                    break;
                case Define.StageLevel.Level3:
                    GameManager.instance.Score += 4;
                    break;
                case Define.StageLevel.Level4:
                    GameManager.instance.Score += 5;
                    break;
                case Define.StageLevel.Level5:
                    GameManager.instance.Score += 6;
                    break;
            }
            
            Destroy(collision.gameObject);
        }
    }

}
