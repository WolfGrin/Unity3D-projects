using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    public Vector3 mapSize;
    public GameObject cube;
    public Material[] materials;



	// Use this for initialization
	void Start () {
		for(int x = 0; x < mapSize.x; x++)
        {
            for (int z = 0; z < mapSize.z; z++)
            {
                float noice = Mathf.PerlinNoise(x/mapSize.x, z/mapSize.z);
                int y = Mathf.RoundToInt(noice * mapSize.y);
                GameObject obj = Instantiate<GameObject>(cube);
                obj.transform.position = new Vector3(x, y, z);
                obj.GetComponent<Renderer>().material = 
                    (y < 6)? materials[0] :
                    (y < 7) ? materials[1] :
                    (y < 9) ? materials[2] :
                    materials[3];
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
