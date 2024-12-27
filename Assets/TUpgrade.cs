using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class TUpgrade : MonoBehaviour
{
    // public static int score = 50;
    // [SerializeField] Text scoreText;
    //[SerializeField] Button upgradeButton;
    [SerializeField] private GameObject Turret1b;
    [SerializeField] private GameObject Turret1c;
    [SerializeField] private GameObject Turret1d;

    private TurretInfoUI updateUI;
    //public static bool canUpgrade;

    public OrderedDictionary  Turrets = new OrderedDictionary()
    {
        {"Turret 1a", 0},
        {"Turret 1b", 20},
        {"Turret 1c", 30},
        {"Turret 1d", 40},
    };
    
    void Start()
    {
        //score = 50;
        //upgradeButton.onClick.AddListener(EnabledUpgradeMode);
        updateUI = FindObjectOfType<TurretInfoUI>();

    }
    
    void Update()
    {
        // scoreText.text = "Score: " + score;
        // if(canUpgrade) CheckUpgradeTurret();
        
    }

    void EnabledUpgradeMode()
    {
        //canUpgrade = true;
         //CheckUpgradeTurret();
    }

    // void CheckUpgradeTurret()
    // {
    //     //Debug.Log("Checking Upgrade Turret" + canUpgrade);
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         //Debug.Log("got ray");
    //         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //         if (Physics.Raycast(ray, out RaycastHit hit))
    //         {
    //             //Debug.Log(hit.collider.gameObject.name);
    //             GameObject selectedTurret = hit.collider.gameObject;
    //             if (selectedTurret.CompareTag("Turret"))
    //             {
    //                 //Debug.Log("Selected Turret" + selectedTurret.name);
    //                 UpgradeTurret(selectedTurret);
    //                 
    //             }
    //         }
    //     }
    //     
    // }

    public void UpgradeTurret(GameObject currentTurret)
    {
        Debug.Log("Upgrade Turret");
        string CurrentTurretName = currentTurret.name.Replace("(Clone)", "").Trim();
        int currentIndex = -1;
        List<string> keys = new List<string>();
        foreach (var key in Turrets.Keys)
        {
            keys.Add(key.ToString());
        }
        currentIndex = keys.IndexOf(CurrentTurretName);

        if (currentIndex != -1 && currentIndex < keys.Count)
        {
            string nextTurretName = keys[currentIndex+1];
            int nextTurretCost = (int)Turrets[nextTurretName];

            if (CastleAttack.score >= nextTurretCost)
            {
                CastleAttack.score -= nextTurretCost;
                ReplaceTurret(currentTurret, nextTurretName);
                Debug.Log(currentTurret.name);
                nextTurretName += "(Clone)";
                GameObject nextTurret = GameObject.Find(nextTurretName);
                
                updateUI.ShowPannel(nextTurret.GetComponent<Attack>());
            }
            else Debug.Log("Недостаточно очков для улучшения");
        }
        else Debug.Log("Турель не может быть улучшена");
        
        //canUpgrade = false;
    }

    void ReplaceTurret(GameObject currentTurret, string newTurretName)
    {
        GameObject newTurret = null;
        switch (newTurretName)
        {
            case "Turret 1b": newTurret = Turret1b; break;
            case "Turret 1c": newTurret = Turret1c; break;
            case "Turret 1d": newTurret = Turret1d; break;
        }

        if (newTurret != null)
        {
            Instantiate(newTurret, currentTurret.transform.position, currentTurret.transform.rotation);
            Destroy(currentTurret);
            
        }
    }
}
