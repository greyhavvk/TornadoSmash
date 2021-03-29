using UnityEngine;

public class Rotator : MonoBehaviour
{
    #pragma warning disable 0649

    [Header("General Variables")]

    [SerializeField] private float _rotateSpeed;

    [Header("References")]
    
    [SerializeField] private Transform _centerTransformToRotate;

    #pragma warning restore 0649

    void Update()
    {
        _centerTransformToRotate.Rotate(new Vector3(0f, _rotateSpeed * Time.deltaTime, 0f));
    }
}