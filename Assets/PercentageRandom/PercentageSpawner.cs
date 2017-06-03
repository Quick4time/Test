using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Спаун обьектов взависимости от "веса" GO
public class PercentageSpawner : MonoBehaviour
{
    // Here's where we define our weighted object structure,
    // and flag it Serializable so it can be edited in the Inspector.
    [System.Serializable]
    public struct Spawnable
    {
        public GameObject gameObject;
        public float weight;
    }

    // Now expose an array of these to be populated in the Inspector.
    public Spawnable[] spawnList;

    // Track the total weight used in the whole array.
    float _totalSpawnWeight;

    // Update the total weight when the user modifies Inspector properties,
    // and on initialization at runtime.
    private void OnValidate()
    {
        _totalSpawnWeight = 0.0f;
        foreach (var spawnable in spawnList)
            _totalSpawnWeight += spawnable.weight;
    }
    // As Problematic points out below, OnValidate isn't called
    // in a built executable. But in that case we don't need to react
    // to a user fiddling with the Inspector mid-game, so it suffices
    // to run this code once during Awake:
    private void Awake()
    {
        OnValidate();
    }
    // Spawn an item randomly, according to the relative weights.
    public void Spawn()
    {
        // Generate a random position in the list.
        float pick = Random.value * _totalSpawnWeight;
        int chosenIndex = 0;
        float cumulativeWeight = spawnList[0].weight;

        // Step through the list until we've accumulated more weight than this.
        // The length check is for safety in case rounding errors accumulate.
        while (pick > cumulativeWeight && chosenIndex < spawnList.Length - 1)
        {
            chosenIndex++;
            cumulativeWeight += spawnList[chosenIndex].weight;
        }

        // Spawn the chosen item.
        Instantiate(spawnList[chosenIndex].gameObject, transform.position, transform.rotation);
    }
}
