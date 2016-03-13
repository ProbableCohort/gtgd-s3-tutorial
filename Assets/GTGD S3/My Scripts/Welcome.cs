using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Assertions;


namespace Chapter1
{
    public class Welcome : MonoBehaviour
    {
        private string WELCOME = "Welcome!";
        private Text textWelcome;
        public GameObject canvasWelcome;

        void SetInitialReferences()
        {
            textWelcome = GameObject.Find("WelcomeText").GetComponent<Text>();
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
            MyWelcomeMessage();
        }

        // Update is called once per frame
        void Update()
        {

        }

        // Display my welcome message
        void MyWelcomeMessage()
        {
            Assert.IsNotNull<Text>(textWelcome, "textWelcome is null.");
            textWelcome.text = WELCOME;

            StartCoroutine(DisableCanvas(3f));
        }

        IEnumerator DisableCanvas(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            canvasWelcome.SetActive(false);
        }
    }
}
