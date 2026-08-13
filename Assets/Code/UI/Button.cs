using Code.Managers;
using UnityEngine;

public class Button : MonoBehaviour
{
    public string nextScene;

    public void ChangeScene()
    {
        if (!SceneChangeManager.instance)
        {
            Debug.LogError("SceneChangeManager not found in scene!");
            return;
        }
        SceneChangeManager.instance.LoadScene(nextScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ContinueFromCheckpoint()
    {
        
    }
}
