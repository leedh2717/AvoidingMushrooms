using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float Speed { get; set; }

    void Start()
    {
        Destroy(gameObject, 4);
    }

    void Update()
    {
        transform.position += Vector3.down * Speed * Time.deltaTime;
    }
}
