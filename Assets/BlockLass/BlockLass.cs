using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BlockLass : MonoBehaviour
{
	private const float Z_SPEED = 1.4f;
	private const float X_SPEED = 1f;
	
	private Rigidbody _rigidbody;
	private Block _block;

	// direction character is facing
	private Vector3 facing = Vector3.back;
	
	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody>();

		//create block
		_block = Instantiate(Resources.Load<GameObject>("Block")).GetComponent<Block>();
	}

	void Update()
	{
		// Movement
		Vector3 velocity = Vector3.zero;
		if (Input.GetKey(KeyCode.W))
		{
			velocity.z = Z_SPEED;
			facing = Vector3.forward;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			velocity.z = -Z_SPEED;
			facing = Vector3.back;
		}

		if (Input.GetKey(KeyCode.D))
		{
			velocity.x = X_SPEED;
			facing = Vector3.right;
		}
		else if (Input.GetKey(KeyCode.A))
		{
			velocity.x = -X_SPEED;
			facing = Vector3.left;
		}
		
		_rigidbody.velocity = velocity.normalized * 200 * Time.deltaTime;

		// Block power
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (_block.gameObject.activeSelf)
			{
				_block.Despawn();
			}
			else
			{
				// set block position
				Vector3 blockPos = transform.position + facing * 2;
				
				_block.Spawn(blockPos);
			}
		}
	}
}
