using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelLerping : MonoBehaviour {


    public GameObject Monument;
    public GameObject TeleportModel;
    Vector3 ModelStartPos;
    public Vector3 ModelEndPos;

    public GameObject ScanIcon;

    // Use this for initialization
    void Start() {

        TeleportModel.SetActive(false);
        ModelStartPos = Monument.transform.localPosition;
        Monument.GetComponent<Animator>().enabled = false;
        ScanIcon.SetActive(true);
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnTrackFound()
    {
        TeleportModel.SetActive(true);
        ScanIcon.SetActive(false);
        StartCoroutine("WaitForGreen");

    }
    public void OnTrackLost()
    {
        Monument.GetComponent<Animator>().enabled = false;
        ScanIcon.SetActive(true);
    }


    IEnumerator WaitForGreen()
    {
        yield return new WaitForSeconds(2f);
        Monument.transform.localPosition = ModelStartPos;
        Monument.SetActive(true);
        StartCoroutine(MoveObject(ModelStartPos, ModelEndPos));
    }

    IEnumerator MoveObject(Vector3 startPos, Vector3 endPos)
    {
        float progress = 0.0f;
        float speed = 1f;

        while (progress < 1.0f)
        {
            Monument.transform.localPosition = Vector3.Lerp(startPos, endPos, progress);

            yield return new WaitForSeconds(0.1f);
            progress += Time.deltaTime * speed;
        }
        Monument.transform.localPosition = endPos;   
        StartCoroutine("WaitForObject");
    }

    IEnumerator WaitForObject()
    {
        yield return new WaitForSeconds(2f);
        TeleportModel.SetActive(false);
        Monument.GetComponent<Animator>().enabled = true;
    }
}
