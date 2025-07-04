using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

public class TUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject Turret1b;
    [SerializeField] private GameObject Turret1c;
    [SerializeField] private GameObject Turret1d;

    private TurretInfoUI updateUI;

    public OrderedDictionary  Turrets = new OrderedDictionary()
    {
        {"Turret 1a", 0},
        {"Turret 1b", 20},
        {"Turret 1c", 30},
        {"Turret 1d", 40},
    };
    
    void Start()
    {
        updateUI = FindObjectOfType<TurretInfoUI>();

    }
    

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

            if (GameManager.instance.currentScore >= nextTurretCost)
            {
                GameManager.instance.AddScore(-nextTurretCost);
                ReplaceTurret(currentTurret, nextTurretName);
                Debug.Log(currentTurret.name);
                nextTurretName += "(Clone)";
                GameObject nextTurret = GameObject.Find(nextTurretName);
                
                updateUI.ShowPannel(nextTurret.GetComponent<Attack>());
            }
            else Debug.Log("Недостаточно очков для улучшения");
        }
        else Debug.Log("Турель не может быть улучшена");
        
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
