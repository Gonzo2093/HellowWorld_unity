using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner3 : MonoBehaviour
{
    public GameObject cubePrefabVar;
    public List<GameObject> gameObjectList; // ����� ������� ��� ������
    public float scalingFactor = 0.95f; // ����������� ��������� �������� ������� ������ � ������ �����
    public int numCubes = 0; // ����������������������

    // ����������� ���� ����� ��� �������������
    void Start()
    {
        // ������������� ������ List<GameObject>
        gameObjectList = new List<GameObject>();
    }

    // Update ���������� � ������ �����
    void Update()
    {
        numCubes++; // ��������� ���������� ������� 

        GameObject gObj = Instantiate<GameObject>(cubePrefabVar);
        // ��������� ������ ������������� ��������� �������� � ����� ������
        gObj.name = "Cube " + numCubes;
        Color c = new Color(Random.value, Random.value, Random.value);
        gObj.GetComponent<Renderer>().material.color = c;         // �������� ��������� Renderer �� gObj � ��������� ��������� ����
        gObj.transform.position = Random.insideUnitSphere;
        gameObjectList.Add(gObj); // �������� gObj � ������ �������
        List<GameObject> removeList = new List<GameObject>();
        // ������ removeList ����� ������� ������, ����������
        // �������� �� ������ gameObjectList
        // ����� ������� � gameObjectList
        foreach (GameObject goTemp in gameObjectList)
        {
            // �������� ������� ������
            float scale = goTemp.transform.localScale.x;
            scale *= scalingFactor;
            goTemp.transform.localScale = Vector3.one * scale;
            if (scale <= 0.1f)
            { // ���� ������� ������ 0.1f...
                removeList.Add(goTemp); // ...�������� ����� � removeList
            }
        }
        foreach (GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); // ������� ����� �� gameObjectList
            Destroy(goTemp); // ������� ������� ������ ������
        }
    }
}
