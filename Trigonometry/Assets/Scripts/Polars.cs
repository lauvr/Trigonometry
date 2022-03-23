using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyMath;

public class Polars : MonoBehaviour {

	[SerializeField] 
	Vector2 polarCoord; // x is radius, y is theta

	[SerializeField] 
	GameObject dona;

	[SerializeField] 
	float angularSpeed;

	[SerializeField] 
	float angularAcceleration;

	[SerializeField] 
	float radialSpeed;

	[SerializeField] 
	float radialAcceleration;

	[SerializeField] 
	float rMax;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		radialSpeed += radialAcceleration * Time.deltaTime;
		polarCoord.x += radialSpeed * Time.deltaTime;

		angularSpeed += angularAcceleration * Time.deltaTime;
		polarCoord.y += angularSpeed * Time.deltaTime;


		polarCoord.y += 0.01f;
		polarCoord.x += 0.001f;
		dona.transform.position = PolarToCartesian (polarCoord);

		DrawPolar (polarCoord);

		CheckCollition ();

	}



	private void DrawPolar (Vector2 polarCoord){

		Vector3 cartesian = PolarToCartesian (polarCoord);
		Debug.DrawLine (Vector3.zero, cartesian, Color.magenta);
	}

	private Vector3 PolarToCartesian(Vector2 polar){
		
		float r = polarCoord.x;
		float cos = Mathf.Cos(polarCoord.y);
		float sin = Mathf.Sin (polarCoord.y);
		Vector3 cartesian = new Vector3 (r * cos, r * sin);
		cartesian *= r;
		return cartesian;

	}

	private void CheckCollition(){
		if (polarCoord.x >= rMax) {
			radialSpeed = -radialSpeed;
		} 
		if (polarCoord.x == 0) {
			radialSpeed = -radialSpeed;
		}
	}
}
