using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject TurretPrefab;

    [SerializeField]
    private float spawnRadius = 2f; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                
                Collider[] colliders = Physics.OverlapSphere(hit.point, spawnRadius);

                bool canSpawn = true;

                
                foreach (Collider collider in colliders)
                {
                    if (collider.gameObject.CompareTag("Turret"))  
                    {
                        canSpawn = false;  
                        break;
                    }
                }

                if (canSpawn)  
                {
                    Instantiate(TurretPrefab, hit.point, Quaternion.identity);  
                }
                else
                {
                    Debug.Log("Турель не может быть размещена в этой области, так как уже есть турель.");
                }
            }
        }
    }
}