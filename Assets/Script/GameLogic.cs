using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Sprite[] shape;

   public SpriteRenderer p1;
   public SpriteRenderer p2;

   public SpriteRenderer pawn;

    public Transform pawn_transform;
    private Vector2 init_pawn_position = new Vector2();

    int[] _random_index = new int[2];
    int pawn_sprite_index;
    private void set_random_index()
    {
        _random_index[0] = Random.Range(0, shape.Length);
        _random_index[1] = Random.Range(0, shape.Length);
        pawn_sprite_index = Random.Range(0, _random_index.Length);
    }

    private void set_sprite()
    {
        set_random_index();
        p1.sprite = shape[_random_index[0]];
        p2.sprite = shape[_random_index[1]];

        pawn.sprite = shape[_random_index[pawn_sprite_index]];
    }

    private void init_sprite()
    {
        set_sprite();
        pawn_transform.position = init_pawn_position;
    }

    private void Start()
    {
        init_pawn_position = pawn_transform.position;
        set_sprite();
    }

    private void Update()
    {
        if(FindObjectOfType<Touch_event>().direction() == 1 && pawn_sprite_index == 0)
        {
            init_sprite();
        }else if(FindObjectOfType<Touch_event>().direction() == -1 && pawn_sprite_index == 1)
        {
            init_sprite();
        }
        else
        {
            Debug.Log("gameover");
        }
    }
}
