using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    float speed;

    void Start()
    {
        Destroy(gameObject, 4);
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
