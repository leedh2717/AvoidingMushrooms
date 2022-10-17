using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHpSlider : MonoBehaviour
{
    Vector3 distance = Vector3.up * 200.0f;
    Transform BossTr;
    RectTransform rectTr;

    Slider hpSlider;
    
    public void SetUp(GameObject target)
    {
        BossTr = target.transform;
        rectTr = GetComponent<RectTransform>();

        hpSlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {           
        if (BossTr == null)
        {
            Destroy(gameObject);
            return;
        }        

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(BossTr.position);
        rectTr.position = screenPosition + distance;        
        hpSlider.value = (float)GameManager.instance.BossCurrentHp / GameManager.instance.BossHp;
    }
}
