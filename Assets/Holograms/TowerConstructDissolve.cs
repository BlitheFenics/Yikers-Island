using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerConstructDissolve : MonoBehaviour
{
    
    Material mat;
    Material holomat;
    public GameObject ps;
    public GameObject Holomesh;

    public float step = 0.01f;
    public float timeStep = 0.01f;

    void Start()
    {
        mat = GetComponent<SkinnedMeshRenderer>().material;
        holomat = Holomesh.GetComponent<SkinnedMeshRenderer>().material;
        ps = transform.parent.GetChild(2).gameObject;
        ConstructTower();
    }

    void ConstructTower()
    {     
        StartCoroutine("Construct");
    }

    IEnumerator Construct()
    {
        yield return new WaitForSeconds(2.0f);

        float threshold = mat.GetFloat("_Threshold");

        ps.GetComponent<ParticleSystem>().Play();

        while (threshold < 8.5f)
        {
            threshold += step;
            ps.transform.Translate(new Vector3(0, 0, step / 1.8f ));
            mat.SetFloat("_Threshold", threshold);
            holomat.SetFloat("_Alpha", holomat.GetFloat("_Alpha") * 0.98f);
            yield return new WaitForSeconds(timeStep);
        }

        ps.GetComponent<ParticleSystem>().Stop();
    }
}
