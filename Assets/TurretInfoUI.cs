using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretInfoUI : MonoBehaviour
{
    [SerializeField] private GameObject UpdateUI;

    public TMP_Text damage;

    public TMP_Text attackRate;

    public TMP_Text attackRange;

    public GameObject selectedTurret;
    

    public void ShowPannel(Attack turret)
    {
        selectedTurret = turret.gameObject;
        damage.text = "Damage: " + turret.attackDamage;
        attackRate.text = "Attack rate: " + turret.attackRate;
        attackRange.text = "Attack range: " + turret.attackRange;
        
        UpdateUI.SetActive(true);
        
    }

    public void UpdateTurret()
    {
        if (selectedTurret != null)
        {
            TUpgrade turretUp = selectedTurret.GetComponent<TUpgrade>();
            turretUp.UpgradeTurret(selectedTurret);
        }
    }

    public void HideInfo()
    {
        UpdateUI.SetActive(false);
    }
}
