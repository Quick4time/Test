using UnityEngine;
using System.Collections;

public class ManualMouse : MonoBehaviour
{

    private void Update()
    {
        ScreenMouseRay();
    }
    public void ScreenMouseRay()
    {
        bool bIntersected = false;
        bool bButtonDown = false;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 5f;

        Vector2 v = Camera.main.ScreenToWorldPoint(mousePosition);

        Collider2D[] col = Physics2D.OverlapPointAll(v);

        if (col.Length > 0)
        {
            foreach (Collider2D c in col)
            {
                if (!bIntersected)
                {
                    Debug.Log("Enter");
                }
                bIntersected = true;
                if (!bButtonDown && Input.GetMouseButton(0))
                {
                    bButtonDown = true;
                    Debug.Log("On Button Down");
                }
                if (c.gameObject.CompareTag("Player")) // для столкновения определенного коллайдера.
                {
                    print("collide with player");
                }
                /*
                if (bButtonDown && !Input.GetMouseButton(0))
                {
                    if (bIntersected)
                    {
                        Debug.Log("Exit");
                    }
                    bIntersected = false;
                    bButtonDown = false;

                }*/
            }
            //yield return null;
        }
    }
}
