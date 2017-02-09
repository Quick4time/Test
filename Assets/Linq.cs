using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// Все это можно прочитать в разделе Linq.

public class Linq : MonoBehaviour {

    void Start ()
    {
        FindEnemiesOldWay();
        NameUp();        
    }

    public void NameUp()
    {
        string searchfemale = @"(?<=\bfemale:)\w+\b";
        string searchmale = @"(?<=\bmale:)\w+\b";
        string CSVData = "male:john, male:tom, male:bob, female:betty, female:jessica, male:dork, female:maria, female:olga, male:peter";
        string [] FemaleNames = (from Match m in Regex.Matches(CSVData, searchfemale) select m.Groups[0].Value).ToArray();
        string[] MaleNames = (from Match m in Regex.Matches(CSVData, searchmale) select m.Groups[0].Value).ToArray();
        string RandomFemaleName = FemaleNames[Random.Range(0, FemaleNames.Length)];
        string RandomMaleName = MaleNames[Random.Range(0, MaleNames.Length)];

        Debug.Log(RandomFemaleName);
        Debug.Log(RandomMaleName);
        /*
        foreach (string M in MaleNames)
        {
            Debug.Log(M);
        }

        foreach (string S in FemaleNames)
        {
            Debug.Log(S);
        } 
        */     
    }

    // Пример с применением linq (Оптимизация).
    public void FindEnemiesOldWay()
    {
        WizardChar[] Enemies = Object.FindObjectsOfType<WizardChar>();
        WizardChar[] FiltredData = (from WizardChar in Enemies where WizardChar.Health <= 50 && WizardChar.Mana <= 11 select WizardChar).ToArray();

        foreach (WizardChar E in FiltredData)
        {
            Destroy(E.gameObject);
        }
    }

    // Перебераем волшебников с определенными параметрами и удаляем их. Но без Linq.
    /*
    public void FindEnemiesOldWay()
    {
        WizardChar[] Enemies = Object.FindObjectsOfType<WizardChar>();
        List<WizardChar> FiltredData = new List<WizardChar>();
        foreach (WizardChar E in Enemies)
        {
            if (E.Health < 50 && E.Mana < 11)
            {
                FiltredData.Add(E);
            }
        }
        foreach (WizardChar E in FiltredData)
        {
            Destroy(E.gameObject);
        }
    }*/
}
