///--------------------------------------------------------------------------------------------
/// Simple Car Damage system By Ciorbyn Studio https://www.youtube.com/c/CiorbynStudio
/// Tutorial link: https://youtu.be/l04cw7EChpI
/// -------------------------------------------------------------------------------------------
/// 
using UnityEngine;
using UnityEngine.UI;

public class CarDamage : MonoBehaviour 
{
    public float hits;
    public float maxhits;
    public GameObject CarSmoke;
    public AudioSource Crash;
    public Button ResBut;

	private MeshFilter[] meshfilters;
	private float sqrDemRange;

    //Save Vertex Data
    private struct permaVertsColl
    {
        public Vector3[] permaVerts;
    }
    private permaVertsColl[] originalMeshData;
    int i;

    void Start() {
        ResBut.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        Repair();
    }
    
    void Repair()
    {
        hits = 0;
        CarSmoke.SetActive(false);
        Debug.Log("Riparato!");
    }

	public void OnCollisionEnter( Collision collision ) 
	{
        
        Crash.Play();

        hits += 1;
        if (hits > maxhits)
        {
            CarSmoke.SetActive(true);
            Debug.Log("Fumo!");
        }

	}

}
