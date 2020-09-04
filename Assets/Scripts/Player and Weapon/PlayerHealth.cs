using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public int health;
	bool die = false;
	
	[SerializeField] private Text healthDisplay;
	
	// Start is called before the first frame update
	void Start()
	{
		health = 100;
		healthDisplay = GameObject.Find("Health").GetComponent<Text>();
		healthDisplay.text = health.ToString();
	}

	// Update is called once per frame
	void Update()
	{
		if(health<=0)
		{
			die = true;
			foreach(GameObject o in FindObjectsOfType<GameObject>())
			{
				Destroy(o);
			}
			healthDisplay.text = "0";
			health = 100;
			FindObjectOfType<WeaponReload>().bulletsCarrying = 150;
			FindObjectOfType<WeaponReload>().bulletsInMagazine = 30;
			SceneManager.LoadScene(0);
		}
		if(health > 0)
		{
			StartCoroutine(TakeHit());
		}
	}

	IEnumerator TakeHit()
	{
		if(healthDisplay != null)
		{
			healthDisplay.text = health.ToString();
		}
		yield return null;
	}
}
