using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    // ����, � ������� ������� ����� ������������� �� �������-�������
    public float explosionForce = 500f;
    // ������ ����������� ����
    public float explosionRadius = 5f;
    // �������� �� ������ ��� ���������� ������������ ���� (�������������)
    public float upwardModifier = 1f;
    public MouseChooseStoneOrMetalItem metalItem;

    private void OnTriggerEnter(Collider other)
    {
        // ���������, ���� �� � ������� ��������� Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();

        // ���� Rigidbody ������, ��������� � ���� �������� ����
        if (rb != null && metalItem.brokeNow)
        {
            // ���������� ���� �� ������� �������-������� � �������
            Vector3 explosionDirection = (other.transform.position - transform.position).normalized;

            // ��������� �������� ����
            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardModifier, ForceMode.Impulse);
        }
    }
}