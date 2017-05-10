using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPoolingComponent : MonoBehaviour, IPoolableComponent
{
    [SerializeField]
    Rigidbody2D rb2d;
    bool rb2dactive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2dactive = !rb2dactive;
            if (rb2dactive)
            {

                //Debug.Log("RB2D activ is: " + rb2dactive.ToString());
            }
            else if (!rb2dactive)
            {
                Despawned();
                //Debug.Log("RB2D activ is: " + rb2dactive.ToString());
            }
        }
    }

    public virtual void Spawned()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.zero;
        rb2d.angularVelocity = 0;
        rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
        Debug.Log(string.Format("Object spawned: {0}", gameObject.name));
    }
    public virtual void Despawned()
    {
        Destroy(rb2d, 2.0f);
        Debug.Log(string.Format("Object despawned: {0}", gameObject.name));
    }
}