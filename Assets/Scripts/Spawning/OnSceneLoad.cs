using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnSceneLoad : MonoBehaviour
{
	private void Start()
	{
		if(SceneManager.GetActiveScene().buildIndex == 0)
		{
			Debug.LogWarning("Current scene 0");
		}
		if(SceneManager.GetActiveScene().buildIndex == 1)
		{
			Debug.LogWarning("Current scene 1");
		}
		if(SceneManager.GetActiveScene().buildIndex == 2)
		{
			Debug.LogWarning("Current scene 2");
		}
		if(SceneManager.GetActiveScene().buildIndex == 3)
		{
			Debug.LogWarning("Current scene 3");
		}
		if(SceneManager.GetActiveScene().buildIndex == 4)
		{
			Debug.LogWarning("Current scene 4");
		}
		if(SceneManager.GetActiveScene().buildIndex == 5)
		{
			Debug.LogWarning("Current scene 5");
		}
	}
}
