using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShieldLass : MonoBehaviour
{
	private const float Z_SPEED = 1.4f;
	private const float X_SPEED = 1f;

	private float _chargeTime;
	// direction character is facing
	private Vector3 _facing = Vector3.back;
	
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
			_facing = Vector3.forward;
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			velocity.z = -Z_SPEED;
			_facing = Vector3.back;
		}
		
		if (Input.GetKey(KeyCode.RightArrow))
		{
			velocity.x = X_SPEED;
			_facing = Vector3.right;
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			velocity.x = -X_SPEED;
			_facing = Vector3.left;
		}

		_rigidbody.velocity = velocity.normalized * 200 * Time.deltaTime;
		
		// Shield Power
		if (Input.GetKey(KeyCode.LeftShift))
		{
			_chargeTime += Time.deltaTime;
		}
		else
		{
			_chargeTime = 0;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		// shield is charging and we're touching the Block
		if (_chargeTime > 0 && other.gameObject.tag == "Block")
		{
			// move block in facing direction
			other.gameObject.GetComponent<Block>().Move(_facing);
		}
	}
}
