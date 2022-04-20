using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force : MonoBehaviour
{
    [SerializeField] private MeshRenderer[] childRenderer;
    [SerializeField]private ParticleSystem particle;
    [SerializeField]private Material material;
    [SerializeField]private Material platform;
    [SerializeField]private Material obstacle;

    private void OnEnable() {
        
        print("whatever");
        foreach(MeshRenderer i in childRenderer)
        {
            if(i.tag == "Platform")
            {
                i.material = platform;
            }
            else if(i.tag == "obstacle")
            {
                i.material = obstacle;
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        Break();
    }
    public void Break()
    {
        
        for(int i = 0;i <= childRenderer.Length - 1;i++)
        {
            childRenderer[i].material = material;
            particle.Play();
        }
        
        StartCoroutine(FalseGameObejct());
    }
    IEnumerator FalseGameObejct()
    {
        yield return new WaitForSeconds(0.2f);
        transform.parent.gameObject.SetActive(false);
    }
}
