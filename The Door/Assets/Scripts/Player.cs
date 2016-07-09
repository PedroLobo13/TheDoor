using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float velocidade = 5;
	public float velocidadeRotacao = 5;
	private Rigidbody rb;
	private float velocidadeAntiga;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		velocidadeAntiga = velocidade;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//transform.Translate(Vector3.forward * Input.GetAxisRaw("Vertical") * Time.deltaTime * velocidade);

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			velocidadeAntiga = velocidade;
			velocidade *= 2;
		}
		else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			velocidade = velocidadeAntiga;
		}

		transform.RotateAround(transform.position, Vector3.up, Input.GetAxisRaw("Horizontal") * velocidadeRotacao);
	}

	void FixedUpdate()
	{
		rb.MovePosition(transform.position + transform.forward * velocidade * Input.GetAxisRaw("Vertical"));
	}
}
