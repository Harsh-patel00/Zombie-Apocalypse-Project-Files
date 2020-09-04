using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
	[Tooltip("Enter the build index of the scene (You can find the build index in File -> Build Settings)")]
	public int sceneToLoad;

	private void Start()
	{
		GameObject.Find("UI").transform.GetChild(2).gameObject.SetActive(true);
		GameObject.Find("HandD").transform.Find("Dialogue").gameObject.SetActive(false);
		GameObject.Find("HandD").transform.Find("Health Panel").gameObject.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		GameObject.Find("HandD").transform.Find("Dialogue").gameObject.SetActive(true);
		GameObject.Find("HandD").transform.Find("Health Panel").gameObject.SetActive(true);
		GameObject.Find("UI").transform.GetChild(2).gameObject.SetActive(false);
		SceneManager.LoadScene(sceneToLoad);
	}
}