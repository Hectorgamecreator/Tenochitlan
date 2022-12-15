using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HectorRodriguez
{
    

    public class CollisionController : MonoBehaviour
    {
        private TilemapRenderer tilemapRenderer;

        public bool showcollision = false;


        // Start is called before the first frame update
        void Start()
        {
            tilemapRenderer = GetComponent<TilemapRenderer>();
            tilemapRenderer.enabled = showcollision;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}