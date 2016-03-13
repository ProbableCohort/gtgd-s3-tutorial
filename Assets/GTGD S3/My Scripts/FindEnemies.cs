using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

namespace Chapter1
{

    public class FindEnemies : MonoBehaviour
    {

        GameObject[] enemies;

        void SetInitialReferences()
        {

        }

        void Awake()
        {
            Assert.raiseExceptions = true;
            SetInitialReferences();
        }

        void OnEnable()
        {

        }

        // Use this for initialization
        void Start()
        {
            SearchForEnemies();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void SearchForEnemies()
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            Assert.IsNotNull<GameObject[]>(enemies, "No enemies found");

            if (enemies.Length > 0)
            {
                foreach(GameObject e in enemies)
                {
                    Debug.Log("Found enemy " + e.name);
                }

            }
        }
    }

}
