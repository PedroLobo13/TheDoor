using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public GameObject [] exitDoors;
	public GameObject [] cameras;
	public Texture [] texturasPortas;
	public GameObject player;
	public enum tipoPorta {Principal, Secundaria};
	public tipoPorta tipoDaPorta;
	private int portaAtiva = 0;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (cameras.Length != 0)
		{
			cameras[portaAtiva].transform.rotation = player.transform.rotation;
		}

		switch (tipoDaPorta)
		{
			case tipoPorta.Principal:
				if (Input.GetKeyDown(KeyCode.F))
				{
					portaAtiva = (int)Mathf.Repeat(portaAtiva + 1, exitDoors.Length);

					GetComponent<MeshRenderer>().material.mainTexture = texturasPortas[portaAtiva];
				}
			break;
			case tipoPorta.Secundaria:
			break;
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			//other.transform.position = new Vector3(exitDoors[portaAtiva].transform.position.x, exitDoors[portaAtiva].transform.position.y, exitDoors[portaAtiva].transform.position.z + exitDoors[portaAtiva].transform.forward.z * other.transform.localScale.z);
			other.transform.position = exitDoors[portaAtiva].transform.position + exitDoors[portaAtiva].transform.up * other.transform.localScale.z;
		}
	}
}
