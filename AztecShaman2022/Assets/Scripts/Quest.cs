using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HectorRodriguez
{

    public class Quest : MonoBehaviour
    {

        [SerializeField] Item Item;
        private void Start()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Debug.Log("Hit");
                ItemCollected();
                Destroy(gameObject);
            }
        }

        void ItemCollected()
        { 
            Inventory.instance.AddItem(Instantiate(Item));

        }

    }
}