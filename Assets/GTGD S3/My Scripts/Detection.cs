using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using Chapter1;

namespace Chapter1
{
    public class Detection : MonoBehaviour {

        private RaycastHit hit;
        private LayerMask detectionLayer;
        private List<Layer> layers = new List<Layer>();
        private float range = 500;
        private float checkRate = 0.5f;
        private float nextCheck;
        private Transform fireTransform;

        void SetInitialReferences()
        {
            Assert.IsNotNull<Transform>(transform, "Transform is null");
            fireTransform = transform;
            SetLayers();
        }

        void SetLayers()
        {
            Debug.Log(detectionLayer);
            layers.Add(new Layer("itemsLayer", 10));
            layers.Add(new Layer("enemiesLayer", 9));
            foreach (Layer l in layers)
            {
                detectionLayer = detectionLayer | 1 << l.bit;
            }
            Debug.Log(detectionLayer);
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
        void Start ()
        {

        }
	
	    // Update is called once per frame
	    void Update () {
            DetectItems();
	    }

        void DetectItems()
        {
            if (Time.time > nextCheck)
            {
                Ray shot = new Ray(fireTransform.position, fireTransform.forward);
                if (Physics.Raycast(shot, out hit, range, detectionLayer))
                {
                    Debug.Log(hit.transform.name + " is a in Layer " + LayerMask.LayerToName(hit.transform.gameObject.layer));
                }
                nextCheck = Time.time + checkRate;
            }
        }
    }

}
