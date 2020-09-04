using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
		DontDestroyOnLoad(GameObject.FindGameObjectWithTag("UI"));
		DontDestroyOnLoad(GameObject.FindGameObjectWithTag("GameController"));
		SceneManager.LoadScene(1);
	}
}
