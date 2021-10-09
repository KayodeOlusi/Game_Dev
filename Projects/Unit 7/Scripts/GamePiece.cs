using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    public int score;

    private int x;
    private int y;

    public int X
    {
        get { return x; }
        set
        {
            if (isMovable())
            {
                y = value;
            }
        }
    }

    public int Y
    {
        get { return y; }
        set
        {
            if (isMovable())
            {
                x = value;
            }
        }
    }

    private Grid.PieceType type;

    public Grid.PieceType Type
    {
        get { return type; }
    }

    private Grid grid;

    public Grid GridRef
    {
        get { return grid; }
    }

    public void Init(int _x, int _y, Grid _grid, Grid.PieceType _type)
    {
        x = _x;
        y = _y;
        grid = _grid;
        type = _type;
    }


    public void OnMouseEnter()
    {
        grid.EnterPiece(this);
    }

    public void OnMouseDown()
    {
        grid.PressPiece(this);
    }

    public void OnMouseUp()
    {
        grid.ReleasePiece();
    }

    private MovablePiece movableComponent;

    public MovablePiece MovableComponent
    {
        get { return movableComponent; }
    }

    private ColorPiece colorComponent;

    public ColorPiece ColorComponent
    {
        get { return colorComponent; }
    }

    private ClearablePiece clearableComponent;

    public ClearablePiece ClearableComponent {
        get { return clearableComponent; }
    }

    void Awake()
    {
        movableComponent = GetComponent<MovablePiece>();
        colorComponent = GetComponent<ColorPiece>();
        clearableComponent = GetComponent<ClearablePiece>();
    }

    void Start()
    {

    }

    public bool isMovable()
    {
        return movableComponent != null;
    }

    public bool IsColored()
    {
        return colorComponent != null;
    }

    public bool IsClearable()
    {
        return clearableComponent != null;
    }
}
