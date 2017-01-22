using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSortLayerScript : MonoBehaviour {
	void Start () {
		ParticleSystem particleSystem = GetComponent<ParticleSystem>();

	    //Change Foreground to the layer you want it to display on 
	    //You could prob. make a public variable for this
//	    Renderer particleSystemRenderer = particleSystem.renderer;
//	    renderer.sortingLayerName = "Foreground";
     }
}
