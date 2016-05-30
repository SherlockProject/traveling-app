using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class AskPhotoScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        loadPhoto();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void backToMenu()
    {
        SceneManager.LoadScene("intro");
    }

    public void loadPhoto()
    {
        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(Application.persistentDataPath + "/" + "DublinTempPicture.png"))
        {
            fileData = File.ReadAllBytes(Application.persistentDataPath + "/" + "DublinTempPicture.png");
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        Sprite sp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        GameObject.Find("BoxContent").GetComponent<Image>().sprite = sp;
    }

    public void recognizeObjects()
    {
        // INPUT: Image (BoxContent)

        // Task: Using an Object Recognition API (e.g. of IBM Bluemix service, Google Reverse/Similar image search, or what you can find), try to get some keywords about the photo made a second ago.
        //       These Keywords will guide the travel App into a conversation about the image in the next step.

        // OUTPUT: Text (TextBox->Text)
    }

}
