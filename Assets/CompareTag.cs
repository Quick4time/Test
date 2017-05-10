using UnityEngine;
using System.Collections;

public class CompareTag : MonoBehaviour {
    
	void Update () {
        int numTests = 10000000;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < numTests; ++i)
            {
                if (gameObject.tag == "Player")
                {
                    // Делаем что-то.
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < numTests; ++i)
            {
                if (gameObject.CompareTag("Player")) // Исрользуем gameObject.CompareTag("tag") вместо gameObject.tag == "tag".
                {
                    // Делаем что-то.
                }
            }
        }
    }
}
