using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercentageScr : MonoBehaviour
{
    // Код на шанс выпадения двух рандомных чисел с какой либо вероятностью.
    struct RandomSelection
    {
        private int minValue;
        private int maxValue;
        public float probability;

        public RandomSelection (int minValue, int maxValue, float probability)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.probability = probability;
        }

        public int GetValue() { return Random.Range(minValue, maxValue + 1); }
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            int random = GetRandomValue(new RandomSelection(4, 8, 0.8f)); // Выпадает числа в диапозоне от 4(любое минимальное число) до 5(любое максимальное числр) с вероятностью в 80 %.
            if (random > 0)
            {
                string s = string.Format("Deal {0} damage (its just a test {1}).", random, 2.0f);
                Debug.Log(s);
            }
            else
            {
                Debug.Log("Miss");
            }
            
        }
    }

    int GetRandomValue(params RandomSelection[] selections)
    {
        float rand = Random.value;
        float currentProb = 0;

        foreach (var selection in selections)
        {
            currentProb += selection.probability;
            if (rand <= currentProb)
                return selection.GetValue();
        }
        //will happen if the input's probabilities sums to less than 1
        //throw error here if that's appropriate
        return 0;
    }
}
