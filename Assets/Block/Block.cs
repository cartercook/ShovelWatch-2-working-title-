using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	private Vector3 destination;
	
	private Rigidbody _rigidbody;
	
	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		gameObject.SetActive(false);
	}

	public void Spawn(Vector3 position)
	{		
		transform.position = SnapToGrid(position);
		_rigidbody.velocity = Vector3.zero;
		gameObject.SetActive(true);
	}

	public void Despawn()
	{
		gameObject.SetActive(false);
	}

	public void Move(Vector3 direction)
	{
		destination = SnapToGrid(transform.position + direction);
		StartCoroutine(MoveTowardDestination());
	}

	IEnumerator MoveTowardDestination()
	{
		// while there's still distance left to travel
		while (Vector3.Distance(transform.position, destination) > 0.01)
		{
			transform.position = Vector3.Lerp(transform.position, destination, 2*Time.deltaTime);
			yield return null;
		}
		
		// finished
		transform.position = destination;
	}
	
	// ---------- HELPERS ----------

	Vector3 SnapToGrid(Vector3 position)
	{
		// Round to nearest .5
		position.x = Mathf.Round(position.x + 0.5f) - 0.5f;
		position.z = Mathf.Round(position.z);

		return position;
	}
}
