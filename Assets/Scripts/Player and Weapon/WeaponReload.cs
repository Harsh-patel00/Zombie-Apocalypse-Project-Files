using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponReload : MonoBehaviour
{
	public int bulletsInMagazine;
	public int bulletsCarrying;
	private int _maxBulletsInMagazine;
	private int _maxBulletsCarrying;
	public int minBulletCarring;
	public int minBulletInMagazine;

	private int _temp;

	[SerializeField] public AudioClip[] weaponSounds;
	AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
		minBulletInMagazine = 0;
		_maxBulletsInMagazine = 30;
		minBulletCarring = 0;
		_maxBulletsCarrying = 150;
		bulletsInMagazine = _maxBulletsInMagazine;
		bulletsCarrying = _maxBulletsCarrying;

		audioSource = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(KeyCode.R))
		{
			Reload();
		}
		DisplayAmmo();
    }

	public void Reload()
	{
		if(bulletsCarrying > minBulletCarring)
		{
			StartCoroutine(reloadSound());

			_temp = bulletsCarrying;
			if(bulletsInMagazine < 30)
			{
				bulletsCarrying -= (_maxBulletsInMagazine - bulletsInMagazine);
				if(bulletsCarrying <= minBulletCarring)
				{
					bulletsInMagazine += _temp;
					bulletsCarrying = minBulletCarring;
				}
				else
				{
					bulletsInMagazine = _maxBulletsInMagazine;
				}
			}
			if(bulletsInMagazine == 0)
			{
				audioSource.clip = weaponSounds[2];
				audioSource.Play();
				bulletsCarrying -= _maxBulletsInMagazine;
				bulletsInMagazine = _maxBulletsInMagazine;
			}
			else
			{
				Debug.Log("No need to reload :') ");
			}
		}
		else
		{
			Debug.Log("No ammo !");
		}
	}

	IEnumerator reloadSound()
	{
		audioSource.clip = weaponSounds[0];
		audioSource.Play();

		yield return new WaitForSeconds(10);
	}

	public void DisplayAmmo()
	{
		GameObject.Find("Ammo Text").GetComponent<Text>().text = bulletsInMagazine + " / " + bulletsCarrying;
	}
}
