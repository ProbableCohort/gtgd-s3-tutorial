using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

namespace Chapter1
{

    public class Shoot : MonoBehaviour
    {
        private float fireRate = 0.3f;
        private float nextFire;
        private RaycastHit hit;
        private float range = 300;
        private Transform fireTransform;

        void SetInitialReferences()
        {
            Assert.IsNotNull<Transform>(transform, "Transform is null");
            fireTransform = transform;
        }

        void Awake()
        {
            Assert.raiseExceptions = true;
            SetInitialReferences();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            CheckForInput();
        }

        void CheckForInput()
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                Ray shot = new Ray(fireTransform.position, fireTransform.forward);

                Debug.DrawRay(shot.origin, shot.direction, Color.green, 3);
                if (Physics.Raycast(shot, out hit, range))
                {
                    if (hit.transform.CompareTag("Enemy"))
                    {
                        Debug.Log("Hit " + hit.transform.name);
                    }
                }
                nextFire = Time.time + fireRate;
                // Debug.Log("Fire");

            }
        }
    }

}
