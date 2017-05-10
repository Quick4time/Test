using UnityEngine;
using System.Collections;

public class CustomTimerTest : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            int numTests = 1000;

            // create a new timer
            using (new CustomTimerOptimiztion("Controlled Test", numTests))
            {
                for (int i = 0; i < numTests; ++i)
                {
                    //TestFunction();
                }
            } // Dispose() is automatically called here, cleaning up the CustomTimer and printing its output
        }
    }

    void TestFunction()
    {
        // count up to 100000, for no good reason
        for (int i = 0; i < 1; ++i)
        {
        }
    }
}
