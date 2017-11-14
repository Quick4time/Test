using UnityEngine;
using System.Collections;

public class ChildCount : MonoBehaviour {

        void Start()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Debug.Log(transform.GetChild(i).name);
            }
        }
}
