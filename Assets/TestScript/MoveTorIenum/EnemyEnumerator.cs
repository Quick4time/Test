using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyEnumerator : IEnumerator
{

    private enemy CurrentObj = null;

    public bool MoveNext()
    {
        CurrentObj = (CurrentObj == null) ? enemy.FirstCreated : CurrentObj.NextEnemy;
        return (CurrentObj != null);
    }
    public void Reset()
    {
        CurrentObj = null;
    }
    public object Current
    {
        get { return CurrentObj; }
    }
}

