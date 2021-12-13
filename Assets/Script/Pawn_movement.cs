using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn_movement : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    public GameObject[] pawns;

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime*speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOver();
    }

    private void gameOver()
    {
        Destroy(gameObject,0.5f);
    }
}
