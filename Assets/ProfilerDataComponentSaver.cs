using UnityEngine;
using System.Text;
using System.Collections;
//Оптимизация Unity - Profiler.Страница 46
public class ProfilerDataComponentSaver : MonoBehaviour {

    int _count = 0;

	void Start () {
        UnityEngine.Profiling.Profiler.logFile = "";
	}
	
	void Update () {
	    if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.H))
        {
            StopAllCoroutines();
            _count = 0;
            StartCoroutine(SaveProfilerData());
        }
	}

    IEnumerator SaveProfilerData()
    {
        while(true)
        {
            string filepath = Application.persistentDataPath + "/profilerLog" + _count;

            UnityEngine.Profiling.Profiler.logFile = filepath;
            UnityEngine.Profiling.Profiler.enableBinaryLog = true;
            UnityEngine.Profiling.Profiler.enabled = true;
            
            for(int i = 0; i < 300; i++)
            {
                yield return new WaitForEndOfFrame();

                if (!UnityEngine.Profiling.Profiler.enabled)
                    UnityEngine.Profiling.Profiler.enabled = true;
            }
            _count++;
        }
    }
}
