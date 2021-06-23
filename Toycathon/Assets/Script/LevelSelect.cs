using UnityEngine.SceneManagement;

using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public void LoadScene(int lvlNo)
    {
        if (lvlNo > 1)
            return; // As only one level is done yet
        SceneManager.LoadScene(lvlNo + 2);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(0);
    }
}
