using UnityEngine;

public class Weapon : MonoBehaviour
{
	public GameObject bulletPrefab;
	public int ammo;
	public int maxAmmo = 10;
	private bool isReloading;
	public bool isAutoFire;
	public float fireInterval = 0.5f;
	public float fireCoolDown;
    
    void Update()
	{
		if (!isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
		{
			Shoot();        
		}

		if (isAutoFire && Input.GetKey(KeyCode.Mouse0))
		{
			Shoot();
		}

		if (Input.GetKeyDown(KeyCode.R) && ammo < maxAmmo)
		{
			Reload();
		}

		fireCoolDown -= Time.deltaTime;
	}

	public void Shoot()
    {
		if (isReloading) return;
		if (ammo <= 0)
		{
			Reload();
			return;
		}
		if (fireCoolDown > 0) return;

		ammo--;
		fireCoolDown = fireInterval;
		Instantiate(bulletPrefab, transform.position, transform.rotation);
	}	
	
	async public void Reload()
    {
		
		if (isReloading) return;
		isReloading = true;

		await new WaitForSeconds(2f);

		ammo = maxAmmo;
		isReloading = false;
		print("Reloaded");
    }
}