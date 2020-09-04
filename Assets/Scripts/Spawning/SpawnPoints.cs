using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoints : MonoBehaviour
{
	[Tooltip("Enter the build index of the scene (You can find the build index in File -> Build Settings)")]
	public int sceneToLoad;

	private void OnTriggerStay2D(Collider2D other)
	{
		if (Input.GetButtonDown("Jump"))
		{
			Debug.Log("Input madi gayu che");
			if (SceneManager.GetActiveScene().buildIndex == 2)
			{
				Debug.Log("Errorroroorror");
				if (GameObject.Find("Image_Q").transform.GetChild(0).gameObject.activeInHierarchy)
                {
                    DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MainCamera"));
					GameObject.Find("Comp").transform.GetComponent<BoxCollider2D>().enabled = false;
					SceneManager.LoadScene(sceneToLoad);
                }
				else
				{
					Debug.Log("Collect Quest Item First !");
				}
			}
			if (SceneManager.GetActiveScene().buildIndex == 3)
			{
				if (GameObject.Find("Image_Q").transform.GetChild(1).gameObject.activeInHierarchy)
				{
					DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MainCamera"));
					GameObject.Find("Comp").transform.GetComponent<BoxCollider2D>().enabled = false;
					SceneManager.LoadScene(sceneToLoad);
				}
				else
				{
					Debug.Log("Collect Quest Item First !");
				}
			}
			if (SceneManager.GetActiveScene().buildIndex == 4)
			{
				if (GameObject.Find("Image_Q").transform.GetChild(2).gameObject.activeInHierarchy)
				{
					DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MainCamera"));
					SceneManager.LoadScene(sceneToLoad);
				}
				else
				{
					Debug.Log("Collect Quest Item First !");
				}
			}
		}
	}
}
