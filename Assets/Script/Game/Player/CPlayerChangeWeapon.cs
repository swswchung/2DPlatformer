using UnityEngine;
using System.Collections;

public class CPlayerChangeWeapon : MonoBehaviour {

    public GameObject[] Weapons;
    bool _isPickUpPistol = false;
    bool _isPickUpShotGun = false;
	// Update is called once per frame
	void Update () {
        ChangeWeapon();
    }

    void PickUpGun(string gunName)
    {
        SendMessage("EffectSound", 2);
        if (gunName.Equals("Pistol"))
        {
            _isPickUpPistol = true;
            PlayerPrefs.SetInt("SavePistol", 1);
        }
        if(gunName.Equals("ShotGun"))
        {
            _isPickUpShotGun = true;
            PlayerPrefs.SetInt("SaveShotGun", 1);
        }
    }

    void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _isPickUpPistol)//1번 권총
        {
            for(int i = 0 ; i < Weapons.Length ; i++)
            {
                if (Weapons[i].name == "Pistol")
                {
                    SendMessage("EffectSound", 2);
                    Weapons[i].SetActive(true);
                }
                else
                {
                    Weapons[i].SetActive(false);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && _isPickUpShotGun)//1번 권총
        {
            for (int i = 0; i < Weapons.Length; i++)
            {
                if (Weapons[i].name == "ShotGun")
                {
                    SendMessage("EffectSound", 2);
                    Weapons[i].SetActive(true);
                }
                else
                {
                    Weapons[i].SetActive(false);
                }
            }
        }
    }
}
