using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Items
{
    public class PowerUpRandomizer : MonoBehaviour
    {
        GameObject[] bItems;
        public float bRotateSpeed;
        public float bRespawnTime;

        // Start is called before the first frame update
        void Start()
        {
            bItems = GameManager.Instance.bPowerUpPrefabs;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.forward * bRotateSpeed * Time.deltaTime);
        }

        private void Hide()
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;
        }

        private void Show()
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            gameObject.GetComponent<Renderer>().enabled = true;
        }

        void OnTriggerEnter(Collider coll)
        {
            if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Enemy")
            {
                ItemManager itemMgr = coll.gameObject.GetComponentInParent<ItemManager>();

                if (itemMgr)
                {
                    int value = Random.Range(0, bItems.Length);
                    itemMgr.SetItem(bItems[value]);

                }

                Hide();
                StartCoroutine(WaitForRespawn());
            }
        }

        IEnumerator WaitForRespawn()
        {
            yield return new WaitForSeconds(bRespawnTime);
            Show();
        }
    }
}

