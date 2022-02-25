using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{



	public float speed;
	private float x;
	public float PontoDeDestino;
	public float PontoOriginal;

	private float leftOriginal = -9;
	private float EndDesination = 8.56f;



	// Use this for initialization
	void Start()
	{
		//PontoOriginal = transform.position.x;
	}

	// Update is called once per frame
	void Update()
	{

		// The goal is to make the scene move when the player presses and input to give the feel of "Freedom"
		if (Input.GetKey(KeyCode.D))
		{

			x = transform.position.x;
			x += speed * Time.deltaTime;
			transform.position = new Vector3(x, transform.position.y, transform.position.z);



			if (x <= PontoDeDestino)
			{
				x = PontoOriginal;
				transform.position = new Vector3(x, transform.position.y, transform.position.z);
			}
		}

		if (Input.GetKey(KeyCode.A))
		{

			x = transform.position.x;
			x -= speed * Time.deltaTime;
			transform.position = new Vector3(x, transform.position.y, transform.position.z);

			if (x >= EndDesination)
				{
					x = leftOriginal;
					transform.position = new Vector3(x, transform.position.y, transform.position.z);
				}
			}

		
	}
}
