using UnityEngine;
using System.Collections;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] GameObject _sphere;
    [SerializeField] GameObject _plane;


    private GameObject[] _planes;
    private GameObject _base;
    private const int SphereNum = 30;
    private const int PlaneNum = 20;

    void Start()
    {
        _base = SetPlane();
        _base.name = "base";
        _planes = new GameObject[PlaneNum];
        for (int i = 0; i < PlaneNum; i++)
        {
            _planes[i] = SetPlane();

            _planes[i].transform.parent = _base.transform;

            for (int j = 0; j < SphereNum; j++)
            {
                var sphere = Spawn(Mathf.Cos(2.0f * Mathf.PI * j / SphereNum), 0f, Mathf.Sin(2.0f * Mathf.PI * j / SphereNum));
                sphere.transform.parent = _planes[i].transform;
            }
            _planes[i].transform.Rotate(0f, 0f, 360f * i / PlaneNum);

        }
    }

    void Update()
    {
        _base.transform.Rotate(0f, 2f, 0f);
    }

    private GameObject SetPlane()
    {
        var plane = Instantiate<GameObject>(_plane);
        plane.transform.position = Vector3.zero;
        return plane;
    }

    private GameObject Spawn(float x, float y, float z)
    {
        var sphere = Instantiate<GameObject>(_sphere);
        sphere.transform.position = new Vector3(x, y, z);
        return sphere;
    }
}
