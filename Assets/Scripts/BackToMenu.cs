using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {
    public void backToMenu()
    {
        SceneManager.LoadScene("intro");
    }
}
