using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] Transform target;  // Объект, к которому направлен луч
    [SerializeField] float maxDistance = 100f;  // Максимальная длина луча
    [SerializeField] GameObject laser;
    [SerializeField] float offset = 5f;

    [SerializeField] float shotTime;

    private bool alreadyShoting;



    void Update()
    {
        if (target != null && !alreadyShoting)
        {
            // Вычисляем направление от текущего объекта к цели
            Vector3 direction = transform.forward;

            // Вычисляем расстояние до цели, но ограничиваем его максимальной длиной луча
            float distance = Mathf.Min(Vector3.Distance(transform.position, target.position), maxDistance);

            // Визуализируем луч в редакторе
            Debug.DrawRay(transform.position, direction * distance, Color.red);

            // Выполняем Raycast и проверяем, попал ли он в объект с тегом "target"
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, distance))
            {
                if (hit.collider.tag =="target")
                {
                    Vector3 targetDirection = (hit.collider.transform.position - transform.position).normalized;
                    float angle = Vector3.Angle(direction, targetDirection);

                    // Проверяем, попадает ли угол в допустимую погрешность offset
                    if (angle <= offset)
                    {
                        Shot1();  // Вызываем Shot и передаем конечную точку луча
                        alreadyShoting = true;
                    }
                    
                }
            }
            else
            {
                laser.gameObject.SetActive(false);
            }
        }
    }

    void Shot1()
    {
        Vector3 endPoint = target.position;
        Debug.Log("Shot triggered!");

        // Включаем объект, если он не активен
        if (!laser.gameObject.activeInHierarchy)
        {
            laser.gameObject.SetActive(true);
        }

        // Рассчитываем начальную и конечную точку луча
        Vector3 startPoint = transform.position;

        // Направление от начальной к конечной точке
        Vector3 direction = (endPoint - startPoint).normalized;

        // Рассчитываем расстояние между начальной и конечной точкой
        float distance = Vector3.Distance(startPoint, endPoint);

        // Обновляем позицию и масштаб stretchingObject, чтобы он растягивался
        laser.transform.position = startPoint + direction * (distance / 2);  // Ставим в середину между точками
        laser.transform.localScale = new Vector3(laser.transform.localScale.x, distance / 6, laser.transform.localScale.z);
        Invoke("ShotEnd", shotTime);
    }

    void ShotEnd()
    {
        laser.SetActive(false);
    }
}
