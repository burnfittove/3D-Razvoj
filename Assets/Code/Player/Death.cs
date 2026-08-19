using Code.Managers;
using UnityEngine;

public class Death : MonoBehaviour
{
    public void ChangeSceneOnDeath()
    {
        if (!SceneChangeManager.instance) return;
        SceneChangeManager.instance.LoadScene("GAME OVER");
    }
}
