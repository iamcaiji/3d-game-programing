using UnityEngine;
using System.Collections;

public class AAA : MonoBehaviour {

	public float t = 0f;

	public GameObject firework;
	public int count = 0;

	void Start() {
		firework = Instantiate(Resources.Load<GameObject>("Prefabs/green"), new Vector3(0, 0, 0), Quaternion.identity);
	}

	// void Update ()
	// {
	// 	t += Time.deltaTime;
	// 	if (t > 3.0f) {
	// 		// Destroy(firework);
	// 		t -= 3.0f;
	// 		++ count;
	// 		Destroy(firework);
	// 		if (count % 3 == 0)
	// 			firework = Instantiate(Resources.Load<GameObject>("Prefabs/green"), new Vector3(0, 0, 0), Quaternion.identity);
	// 		if (count % 3 == 1)
	// 			firework = Instantiate(Resources.Load<GameObject>("Prefabs/purple"), new Vector3(0, 0, 0), Quaternion.identity);
	// 		if (count % 3 == 2)
	// 			firework = Instantiate(Resources.Load<GameObject>("Prefabs/yellow"), new Vector3(0, 0, 0), Quaternion.identity);
	// 	}
	// }

	void OnGUI(){
		if (GUI.Button(new Rect(30,30,100,30), "绿色烟花")) {
			Destroy(firework);
			firework = Instantiate(Resources.Load<GameObject>("Prefabs/green"), new Vector3(0, 0, 0), Quaternion.identity);
		}
		if (GUI.Button(new Rect(130,30,100,30), "紫色烟花")) {
			Destroy(firework);
			firework = Instantiate(Resources.Load<GameObject>("Prefabs/purple"), new Vector3(0, 0, 0), Quaternion.identity);
		}
		if (GUI.Button(new Rect(230,30,100,30), "黄色烟花")) {
			Destroy(firework);
			firework = Instantiate(Resources.Load<GameObject>("Prefabs/yellow"), new Vector3(0, 0, 0), Quaternion.identity);
		}
	}
}