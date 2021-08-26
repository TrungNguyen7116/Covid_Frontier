using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Super : Covid
{
    private void Update()
    {
        if (circleRange.CheckRange())
        {
            base.Action();
            Action();
        }
        else
        {
            acting = false;
            Moverment();
        }
    }
    public override void Action()
    {
        if (!acting)
        {
            acting = true;
        }
    }
}
