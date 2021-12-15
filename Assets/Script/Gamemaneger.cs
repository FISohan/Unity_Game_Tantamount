using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemaneger : MonoBehaviour
{
    private int score = 0;
    public void increaseScore(int s)
    {

        score += s;
    }

    public int getScore() => score;
}
