using UnityEngine;
using UnityEditor;
using System.Collections;

public class BatchRename : ScriptableWizard
{
    // Служит для нумировки обьектов  с одинаковым именем.
    public string BaseName = "MyObject_";
    public int StartNumber = 0;
    public int Inscrement = 1;

    [MenuItem("Edit/Batch Rename...")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Batch Rename", typeof(BatchRename), "Rename");
    }

    void OnEnable()
    {
        UpdateSelectionHelper();
    }
    void OnSelectionChange ()
    {
        UpdateSelectionHelper();
    }
    void UpdateSelectionHelper()
    {
        helpString = "";

        if (Selection.objects != null)
            helpString = "Numbers of objects selected: " + Selection.objects.Length;
    }
    void OnWizardCreate ()
    {
        if (Selection.objects == null)
            return;

        int PostFix = StartNumber;

        foreach (Object O in Selection.objects)
        {
            O.name = BaseName + PostFix;
            PostFix += Inscrement;
        }
    }
}
