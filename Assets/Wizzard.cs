using UnityEngine;
using System.Collections;

// Страница 212
public class WizardEnumerator : IEnumerator
{
    private Wizzard CurrentObj = null;

    public bool MoveNext()
    {
        CurrentObj = (CurrentObj == null) ? Wizzard.FirstCreated : CurrentObj.NextWizard;

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

[System.Serializable]
public class Wizzard : MonoBehaviour, IEnumerable
{
    public static Wizzard LastCreated = null;

    public static Wizzard FirstCreated = null;

    public Wizzard NextWizard = null;

    public Wizzard PrevWizard = null;

    public string WizardName = "Wizard";

    void Awake()
    {
        if (FirstCreated == null)
            FirstCreated = this;

        if (Wizzard.LastCreated != null)
        {
            Wizzard.LastCreated.NextWizard = this;
            PrevWizard = Wizzard.LastCreated;
        }
        Wizzard.LastCreated = this;
    }

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IEnumerator WE = Wizard.FirstCreated.GetEnumerator();
            while (WE.MoveNext())
            {
                Debug.Log(((Wizard)WE.Current).WizardName);
            }
        }
    }*/

    /*void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Wizard WizardCollection = Wizard.FirstCreated;
            
            if (WizardCollection != null)
            {
                foreach (Wizard W in WizardCollection)
                {
                    Debug.Log(W.WizardName);
                }
            }
        }
    }*/
    void OnDestroy()
    {
        if (PrevWizard != null)
            PrevWizard.NextWizard = NextWizard;

        if (NextWizard != null)
            NextWizard.PrevWizard = PrevWizard;
    }
    public IEnumerator GetEnumerator()
    {
        return new WizardEnumerator();
    }
}
