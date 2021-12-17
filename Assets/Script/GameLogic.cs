using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLogic : MonoBehaviour
{
    public Sprite[] shape;

   public SpriteRenderer p1;
   public SpriteRenderer p2;

   public SpriteRenderer pawn;

    public Transform pawn_transform;
    private Vector2 init_pawn_position = new Vector2();

    int[] _random_index = new int[2];
    int pawn_sprite_index = 0;
    int direction = 1;

    bool b1 = true;

    public TextMeshProUGUI score;
    //Gamemaneger gamemaneger;

    private void Start()
    {
        init_pawn_position = pawn_transform.position;
     //   gamemaneger = FindObjectOfType<Gamemaneger>();
        init_sprite();
    }

    private void set_random_index()
    {
        int r1 = Random.Range(0, shape.Length);
        int r2 = Random.Range(0, shape.Length);

        _random_index[0] = r1 == r2 ? Random.Range(0, 2) : r1;
        _random_index[1] = r1 == r2 ? Random.Range(shape.Length - 2, shape.Length) : r2;
        pawn_sprite_index = Random.Range(0, _random_index.Length);
        direction = pawn_sprite_index == 0 ? -1 : 1;
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
        b1 = true;
        set_sprite();
        pawn_transform.position = init_pawn_position;

        FindObjectOfType<Gamemaneger>().increaseScore(10);
        score.text = FindObjectOfType<Gamemaneger>().getScore().ToString();
        FindObjectOfType<Pawn_movement>().increaseSpeed(0.05f);

    }

    public void pawnMove(int dir)
    {
        if(direction == dir)
        {
            init_sprite();
        }
        else
        {
            FindObjectOfType<Gamemaneger>().gameover();
        }
    }



    private void FixedUpdate()
    {

    }
}
