using UnityEngine;
using UnityEngine.SceneManagement;

public class Hacking : MonoBehaviour
{
	public int prisonBreak;
    // Start is called before the first frame update
    void Start()
    {
		SingletonScript.Instance.Chernobyl = prisonBreak;
	}
	private void StartHack()
	{
		SceneManager.LoadScene("Computer");
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.CompareTag("Player") && gameObject.CompareTag("ComputerTag"))
		{
			if(Input.GetButtonDown("Jump"))
			{
				StartHack();
			}
		}
	}
}
