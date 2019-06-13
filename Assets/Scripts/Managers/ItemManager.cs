using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Items
{
    public class ItemManager : MonoBehaviour
    {

        public GameObject item;

        private bool itemActive;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                itemActive = false;
                item = null;
                UIManager.Instance.SetImage(-1);
            }
        }

        public void SetItem(GameObject g)
        {
            if (itemActive == false)
            {
                itemActive = true;
                item = g;
                UIManager.Instance.SetPowerUpImage(g);
            }

        }

    }
}

