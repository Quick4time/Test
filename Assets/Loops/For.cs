using UnityEngine;
using System.Collections;

public class For : MonoBehaviour {

    // Массив игровых обьектов в сцене.
    public GameObject[] MyObjects;
    
	void Start () {
        StartCoroutine(YieldTest());
        /*// Обходит обьекты в обратном направлянии, один за другим.
	    for(int i = MyObjects.Length-1; i >= 0; i--)
        {
            // Уничтожает обьекты.
            Destroy(MyObjects[i]);
        }
        //Обходит обьекты в поочереди, один за другим.
        for (int i = MyObjects.Length - 4; i <= 3; i++)
        {
            // Уничтожает обьекты.
            Destroy(MyObjects[i]);
        }
        
        // пример for поочереди.
        for (int i = 0; i <= 4; i++)
        {
            print("Hello" + i);
        }
        // пример for обратном направлянии.
        for (int i = 4; i >= 0; i--)
        {
            print("Hello" + i);
        }*/
    }

    private IEnumerator LoopFunction(float waitTime)
    {
        while(true)
        {
            Debug.Log("print.");
            yield return new WaitForSeconds(waitTime);
            Debug.Log("print1.");
        }
    }
    private IEnumerator InfiniteLoop()
    {
        WaitForSeconds waitTime = new WaitForSeconds(2);
        while (true)
        {
            Debug.Log("print.");
            yield return waitTime;
        }
    }
    private IEnumerator YieldTest()
    {
        gotoTest:// пример использования goTo
        //Debug.Log("lol");
        while(true)
        {
            yield return new WaitForSeconds(2.0f);
            goto gotoTest; // пример использования goTo
        }
    }
}
//GOTO Examples
/*
public class GotoTest1
{
    static void Main()
    {
        int x = 200, y = 4;
        int count = 0;
        string[,] array = new string[x, y];

        // Initialize the array:
        for (int i = 0; i < x; i++)

            for (int j = 0; j < y; j++)
                array[i, j] = (++count).ToString();

        // Read input:
        Console.Write("Enter the number to search for: ");

        // Input a string:
        string myNumber = Console.ReadLine();

        // Search:
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                if (array[i, j].Equals(myNumber))
                {
                    goto Found;
                }
            }
        }

        Console.WriteLine("The number {0} was not found.", myNumber);
        goto Finish;

        Found:
        Console.WriteLine("The number {0} is found.", myNumber);

        Finish:
        Console.WriteLine("End of search.");


        // Keep the console open in debug mode.
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
class SwitchTest
{
    static void Main()
    {
        Console.WriteLine("Coffee sizes: 1=Small 2=Medium 3=Large");
        Console.Write("Please enter your selection: ");
        string s = Console.ReadLine();
        int n = int.Parse(s);
        int cost = 0;
        switch (n)
        {
            case 1:
                cost += 25;
                break;
            case 2:
                cost += 25;
                goto case 1;
            case 3:
                cost += 50;
                goto case 1;
            default:
                Console.WriteLine("Invalid selection.");
                break;
        }
        if (cost != 0)
        {
            Console.WriteLine("Please insert {0} cents.", cost);
        }
        Console.WriteLine("Thank you for your business.");

        // Keep the console open in debug mode.
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}*/
