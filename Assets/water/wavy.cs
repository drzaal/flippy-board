using UnityEngine;
using System.Collections.Generic;

public class wavy : MonoBehaviour {
	public MeshFilter mf;
	public Mesh m;
	public MeshRenderer mr;
	public float phi;
	public float omega;
	public float alpha;
	public float wave_speed;

	Vector3[] deform_verts;

	// Use this for initialization
	void Start () {
		//Mesh m = new Mesh();

		mf = gameObject.GetComponent<MeshFilter>();
		mr = gameObject.GetComponent<MeshRenderer>();
		List<Vector3> verts = new List<Vector3>();
		List<Vector3> norms = new List<Vector3>();
		List<Vector2> uvs = new List<Vector2>();
		int[] faces = new int[99*6];
		int i,j;

		for (i=0; i< 100; i++) {
			verts.Add(new Vector3(i* 10 - 100, 25, 0));
			verts.Add(new Vector3(i* 10 - 100, -25, 0));
			norms.Add(-Vector3.forward);
			norms.Add(-Vector3.forward);
			uvs.Add(Vector2.right * (i % 5) / 4);
			uvs.Add(Vector2.one);

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
		phi -= Time.deltaTime * wave_speed;

		int i, imax = m.vertices.Length;
		Vector3 vert;
		for (i=0; i<imax; i++){
			vert = deform_verts[i];
			vert.y = alpha * Mathf.Sin(phi + vert.x * omega) - (160F * (i % 2));
			deform_verts[i] = vert;
			//vert.y = vert.z;
		}
		m.vertices = deform_verts;

		//mr.material.mainTextureOffset = Vector2.right * phi;
	
	}
}
