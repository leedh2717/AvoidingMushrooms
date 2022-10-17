using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject stone;

    [SerializeField]
    Player player;

    bool isAttack = true;

    public void LeftArrowDown()
    {
        player.RightMove = false;
        player.LeftMove = true;
        player.animator.SetBool("isRun", true);
    }

    public void LeftArrowUp()
    {
        player.LeftMove = false;
        player.animator.SetBool("isRun", false);
    }

    public void RightArrowDown()
    {
        player.LeftMove = false;
        player.RightMove = true;
        player.animator.SetBool("isRun", true);
    }

    public void RightArrowUp()
    {
        player.RightMove = false;
        player.animator.SetBool("isRun", false);
    }

    public void AttackBtnDown()
    {
        StartCoroutine(Attack());        
    }

    IEnumerator Attack()
    {
        if (isAttack)
        {
            isAttack = false;
            Instantiate(stone, player.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            isAttack = true;           
        }
        
    }

}
