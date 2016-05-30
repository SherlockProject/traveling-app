using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwipeImage : MonoBehaviour {

    float startX;
    float startX0;
    float startX1;
    float startXm1;
    float deltaX;

    bool dragging;

    // Use this for initialization
    void Start ()
    {
        startX0 = GameObject.Find("BoxContent").GetComponent<RectTransform>().anchoredPosition.x;
        startX1 = GameObject.Find("BoxContent+1").GetComponent<RectTransform>().anchoredPosition.x;
        startXm1 = GameObject.Find("BoxContent-1").GetComponent<RectTransform>().anchoredPosition.x;

        dragging = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(dragging)
        {
            deltaX = Input.mousePosition.x - startX;
            GameObject.Find("IFPlaceholder").GetComponent<Text>().text = "deltaX: " + deltaX.ToString();

            GameObject.Find("BoxContent").GetComponent<RectTransform>().anchoredPosition = new Vector2(startX0 + deltaX, GameObject.Find("BoxContent").GetComponent<RectTransform>().anchoredPosition.y);
            GameObject.Find("BoxContent+1").GetComponent<RectTransform>().anchoredPosition = new Vector2(startX1 + deltaX, GameObject.Find("BoxContent+1").GetComponent<RectTransform>().anchoredPosition.y);
            GameObject.Find("BoxContent-1").GetComponent<RectTransform>().anchoredPosition = new Vector2(startXm1 + deltaX, GameObject.Find("BoxContent-1").GetComponent<RectTransform>().anchoredPosition.y);
        }	
	}

    public void drag ()
    {
        GameObject.Find("IFPlaceholder").GetComponent<Text>().text = "drag";
        startX = Input.mousePosition.x;
        dragging = true;
    }

    public void drop ()
    {
        GameObject.Find("IFPlaceholder").GetComponent<Text>().text = "drop";
        if(deltaX < - 200)
        {
            // swipe to Right
            Sprite tmpsprt = GameObject.Find("BoxContent").GetComponent<Image>().sprite;
            GameObject.Find("BoxContent").GetComponent<Image>().sprite = GameObject.Find("BoxContent+1").GetComponent<Image>().sprite;
            GameObject.Find("BoxContent+1").GetComponent<Image>().sprite = GameObject.Find("BoxContent-1").GetComponent<Image>().sprite;
            GameObject.Find("BoxContent-1").GetComponent<Image>().sprite = tmpsprt;
            newImageDisplayed();
        }

        if(deltaX > 200)
        {
            // swipe to Left
            Sprite tmpsprt = GameObject.Find("BoxContent").GetComponent<Image>().sprite;
            GameObject.Find("BoxContent").GetComponent<Image>().sprite = GameObject.Find("BoxContent-1").GetComponent<Image>().sprite;
            GameObject.Find("BoxContent-1").GetComponent<Image>().sprite = GameObject.Find("BoxContent+1").GetComponent<Image>().sprite;
            GameObject.Find("BoxContent+1").GetComponent<Image>().sprite = tmpsprt;
            newImageDisplayed();
        }

        GameObject.Find("BoxContent").GetComponent<RectTransform>().anchoredPosition = new Vector2(startX0, GameObject.Find("BoxContent").GetComponent<RectTransform>().anchoredPosition.y);
        GameObject.Find("BoxContent+1").GetComponent<RectTransform>().anchoredPosition = new Vector2(startX1, GameObject.Find("BoxContent+1").GetComponent<RectTransform>().anchoredPosition.y);
        GameObject.Find("BoxContent-1").GetComponent<RectTransform>().anchoredPosition = new Vector2(startXm1, GameObject.Find("BoxContent-1").GetComponent<RectTransform>().anchoredPosition.y);

        dragging = false;

    }

    public void newImageDisplayed()
    {
        // Working Package: 
        // INPUT: Image (BoxContent) and .json file containing annotations in that image

        // TASK: Develope an algorithm that displays the information about the image in natural language

        // OUTPUT: Text (TextBox->Text) containing a description of the content of the image
    }
}
