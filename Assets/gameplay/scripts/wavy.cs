using UnityEngine;
using System.Collections.Generic;

public class wavy : MonoBehaviour {
	public MeshFilter mf;
	public Mesh m;
	public MeshRenderer mr;
	public static float _phi;
	public static float _omega;
	public static float _alpha;
	public static float _wave_speed;
	public float phi;
	public float omega;
	public float alpha;
	public float wave_speed;

	Vector3[] deform_verts;

	// Use this for initialization
	void Start () {
		_phi = phi;
		_omega = omega;
		_alpha = alpha;
		_wave_speed = wave_speed;
		//Mesh m = new Mesh();

		mf = gameObject.GetComponent<MeshFilter>();
		mr = gameObject.GetComponent<MeshRenderer>();
		List<Vector3> verts = new List<Vector3>();
		List<Vector3> norms = new List<Vector3>();
		List<Vector2> uvs = new List<Vector2>();
		int[] faces = new int[99*6];
		int i,j;

		for (i=0; i< 100; i++) {
			verts.Add(new Vector3(i* 0.45F - 22F, 2.5F, 0));
			verts.Add(new Vector3(i* 0.45F - 22F, -2.5F, 0));
			norms.Add(-Vector3.forward);
			norms.Add(-Vector3.forward);
			uvs.Add(Vector2.right * (i / 99F) + Vector2.up);
			uvs.Add(Vector2.right * (i / 99F));

			if (i > 0) {
				faces[ 6 * (i - 1)+0] = 2*i-1;
				faces[ 6 * (i - 1)+1] = 2*i-2;
				faces[ 6 * (i - 1)+2] = 2*i;
				faces[ 6 * (i - 1)+3] = 2*i;
				faces[ 6 * (i - 1)+4] = 2*i+1;
				faces[ 6 * (i - 1)+5] = 2*i-1;
			}
		}

		m = mf.mesh = new Mesh();
		m.SetVertices(verts);
		m.SetNormals(norms);
		m.SetUVs(0, uvs);
		m.SetTriangles(faces, 0);

		deform_verts = m.vertices;
		// addcom
	}
	
	// Update is called once per frame
	void Update () {
		phi -= Time.deltaTime * (wave_speed - pcontroller.main.v.x * 4);

		int i, imax = m.vertices.Length;
		Vector3 vert;
		for (i=0; i<imax; i++){
			vert = deform_verts[i];
			if (i % 2 == 0) {
				vert.y = getCrestY(vert.x);
				// - (160F * (i % 2));
			} else {
				vert.y = -1.8F * alpha;
			}
			deform_verts[i] = vert;
			//vert.y = vert.z;
		}
		m.vertices = deform_verts;

		_phi = phi;
		_omega = omega;
		_alpha = alpha;
		_wave_speed = wave_speed;

		mr.material.mainTextureOffset = Vector2.right * 
			(phi) / 20F;
	
	}
	public static float getCrestY(float x) {
		float y = _alpha * 1 + 8F;
		float crash_wake = CrashWave.main.pos.x;
		if (x < crash_wake) {
			y += x - crash_wake;
		}
		return y;
		
			//	0.8F * _alpha * Mathf.Cos(0.711218F * _phi + 1.8F * x * _omega) + 8F;
	}
	public static float getCrestdY(float x) {
			return _alpha * _omega * Mathf.Cos(_phi + x * _omega);
	}
	public static float getCrestAngle(float x) {
			return Mathf.Atan(getCrestdY(x));
	}
}
