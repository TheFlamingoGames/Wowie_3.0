using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Character
{
    int zigzag = 1;
    protected override void PredeterminedMovement()
    {
        if ((Vector2)transform.position == currentPos)
        {
            zigzag *= -1;
            Vector2 newPos = new Vector2(zigzag, 0);
            currentPos += newPos;
        }
    }
}
