using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PhotoScript : MonoBehaviour {

	// Use this for initialization

    public RawImage rawimage;
    public WebCamTexture wct;
    
    void Start()
    {
        rawimage = GameObject.Find("BoxContent").GetComponent<RawImage>();
        wct = new WebCamTexture();
        rawimage.texture = wct;
        rawimage.material.mainTexture = wct;
        wct.Play();
    }

    
    public void TakePhoto()
    {

        Texture2D photo = new Texture2D(wct.width, wct.height);
        photo.SetPixels(wct.GetPixels());
        wct.Stop();
        photo.Apply();

        System.IO.File.WriteAllBytes(Application.persistentDataPath + "/" + "DublinTempPicture.png", photo.EncodeToPNG());
        GameObject.Find("PhotoButton").GetComponent<AudioSource>().Play();

        SceneManager.LoadScene("askPhoto");
    }

    public void backToMenu()
    {
        wct.Stop();

        SceneManager.LoadScene("intro");
    }

}
