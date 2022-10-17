using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField]
    float speed;
    
    public GameObject effect;

    void Start()
    {
        Destroy(gameObject, 0.95f);
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            GameManager.instance.PlayerAttack += 1;            
            GameManager.instance.Score += 5;
            Instantiate(Resources.Load<GameObject>("Prefabs/Explosion"), collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Mushroom")
        {
            GameManager.instance.PlayerCurrentHp -= 20;
            if (GameManager.instance.PlayerAttack <= 1)
                GameManager.instance.PlayerAttack = 1;
            else
                GameManager.instance.PlayerAttack -= 1;

            Instantiate(Resources.Load<GameObject>("Prefabs/Explosion"), collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Boss")
        {
            GameManager.instance.BossCurrentHp -= GameManager.instance.PlayerAttack;
            GameManager.instance.Score += 2;

            Instantiate(Resources.Load<GameObject>("Prefabs/Explosion"), collision.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("Prefabs/DamageText"), collision.transform.position + Vector3.up, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator Explosion(GameObject go)
    {
        GameObject explosion = Instantiate(Resources.Load<GameObject>("Prefabs/Explosion"), go.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(explosion.gameObject);
    }
}


