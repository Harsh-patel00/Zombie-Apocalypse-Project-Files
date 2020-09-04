using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{
	public void ContinuePlay()
    {
		foreach(GameObject o in FindObjectsOfType<GameObject>())
		{
			Destroy(o);
		}
		SceneManager.LoadScene(0);
    }

    public void ExitPlay()
    {
        Application.Quit();
    }
}
