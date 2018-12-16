using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchObject : MonoBehaviour {

    public GameObject main;
    public GameObject scan;
    public GameObject rules;
    public GameObject hints;

    public GameObject ModelsText;


    // Use this for initialization
    void Start()
    {
        main.SetActive(true);
        rules.SetActive(false);
        scan.SetActive(false);
        hints.SetActive(false);

        ModelsText.SetActive(false);
    }

        // Update is called once per frame
        void Update()
    {

        if ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.A))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (EventSystem.current.IsPointerOverGameObject(0)) return;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                print("1");
                if (hit.transform.tag == "Monument")
                {
                    print("2");
                    hit.transform.gameObject.GetComponent<Animator>().SetTrigger("Rotate");
                }


            }
        }
    }

    public void goToExit()
    {
        // save any game data here
       #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
       #else
                 Application.Quit();
      #endif
    }

    public void goToExplore()
    {
            scan.SetActive(true);
            main.SetActive(false);
            rules.SetActive(false);
            hints.SetActive(false);

           ModelsText.SetActive(true);
    }

    public void goToRules()
    {
        print("d");
        scan.SetActive(false);
        main.SetActive(false);
        rules.SetActive(true);
        hints.SetActive(false);

        ModelsText.SetActive(false);
    }

    public void goToHint()
    {
        scan.SetActive(false);
        main.SetActive(false);
        rules.SetActive(false);
        hints.SetActive(true);

        ModelsText.SetActive(false);
    }
    public void backToMain()
    {
        scan.SetActive(false);
        main.SetActive(true);
        rules.SetActive(false);
        hints.SetActive(false);

        ModelsText.SetActive(false);
    }

    public void backToScan()
    {
        scan.SetActive(true);
        main.SetActive(false);
        rules.SetActive(false);
        hints.SetActive(false);


        ModelsText.SetActive(true);
    }

}
