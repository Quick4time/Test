using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextManager theTextBox;

    public bool requireButtonPress;

    [SerializeField]
    private bool waitForPresss;

    public bool destroyWhenActivated;

    private void Start()
    {
        theTextBox = FindObjectOfType<TextManager>();
    }

    private void Update()
    {
        if (waitForPresss && Input.GetKeyDown(KeyCode.J)) // Нажатием кнопки запускаем новые строки текста в диалоговой панели и waitForPress = true
        {
            theTextBox.RealoadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;
            theTextBox.EnableTextBox();
        }

        if (requireButtonPress) // // если допустим входим в триггер диалогового окна
        {
            waitForPresss = true;
            return;
        }
        
        /*
        if (destroyWhenActivated)
        {
            Destroy(gameObject);
        }
        */

        if (Input.GetKeyDown(KeyCode.Space)) // если допустим выходим из триггера диалогового окна
        {
            waitForPresss = false;
        }
    }
}
