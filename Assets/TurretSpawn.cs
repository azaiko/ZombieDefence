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
            bool canSpawn = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                
                GameObject hitObject = hit.collider.gameObject;
                if (hitObject.tag == "TurretFloor")
                {
                    Collider[] colliders = Physics.OverlapSphere(hit.point, spawnRadius);

                    canSpawn = true;

                
                    foreach (Collider collider in colliders)
                    {
                        if (collider.gameObject.CompareTag("Turret"))  
                        {
                            Debug.Log(collider.gameObject.tag + collider.gameObject.name);
                            canSpawn = false;  
                            break;
                        }
                    }
                }
                

                if (canSpawn)
                {
                    if (fturretCost <= Upgrade.score)
                    {
                        GameObject objectToCreate = Instantiate(TurretPrefab, hitObject.transform.position, Quaternion.identity);
                        objectToCreate.name = "Turret 1a";
                        Upgrade.score -= fturretCost;
                    }
                      
                }
                else
                {
                    Debug.Log("Турель не может быть размещена в этой области");
                }
            }
        }
}