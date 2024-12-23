using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretInfoUI : MonoBehaviour
{
    public GameObject UpdateUI;

    public TMP_Text damage;

    public TMP_Text attackRate;

    public TMP_Text attackRange;

    private Upgrade currentTurret;
    
    // Start is called before the first frame update
    void Start()
    {
        //UpdateUI.SetActive(false);
    }

    public void ShowPannel(Attack turret)
    {
        
        damage.text = "Damage: " + turret.attackDamage;
        attackRate.text = "Attack rate: " + turret.attackRate;
        attackRange.text = "Attack range: " + turret.attackRange;
        
        UpdateUI.SetActive(true);
        
    }

    

    public void HideInfo()
    {
        UpdateUI.SetActive(false);
    }
}
