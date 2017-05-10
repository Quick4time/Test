using System.Collections;
using UnityEngine;
// Сценарий PlatformTest с примером кода, привязанного к платформе(В каждом случае запускается свой вариант кода!).
public class PlatformTest : MonoBehaviour
{
    private void OnGUI()
    {
#if UNITY_EDITOR // Этот раздел запускается только в редакторе.
        GUI.Label(new Rect(10, 10, 200, 20), "Running in Editor");
#elif UNITY_STANDALONE // Только в приложениях для рабочего стола/автономных приложениях.
       GUI.Label(new Rect(10, 10, 200, 20), "Running on Desktop");
#else
       GUI.Label(new Rect(10, 10, 200, 20), "Running on other platform");
#endif
    }
}
// Примеры всех платформ https://docs.unity3d.com/ru/current/Manual/PlatformDependentCompilation.html
