using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn_movement : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    public Transform denger_position;

    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime*speed);
        game_over();
    }

    private bool has_destroy()
    {
        if (Mathf.FloorToInt(Vector2.Distance(denger_position.position, transform.position)) == 0) return true;
        return false;
    }
    private void game_over()
    {
        if (has_destroy())
        {
            Debug.Log("gameover");
            Destroy(gameObject, 0.8f);
        }
    }
}
