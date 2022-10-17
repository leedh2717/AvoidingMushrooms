using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    TextMeshPro text;
    int damage;
    Color alpha;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
        damage = GameManager.instance.PlayerAttack;
        text.text = damage.ToString();
        alpha = text.color;

        Invoke("DestroyDamageText", 2);

    }

    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * 0.5f;
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * 2);
        text.color = alpha;
    }

    private void DestroyDamageText()
    {
        Destroy(gameObject);
    }

}
