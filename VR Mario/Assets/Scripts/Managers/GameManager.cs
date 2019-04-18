using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {

        private static GameManager instance;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<GameManager>();
                }

                return instance;
            }

        }

        public GameObject[] bPowerUpPrefabs;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public int GetItemIndex(string str)
        {
            for (int i = 0; i < bPowerUpPrefabs.Length; i++)
                if (str == bPowerUpPrefabs[i].name)
                    return i;
            return -1;
        }
    }
}

