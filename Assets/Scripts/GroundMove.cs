﻿using UnityEngine;

public class GroundMove : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
