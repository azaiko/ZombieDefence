using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretSpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject TurretPrefab;

    [SerializeField]
    private float spawnRadius = 2f;

    private int fturretCost = 10;

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() || Upgrade.canUpgrade)
        {
            return; 
        }
        if (Input.GetMouseButtonDown(0) && !Upgrade.canUpgrade) SpawnTurret();
        
        
        
    }

    void SpawnTurret()
    {
        
            //Debug.Log(Upgrade.canUpgrade);
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                
                
                Collider[] colliders = Physics.OverlapSphere(hit.point, spawnRadius);

                bool canSpawn = true;

                
                foreach (Collider collider in colliders)
                {
                    if (collider.gameObject.CompareTag("Turret") || collider.gameObject.CompareTag("TownHall"))  
                    {
                        canSpawn = false;  
                        break;
                    }
                }

                if (canSpawn)
                {
                    if (fturretCost <= Upgrade.score)
                    {
                        GameObject objectToCreate = Instantiate(TurretPrefab, hit.point, Quaternion.identity);
                        objectToCreate.name = "Turret 1a";
                        Upgrade.score -= fturretCost;
                    }
                      
                }
                else
                {
                    Debug.Log("Турель не может быть размещена в этой области, так как уже есть турель");
                }
            }
        }
}