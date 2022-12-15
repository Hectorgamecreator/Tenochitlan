using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HectorRodriguez
{

    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float CharacterSpeed = 1.0f;
        private Vector2 InputDir;
       

        public Rigidbody2D PlayerPhysics;


        //adding this
        [SerializeField]
        private InventoryUi inventoryUi;


       
        // collect references
       private void Awake()
        {

            PlayerPhysics = GetComponent<Rigidbody2D>();


        }
        private void Start()
        {
           // Cursor.lockState = CursorLockMode.Locked;
           // Cursor.visible = false;
        }


        public void SlowDown()
        {
            CharacterSpeed = 0.5f;
        }

        public void Normalspeed()
        {

            CharacterSpeed = 1.0f;
            } 
        private void Update()
        {

            if (!inventoryUi.InventoryOpen)
            {
            }

            float VertInput = Input.GetAxis("Vertical");
            float HorInput = Input.GetAxis("Horizontal");
            InputDir = new Vector2(HorInput, VertInput).normalized;

        }

        void FixedUpdate()
        {

            Vector2 WhereAmI = PlayerPhysics.position;
            Vector2 WhereTo = WhereAmI + (InputDir * CharacterSpeed) * Time.fixedDeltaTime;
            PlayerPhysics.MovePosition(WhereTo);


        }

    }
}