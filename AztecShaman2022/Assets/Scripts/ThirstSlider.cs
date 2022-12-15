using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HectorRodriguez
{
    public class ThirstSlider : MonoBehaviour
    {
        public Slider Thirstbar;
        [SerializeField] PlayerController PlayerController;

        public static float Thirst;
        float maxThirst = 100f;

        // Start is called before the first frame update
        void Start()
        {

            Thirst = maxThirst;
        }

        // Update is called once per frame
        void Update()
        {
            Thirstbar.value = Thirst;

            if (Thirst >= 0)
            {
                Thirst -= 1f * Time.deltaTime;

                if (Input.GetKey(KeyCode.W))
                {
                    Thirst -= 2f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    Thirst -= 2f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    Thirst -= 2f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Thirst -= 2f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    Thirst -= 2f * Time.deltaTime;
                }

                if (Thirst <= 0)
                {
                    PlayerController.SlowDown();
                }
                else if (Thirst >= 1)
                {

                    PlayerController.Normalspeed();
                }
            }
        }
    }
}