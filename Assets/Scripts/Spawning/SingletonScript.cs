using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletonScript : MonoBehaviour
{
	public  static SingletonScript Instance { get; private set; }

	[HideInInspector]
	public int collectionNumber;
	public int Chernobyl;
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}