using UnityEngine;
using System.Collections;

public class Enums : MonoBehaviour {
	

    // ВОЗМОЖНО ДОБАВИТЬ ПРАВИЛЬНОЕ ПЕРЕЧИСЛЕНИЕ.
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Wizzard WizardCollection = Wizzard.FirstCreated;

            if (WizardCollection != null)
            {
                IEnumerator WE = Wizzard.FirstCreated.GetEnumerator();
                while (WE.MoveNext())
                {
                    Debug.Log(((Wizzard)WE.Current).WizardName);
                }
            }
        }
    }
}
