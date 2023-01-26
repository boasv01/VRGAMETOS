using System.Collections;
using UnityEngine.AI;
using UnityEngine;

namespace Rotation
{
    public class Rotate : MonoBehaviour
    {
        public void RotateTo(Transform target)
        {
            StartCoroutine(RotateToObject(target));
        }

        IEnumerator RotateToObject(Transform target)
        {
            Quaternion lookRotation;
            do
            {
                Vector3 direction = new Vector3(target.position.x - transform.position.x, 0f, target.position.z - transform.position.z);
                lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime / (Quaternion.Angle(transform.rotation, lookRotation) / GetComponent<NavMeshAgent>().angularSpeed));
                yield return new WaitForFixedUpdate();
            } while (true);
        }
    }
}