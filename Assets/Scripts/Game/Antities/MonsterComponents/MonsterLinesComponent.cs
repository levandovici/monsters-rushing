using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Monster))]
public class MonsterLinesComponent : MonoBehaviour, Move.IBounce
{
    private Monster _monster;

    private Move.ELineInfo _lineInfo = Move.ELineInfo.stay;
    private int _road = 0;
    [SerializeField]
    private bool _doNotRebound = false;



    private void Awake()
    {
        _monster = GetComponent<Monster>();
        _road = (int)transform.position.x / 5;
    }



    public void Rebound()
    {
        if(!_doNotRebound)
        {
        if (_lineInfo == Move.ELineInfo.toLeft)
        {
            ChangeLineRight();
        }
        else if (_lineInfo == Move.ELineInfo.toRight)
        {
            ChangeLineLeft();
        }
        else
        {
            int b = UnityEngine.Random.Range(0, 2);

            if (b == 0)
            {
                if (CanChangeLeft())
                {
                    ChangeLineLeft();
                }
                else
                {
                    ChangeLineRight();
                }
            }
            else
            {
                if (CanChangeRight())
                {
                    ChangeLineRight();
                }
                else
                {
                    ChangeLineLeft();
                }
            }
        }
        }
        else _doNotRebound = false;
    }

    public void DoNotRebound()
    {
        _doNotRebound = true;
    }


    private bool CanChangeLeft()
    {
        return _road > Move.FirstLineID;
    }

    private bool CanChangeRight()
    {
        return _road < Move.LastLineID;
    }

    public void ChangeLineLeft()
    {
        if (CanChangeLeft())
        {
            _road--;
            _lineInfo = Move.ELineInfo.toLeft;
            StopAllCoroutines();
            StartCoroutine(ChangeLine());
        }
    }

    public void ChangeLineRight()
    {
        if (CanChangeRight())
        {
            _road++;
            _lineInfo = Move.ELineInfo.toRight;
            StopAllCoroutines();
            StartCoroutine(ChangeLine());
        }
    }



    private IEnumerator ChangeLine()
    {
        Vector3 velocity = Vector3.zero;


        while (Vector3.Distance(transform.position, new Vector3(_road * Move.CellSize,
         transform.position.y, transform.position.z)) > 0.1f)
        {
            Vector3 to = new Vector3(_road * Move.CellSize, transform.position.y, transform.position.z);

            transform.position = Vector3.SmoothDamp(transform.position, to,
             ref velocity, Time.smoothDeltaTime, _monster.MoveSpeed * 2f);

            yield return null;
        }


        transform.position = new Vector3(_road * Move.CellSize, transform.position.y, transform.position.z);
        _lineInfo = Move.ELineInfo.stay;
    }
}