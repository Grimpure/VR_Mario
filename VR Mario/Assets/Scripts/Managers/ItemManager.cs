using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Items
{
    public class ItemManager : MonoBehaviour
    {

        public GameObject item;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                item = null;

                UIManager.Instance.ChangeItem("");
            }
        }

        public void SetItem(GameObject g)
        {
            if (!item)
            {
                StartCoroutine(RouletteCoroutine(g));
            }
        }

        IEnumerator RouletteCoroutine(GameObject newItem)
        {
            if (gameObject.name != "Player")
            {
                yield break;
            }
            if (UIManager.Instance)
            {
                UIManager.Instance.ChangeItem(newItem.name);
            }
            yield return new WaitForSeconds(3);
            item = newItem;
        }
    }
}

