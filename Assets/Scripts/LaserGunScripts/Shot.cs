using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] Transform target;  // ������, � �������� ��������� ���
    [SerializeField] float maxDistance = 100f;  // ������������ ����� ����
    [SerializeField] GameObject laser;
    [SerializeField] float offset = 5f;

    [SerializeField] float shotTime;

    private bool alreadyShoting;



    void Update()
    {
        if (target != null && !alreadyShoting)
        {
            // ��������� ����������� �� �������� ������� � ����
            Vector3 direction = transform.forward;

            // ��������� ���������� �� ����, �� ������������ ��� ������������ ������ ����
            float distance = Mathf.Min(Vector3.Distance(transform.position, target.position), maxDistance);

            // ������������� ��� � ���������
            Debug.DrawRay(transform.position, direction * distance, Color.red);

            // ��������� Raycast � ���������, ����� �� �� � ������ � ����� "target"
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, distance))
            {
                if (hit.collider.tag =="target")
                {
                    Vector3 targetDirection = (hit.collider.transform.position - transform.position).normalized;
                    float angle = Vector3.Angle(direction, targetDirection);

                    // ���������, �������� �� ���� � ���������� ����������� offset
                    if (angle <= offset)
                    {
                        Shot1();  // �������� Shot � �������� �������� ����� ����
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

        // �������� ������, ���� �� �� �������
        if (!laser.gameObject.activeInHierarchy)
        {
            laser.gameObject.SetActive(true);
        }

        // ������������ ��������� � �������� ����� ����
        Vector3 startPoint = transform.position;

        // ����������� �� ��������� � �������� �����
        Vector3 direction = (endPoint - startPoint).normalized;

        // ������������ ���������� ����� ��������� � �������� ������
        float distance = Vector3.Distance(startPoint, endPoint);

        // ��������� ������� � ������� stretchingObject, ����� �� ������������
        laser.transform.position = startPoint + direction * (distance / 2);  // ������ � �������� ����� �������
        laser.transform.localScale = new Vector3(laser.transform.localScale.x, distance / 6, laser.transform.localScale.z);
        Invoke("ShotEnd", shotTime);
    }

    void ShotEnd()
    {
        laser.SetActive(false);
    }
}
