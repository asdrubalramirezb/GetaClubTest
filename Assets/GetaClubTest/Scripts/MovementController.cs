
using UnityEngine;

public class MovementController : MonoBehaviour
{
	public Rigidbody rb;
	public Collider col;

	public Vector3 pos { get { return transform.position; } }

	

	public void Push (Vector2 force)
	{
		GetComponentInChildren<Rigidbody>().AddForce (force, ForceMode.Impulse);
	}

	public void ActivateRb ()
	{
		GetComponentInChildren<Rigidbody>().isKinematic = false;
	}

	public void DesactivateRb ()
	{
		GetComponentInChildren<Rigidbody>().velocity = Vector3.zero;
		GetComponentInChildren<Rigidbody>().angularVelocity = Vector3.zero;
		GetComponentInChildren<Rigidbody>().isKinematic = true;
	}
}
