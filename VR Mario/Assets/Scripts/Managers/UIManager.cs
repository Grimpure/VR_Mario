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

        public Image bItemImage;
        public Sprite[] bItemSprites;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeItem(string s)
        {
            if (bItemImage)
            {
                StartCoroutine(ItemImageCoroutine(GameManager.Instance.GetItemIndex(s)));
            }
        }

        IEnumerator ItemImageCoroutine(int index)
        {
            /*if (itemImage == null)
                yield break;
            if (index == -1)
            {
                itemImage.sprite = defaultSprite;
                yield break;
            }

            AudioManager.Instance.PlayRoulette();

            int count = 20;
            float time = 1;
            for (int i = 0; i < count; i++)
            {
                if (itemImage == null)
                    yield break;
                itemImage.sprite = itemSprites[i % itemSprites.Length];
                yield return new WaitForSeconds(time / count);
            }
            for (int i = 0; i < count; i++)
            {
                if (itemImage == null)
                    yield break;
                itemImage.sprite = itemSprites[i % itemSprites.Length];
                yield return new WaitForSeconds((time / count) * 2);
            }
            if (itemImage == null)
                yield break;
            itemImage.sprite = itemSprites[index];
            AudioManager.Instance.PlayGotItem();*/

            if (index == -1)
            {
                bItemImage.sprite = null;
                yield break;
            }

            yield return new WaitForEndOfFrame();
            bItemImage.sprite = bItemSprites[index];

        }
    }
}

