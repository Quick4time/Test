using UnityEngine;
using System.Collections;


public interface IPoolableComponent
{
    void Spawned();
    void Despawned();
}

public class PoolableComponent : MonoBehaviour, IPoolableComponent
{
    public virtual void Spawned()
    {
        Debug.Log(string.Format("Object spawned: {0}", gameObject.name));
    }

    public virtual void Despawned()
    {
        // handle any destruction operations here
        Debug.Log(string.Format("Object despawned: {0}", gameObject.name));
    }

}
