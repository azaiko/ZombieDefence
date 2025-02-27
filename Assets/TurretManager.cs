using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public List<GameObject> turrets = new List<GameObject>();

    public void UpgradeTurret(GameObject turret)
    {
        var turretUpgrade = turret.GetComponent<TUpgrade>();
        if (turretUpgrade != null)
        {
            turretUpgrade.UpgradeTurret(turret);
        }
    }
}
