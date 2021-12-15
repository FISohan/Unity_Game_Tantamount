using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class GameLogic : MonoBehaviour
{
    public Sprite[] shape;

   public SpriteRenderer p1;
   public SpriteRenderer p2;

   public SpriteRenderer pawn;

    public TextMeshProUGUI score;
    Gamemaneger gamemaneger;
    public Transform pawn_transform;
    private Vector2 init_pawn_position = new Vector2();

    int[] _random_index = new int[2];
    int pawn_sprite_index = 0;
    int direction = 1;

    private void set_random_index()
    {
        _random_index[0] = Random.Range(0, shape.Length);
        _random_index[1] = Random.Range(0, shape.Length);
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
        set_sprite();
        pawn_transform.position = init_pawn_position;
        gamemaneger.increaseScore(10);
        score.text = gamemaneger.getScore().ToString();
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
            Debug.Log("Gameover!goto hell");
        }
    }

    private void Start()
    {
        gamemaneger = FindObjectOfType<Gamemaneger>();
        init_pawn_position = pawn_transform.position;
        init_sprite();
    }

    private void FixedUpdate()
    {

    }
}
