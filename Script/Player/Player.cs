using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public bool LeftMove { get; set; }
    public bool RightMove { get; set; }

    public PlayerController playerController;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    Slider playerHpSlider;
    [SerializeField]
    Text playerAttackText;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        GameManager.instance.PlayerHp = 100;
        GameManager.instance.PlayerCurrentHp = GameManager.instance.PlayerHp;
        GameManager.instance.PlayerAttack = 1;

    }

    private void Update()
    {
        if (LeftMove || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            playerController.LeftArrowDown();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            playerController.LeftArrowUp();
        }

        if (RightMove || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            playerController.RightArrowDown();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            playerController.RightArrowUp();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerController.AttackBtnDown();
        }

        playerHpSlider.value = (float)GameManager.instance.PlayerCurrentHp / GameManager.instance.PlayerHp;
        playerAttackText.text = GameManager.instance.PlayerAttack.ToString();

        if (GameManager.instance.PlayerCurrentHp <= 0)
            Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 음식에 닿았을 때
        if (collision.gameObject.tag == "Food")
        {
            GameManager.instance.Score += 5;
            if (GameManager.instance.PlayerCurrentHp >= 90)
                GameManager.instance.PlayerCurrentHp = 100;
            else
                GameManager.instance.PlayerCurrentHp += 10;
            Destroy(collision.gameObject);
        }

        // 버섯에 닿았을 때
        if (collision.gameObject.tag == "Mushroom")
        {
            if (GameManager.instance.PlayerCurrentHp <= 30)
            {
                GameManager.instance.PlayerCurrentHp = 0;
            }                
            else
                GameManager.instance.PlayerCurrentHp -= 30;
            Destroy(collision.gameObject);
        }

    }

    private void PlayerDie()
    {
        Destroy(gameObject);
    }

}
