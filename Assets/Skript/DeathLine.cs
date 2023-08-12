using UnityEngine;
using UnityEngine.Events;

public class DeathLine : MonoBehaviour
{
    [SerializeField] private UnityEvent _hero;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PleyerLogic pleyer))
        {
            _hero?.Invoke();
        }
        else
        {
            Destroy(other.gameObject, 0);
        }
    }
}
