using UnityEngine;
using DG.Tweening;

public class CubeVacuumController : MonoBehaviour
{
    #pragma warning disable 0649

    [Header("General Variables")]
    
    [SerializeField] private float _shrinkSpeed;
    [SerializeField] private float _risingSpeed;
    [SerializeField] private float _risingRotationSpeed;
    [SerializeField] private float _vacuumSpeed;
    
    #pragma warning restore 0649

    private CubeStates _state;
    private Rigidbody _rigidBodyCube;

    private enum CubeStates
    {
        Stay,
        Vacuum,
        Rise
    }

    private void Start()
    {
        _rigidBodyCube = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Rising();
    }

    private void Rising()
    {
        if (_state == CubeStates.Rise) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (_risingSpeed * Time.deltaTime), transform.position.z);
            transform.Rotate(new Vector3(0f, _risingRotationSpeed * Time.deltaTime, _risingRotationSpeed * Time.deltaTime), Space.Self);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WhirlwindCenterTrigger"))
        {
            if (_state != CubeStates.Rise)
            {
                _state = CubeStates.Rise;
                transform.parent = other.transform;
                _rigidBodyCube.isKinematic = true;
                transform.DOScale(0.03f, _shrinkSpeed).SetDelay(0.1f).OnComplete(() =>
                {
                    Destroy(gameObject);
                    AudioController.audioController.PlayGetPointSFX();
                });
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WhirlwindVacuumColl"))
        {
            if (_state != CubeStates.Rise)
            {
                _state = CubeStates.Vacuum;
                transform.Rotate(new Vector3(0f, (_risingRotationSpeed / 2f) * Time.deltaTime, (_risingRotationSpeed / 2f) * Time.deltaTime), Space.Self);
                Vector3 _vector = (other.GetComponent<VacuumCollider>().centerTransform.position - transform.position).normalized;
                _rigidBodyCube.AddForce(_vector * _vacuumSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WhirlwindVacuumColl"))
        {
            if (_state != CubeStates.Rise)
            {
                _state = CubeStates.Stay;
            }
        }
    }
}