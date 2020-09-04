using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public Transform firePoint;
    public LineRenderer lineRenderer;
    public int damage = 20;
    public float offset;
	WeaponReload wr;
	AudioSource audioSource;


	private void Start()
    {
        Physics2D.queriesStartInColliders = false;
		wr = FindObjectOfType<WeaponReload>();
		audioSource = gameObject.GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
//        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position;
//        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
//        firePoint.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
//        
        if (Input.GetButtonDown("Fire1"))
        {
			if(wr.bulletsCarrying > wr.minBulletCarring || wr.bulletsInMagazine > wr.minBulletInMagazine)
			{
				StartCoroutine(Shoot());
			}
        }
		if(wr.bulletsInMagazine == wr.minBulletInMagazine && wr.bulletsCarrying > wr.minBulletCarring)
		{
			wr.Reload();
		}

    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);

			audioSource.clip = GetComponent<WeaponReload>().weaponSounds[1];
			audioSource.Play();
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right *100);
			audioSource.Stop();
        }

        lineRenderer.enabled = true;

        yield return new WaitForSeconds(0.1f);
        
        lineRenderer.enabled = false;

		wr.bulletsInMagazine--;

    }
}
