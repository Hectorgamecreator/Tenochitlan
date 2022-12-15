using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HectorRodriguez
{

    public class GameManager : MonoBehaviour
    {
        #region singleton
        public static GameManager instance;
        private void Awake()
        {
            if (instance == null)
                instance = this;
        }
        #endregion

        public List<Item> itemList = new List<Item>();
        public List<Item> craftingRecipes = new List<Item>();

        public Transform canvas;
        public GameObject itemInfoPrefab;
        private GameObject currentItemInfo = null;

        public Transform mainCanvas;
        public Transform hotbarTransform;
        public Transform inventoryTransform;

        [SerializeField] PlayerController PlayerController;
        public Slider Thirstbar;
        public static float Thirst;


        private void Start()
        {

        }
        private void Update()
        {


        }

        public void OnStatItemUse(StatItemType itemType, int amount)
        {
            if (ThirstSlider.Thirst <= 50)
            {
                ThirstSlider.Thirst += 50f;
                //Destroy(gameObject);
            }
            Debug.Log("Consuming " + itemType + " Add amount: " + amount);
        }

        public void DisplayItemInfo(string itemName, string itemDescription, Vector2 buttonPos)
        {
            if (currentItemInfo != null)
            {
                Destroy(currentItemInfo.gameObject);
            }

            buttonPos.x -= 180;
            buttonPos.y += 100;

            currentItemInfo = Instantiate(itemInfoPrefab, buttonPos, Quaternion.identity, canvas);
            currentItemInfo.GetComponent<ItemInfo>().SetUp(itemName, itemDescription);
        }

        public void DestroyItemInfo()
        {
            if (currentItemInfo != null)
            {
                Destroy(currentItemInfo.gameObject);
            }
        }

    }
}
