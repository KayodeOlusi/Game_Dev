using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearColorPiece : ClearablePiece
{

    private ColorPiece.ColorType color;

    public ColorPiece.ColorType Color
    {
        get { return color; }
        set { color = value; }
    }

    public override void Clear()
    {
        base.Clear();

        piece.GridRef.ClearColor(color);
    }
}
