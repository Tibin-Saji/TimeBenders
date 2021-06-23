using UnityEngine.SceneManagement;
using UnityEngine;

public class StartPageManager : MonoBehaviour
{
    public GameObject HelpPanel;
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void HelpButton()
    {
        HelpPanel.SetActive(true);
    }

    public void BackButton()
    {
        HelpPanel.SetActive(false);
    }
}
