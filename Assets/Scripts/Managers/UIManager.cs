using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {

        private static UIManager instance;

        public static UIManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<UIManager>();
                }

                return instance;
            }

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public Sprite[] preFabSprites;
        public Sprite defaultSprite;
        public Image image;

        int currentImage;

        public void SetPowerUpImage(GameObject g)
        {
            SetImage(ImageValue(g));
        }

        public int ImageValue(GameObject g)
        {
            currentImage = -1;

            for (int i = 0; i < preFabSprites.Length; i++)
            {
                if (g.name == preFabSprites[i].name)
                {
                    currentImage = i;
                }
            }
            return currentImage;
        }

        public void SetImage(int index)
        {
            float timer = 0.5f;

            if(index == -1)
            {
                image.sprite = defaultSprite;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int o = index; o < preFabSprites.Length; o++)
                    {
                        image.sprite = preFabSprites[o];
                        StartCoroutine(Wait(timer));
                        timer = timer + 0.2f;
                    }
                }
                
                image.sprite = preFabSprites[index];
            }
        }

        private IEnumerator Wait(float f)
        {
            yield return new WaitForSeconds(f);
        }

    }
}

