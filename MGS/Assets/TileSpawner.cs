using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileSpawner : MonoBehaviour {
	
	public GameObject tile;
	public GameObject defaultTile;
	GameObject newTile;
	public GameObject newInstanceTile;
	public GameObject instanceTile;
	bool isDefaultTile;


	void Start () {
		isDefaultTile = true;
		newTile = Instantiate (defaultTile, gameObject.transform.position, new Quaternion());
		newTile.transform.parent = gameObject.transform;
	}
	
	// Update is called once per frame

	void LateUpdate()

	{


	}
	void Update () {

		if (tile!=null)	{instanceTile = tile;}
		if (isDefaultTile == true && tile !=null)
			{

			Invoke("InstanciateTile",0.0f);

			Invoke("DestroyTile",0.02f);
			isDefaultTile = false;

			} 

		if (isDefaultTile == false && tile !=null)
			{

			Invoke("DestroyInstancedTile",0.0f);

			}

		}


	public void InstanciateTile()
		{
		newInstanceTile = Instantiate (instanceTile, gameObject.transform.position, new Quaternion ());
		newInstanceTile.transform.parent = gameObject.transform;


		}

	public void DestroyTile()
		{
		Destroy (newTile);
		tile = null;
	
		}

	public void DestroyInstancedTile()
		{
		Destroy (newInstanceTile);
		Invoke("InstanciateTile",0.0f);
		tile = null;
		}
		
}
