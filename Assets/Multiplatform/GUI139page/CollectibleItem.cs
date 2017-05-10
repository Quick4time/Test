using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
   [SerializeField]
    private string itemName;


     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Managers.Inventory.AddItem(itemName);
            Destroy(this.gameObject);
        }
    }

}
