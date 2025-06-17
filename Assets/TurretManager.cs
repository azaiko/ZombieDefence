using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{

    public void UpgradeTurret(GameObject turret)
    {
        var turretUpgrade = turret.GetComponent<TUpgrade>();
        if (turretUpgrade != null)
        {
            turretUpgrade.UpgradeTurret(turret);
        }
    }
}
