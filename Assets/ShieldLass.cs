using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShieldLass : MonoBehaviour
{
	private const float Z_SPEED = 1.4f;
	private const float X_SPEED = 1f;
	
	private Rigidbody _rigidbody;
	
	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	void Update ()
	{
		Vector3 velocity = Vector3.zero;
		
		if (Input.GetKey(KeyCode.UpArrow))
		{
			velocity.z = Z_SPEED;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			velocity.z = -Z_SPEED;
		}
		
		if (Input.GetKey(KeyCode.RightArrow))
		{
			velocity.x = X_SPEED;
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			velocity.x = -X_SPEED;
		}

		_rigidbody.velocity = velocity.normalized * 200 * Time.deltaTime;
	}
}
