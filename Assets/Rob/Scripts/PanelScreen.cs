using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelScreen : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;




    public void LostGame()
    {
        losePanel.SetActive(true);
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
    }

}
