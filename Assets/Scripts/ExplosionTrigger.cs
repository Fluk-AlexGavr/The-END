using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    // Сила, с которой объекты будут отталкиваться от триггер-объекта
    public float explosionForce = 500f;
    // Радиус воздействия силы
    public float explosionRadius = 5f;
    // Смещение по высоте для добавления вертикальной силы (необязательно)
    public float upwardModifier = 1f;
    public MouseChooseStoneOrMetalItem metalItem;

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, есть ли у объекта компонент Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();

        // Если Rigidbody найден, применяем к нему взрывную силу
        if (rb != null && metalItem.brokeNow)
        {
            // Направляем силу от позиции триггер-объекта к объекту
            Vector3 explosionDirection = (other.transform.position - transform.position).normalized;

            // Применяем взрывную силу
            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardModifier, ForceMode.Impulse);
        }
    }
}