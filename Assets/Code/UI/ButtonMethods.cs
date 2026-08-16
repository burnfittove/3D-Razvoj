using Code.Managers;
using UnityEngine;

public class ButtonMethods : MonoBehaviour
{
    public string nextScene;
    
    public void ChangeScene(Transform nextSceneLocation)
    {
        var playerCharacter = GameObject.FindGameObjectWithTag("Player");
        if (!SceneChangeManager.instance)
        {
            Debug.LogError("SceneChangeManager not found in scene!");
            return;
        }

        if (!playerCharacter)
        {
            Debug.LogError("PlayerCharacter not found in scene!");
            return;
        }
        
        SceneChangeManager.instance.AddObjectPosition(playerCharacter, nextSceneLocation.position);
        SceneChangeManager.instance.LoadScene(nextScene);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadFromCheckpoint()
    {
        if (!SaveDataManager.Instance)
        {
            Debug.LogError("SaveDataManager not found in scene!");
            return;
        }
        
        Debug.Log("1", this);
        SaveDataManager.Instance.LoadCheckpoint();
    }
}
