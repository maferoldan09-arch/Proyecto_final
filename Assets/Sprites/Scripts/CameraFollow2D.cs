using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Objetivo a seguir")]
    public Transform target;

    [Header("Configuración de la Cámara")]
    [Range(0.01f, 1f)]
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        // Si no hay un objetivo asignado, no hacemos nada
        if (target == null)
        {
            Debug.LogWarning("Falta asignar el 'Target' en el script de la cámara.");
            return;
        }

        // 1. Calculamos a dónde queremos que vaya la cámara
        Vector3 desiredPosition = target.position + offset;

        // 2. Interpolamos entre la posición actual y la deseada para dar el efecto suave
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // IMPORTANTE PARA 2D: Mantenemos la posición en Z fija (generalmente en -10) 
        // para no perder de vista los sprites por acercarnos demasiado.
        smoothedPosition.z = target.position.z + offset.z;

        // 3. Movemos la cámara a la nueva posición
        transform.position = smoothedPosition;
    }
}