using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public GameObject textBox; // ссылка на окно диалога

    public TMPro.TextMeshProUGUI theText; // ссылка на текст в канвасе

    public TextAsset textFile; // сам текст проицироваемый на канвас
    public string[] textLines; // сколько линий в тексте

    public int currentLine; // текущая линия (устанавливаем начальную строку) = 0
    public int endAtLine; // последняя линия в строке
    public bool isActive; // Проверка диалогового окна на SetActiv(false/true).

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;

    private void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1; // в тексте 10 линий но так как для компьютера 0 тоже чило мы делаем lenght - 1.
        }
        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }
    }
    private void Update()
    {
        if(!isActive)
        {
            return;
        }

        //theText.text = textLines[currentLine];

        if(Input.GetKeyDown(KeyCode.K)) // при нажатии k мы выводим следующую строку 
        {
            if(!isTyping)
            {
                currentLine += 1;

                if (currentLine > endAtLine) // при выходе за пределы endAtLine мы скрываем диалоговое окно
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if (isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }   

    private IEnumerator TextScroll (string lineOfText) // Корутина печатающая текст look in textMeshPro?
    {
        int letter = 0;
        theText.text = string.Empty;
        isTyping = true;
        cancelTyping = false;
        while(isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        //theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        StartCoroutine(TextScroll(textLines[currentLine]));
    }
    public void DisableTextBox()
    {
        textBox.SetActive(false);
    }

    public void RealoadScript(TextAsset theText) // Метод для использования другого текстового файла
    {
        if(theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}
