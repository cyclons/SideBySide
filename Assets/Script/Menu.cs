using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

	public void StartGame()
    {
        SceneManager.LoadSceneAsync("Scenes/001");
    }
    public void DisPlaySettingsUI()
    {
        transform.Find("Settings").Find("SettingsWin").gameObject.SetActive(true);
    }
    public void ExitGame()
    {
        //Debug.Log("Quiting");
        Application.Quit();
    }
}
