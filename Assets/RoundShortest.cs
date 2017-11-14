using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class RoundShortest : MonoBehaviour {

    double value = 1234567890;

	void Start ()
    {
        // Результат 1,234,567,890
        print(value.ToString("#,#")); // зачем тогда нужен CultureInfo.InvariantCulture ???
        // Результат 1,234,568K
        print(value.ToString("#,##0,K"));
        // Результат 1,235M
        print(value.ToString("#,##0,,M"));
        // Результат 1B
        print(value.ToString("#,##,,,B"));
    }
}
