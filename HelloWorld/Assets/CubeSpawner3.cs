using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner3 : MonoBehaviour
{
    public GameObject cubePrefabVar;
    public List<GameObject> gameObjectList; // Будет хранить все кубики
    public float scalingFactor = 0.95f; // Коэффициент изменения масштаба каждого кубика в каждом кадре
    public int numCubes = 0; // Общееколичествокубиков

    // Используйте этот метод для инициализации
    void Start()
    {
        // Инициализация списка List<GameObject>
        gameObjectList = new List<GameObject>();
    }

    // Update вызывается в каждом кадре
    void Update()
    {
        numCubes++; // Увеличить количество кубиков 

        GameObject gObj = Instantiate<GameObject>(cubePrefabVar);
        // Следующие строки устанавливают некоторые значения в новом кубике
        gObj.name = "Cube " + numCubes;
        Color c = new Color(Random.value, Random.value, Random.value);
        gObj.GetComponent<Renderer>().material.color = c;         // Получить компонент Renderer из gObj и назначить случайный цвет
        gObj.transform.position = Random.insideUnitSphere;
        gameObjectList.Add(gObj); // Добавить gObj в список кубиков
        List<GameObject> removeList = new List<GameObject>();
        // Список removeList будет хранить кубики, подлежащие
        // удалению из списка gameObjectList
        // Обход кубиков в gameObjectList
        foreach (GameObject goTemp in gameObjectList)
        {
            // Получить масштаб кубика
            float scale = goTemp.transform.localScale.x;
            scale *= scalingFactor;
            goTemp.transform.localScale = Vector3.one * scale;
            if (scale <= 0.1f)
            { // Если масштаб меньше 0.1f...
                removeList.Add(goTemp); // ...добавить кубик в removeList
            }
        }
        foreach (GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); // Удалить кубик из gameObjectList
            Destroy(goTemp); // Удалить игровой объект кубика
        }
    }
}
