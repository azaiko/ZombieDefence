using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject TurretPrefab;

    [SerializeField]
    private float spawnRadius = 2f; // Радиус, в котором не будет спавниться турель

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Проверяем клик левой кнопкой мыши
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // Создаём луч от камеры
            if (Physics.Raycast(ray, out RaycastHit hit))  // Проверка попадания луча в объект
            {
                // Проверяем, есть ли в радиусе вокруг точки уже другие турели
                Collider[] colliders = Physics.OverlapSphere(hit.point, spawnRadius);

                bool canSpawn = true;  // Флаг, показывающий можно ли спавнить турель

                // Проходим по всем коллайдерам в радиусе
                foreach (Collider collider in colliders)
                {
                    if (collider.gameObject.CompareTag("Turret"))  // Проверяем, что это объект с тегом "Turret"
                    {
                        canSpawn = false;  // Если турель уже есть, не создаём новую
                        break;
                    }
                }

                if (canSpawn)  // Если турелей в радиусе нет
                {
                    Instantiate(TurretPrefab, hit.point, Quaternion.identity);  // Создаём новую турель
                }
                else
                {
                    Debug.Log("Турель не может быть размещена в этой области, так как уже есть турель.");
                }
            }
        }
    }
}