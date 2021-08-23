using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelScreen : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;
    public Button button;
    
    
    void Start () {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(PlayAgain);
    }





    public void LostGame()
    {
        losePanel.SetActive(true);
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
