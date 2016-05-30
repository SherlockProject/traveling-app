using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

/*
using IBM.Watson.DeveloperCloud.Services.SpeechToText.v1;
using IBM.Watson.DeveloperCloud.Services.TextToSpeech.v1;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Utilities;
using IBM.Watson.DeveloperCloud.UnitTests;
using IBM.Watson.DeveloperCloud.Editor;
using IBM.Watson.DeveloperCloud.Widgets;
*/



public class MainScript : MonoBehaviour {

    GameObject voiceButton;
    GameObject widgets;

    public InputField conversationLog;
    public InputField userInput; // = GameObject.Find("InputField").GetComponent<InputField>();

    public GameObject micWidget; // = GameObject.Find("MicWidget");
    public GameObject speechToTextWidget; // = GameObject.Find("SpeechToTextWidget");
    public GameObject speechDisplayWidget; //= GameObject.Find("SpeechDisplayWidget");
    public GameObject textToSpeechWidget; //= GameObject.Find("TextToSpeechWidget");

    // Use this for initialization
    void Start () {

        voiceButton = GameObject.Find("SendVoice");

        
        micWidget.SetActive(false);
        speechToTextWidget.SetActive(false);
        speechDisplayWidget.SetActive(false);
        textToSpeechWidget.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        
        // this is a clever idea :>
        // voice/text button switch:
        if (GameObject.Find("IFText").GetComponent<Text>().text.Length == 0)
            voiceButton.SetActive(true);
        else
            voiceButton.SetActive(false);

	}

    
    public void sendText()
    {
        //send your question to test box
        
        micWidget.SetActive(false);
        speechToTextWidget.SetActive(false);
        speechDisplayWidget.SetActive(false);
        
        //put user input on conversation log.

        conversationLog.text = GameObject.Find("IFText").GetComponent<Text>().text;

        //delete user input
        userInput.text = "";

        TextToSpeech();

        // INPUT: Submitted Text (InputField->Text), Category (ClassifyText()) and perhaps chat history

        // Task: Using preferably the Dialog system of IBM Bluemix, constitute a conversation in natural language with the travel app.

        // OUTPUT: Text (TextBox->Text)


    }

    

    public void goToPhotoScript()
    {
        SceneManager.LoadScene("makePhoto");
    }


    public void goToMaps()
    {
        SceneManager.LoadScene("Maps");
    }

    public void recordAudio()
    {
        //GameObject.Find("IFPlaceholder").GetComponent<Text>().text = "start";
        //AudioSource aud = GetComponent<AudioSource>();
        //aud.clip = Microphone.Start("", true, 10, 44100);
    }

    public void endRecordAudio()
    {
        
        //GameObject.Find("IFPlaceholder").GetComponent<Text>().text = "end";
        //Microphone.End("");
        //GetComponent<AudioSource>().Play();
    }

    private Type[] m_TestsAvailable = null;

    public void SpeechToText()
    {

        micWidget.SetActive(true);
        speechToTextWidget.SetActive(true);
        speechDisplayWidget.SetActive(true);
        

        //I do not use this method since ibm built in widget can be tagged with button directory.
        //nevertheless, following way should also be worked out.

        /*
        Debug.Log("jei");

        TestTextToSpeech ttts = new TestTextToSpeech();
        UnitTestManager tm = new UnitTestManager();

        if (m_TestsAvailable == null)
            m_TestsAvailable = Utility.FindAllDerivedTypes(typeof(UnitTest));

        tm.QueueTest(m_TestsAvailable[6], true);
        */

        //RunTest();
        // INPUT: Audio sequence (GetComponent<AudioSource>())

        // Task: Parse the audio sequence (e.g. via IBM Bluemix STT module) and return the converted text version of the input.
        //       This will represent an alternative version of chatting.

        // OUTPUT: Text
    }

    public void TextToSpeech()
    {

        textToSpeechWidget.SetActive(true);
        
        //textToSpeechWidget.GetComponent<TextToSpeechWidget>();
        //textToSpeechWidget.GetComponent<textToSpeech>()

        // same with speech to text, you can implement in a following way. However, I found a nice widget 
        // to 

        /*
        TestTextToSpeech ttts = new TestTextToSpeech();
        UnitTestManager tm = new UnitTestManager();

        if (m_TestsAvailable == null)
            m_TestsAvailable = Utility.FindAllDerivedTypes(typeof(UnitTest));

        tm.QueueTest(m_TestsAvailable[7], true);
        */

    }
    

    public string ClassifyText()
    {
        // INPUT: Text (InputField->Text)

        // Task: Use the IBM Natural Language Classifier to make a guess in which category a users query fits (e.g. hotel, restaurant, sightseeing, ... )
        //       This information will be used internally and passed to the Dialog system

        // OUTPUT: return String of the best guess
        return null;
    }
}
