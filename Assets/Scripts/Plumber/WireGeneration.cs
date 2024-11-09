using UnityEngine;
using System.Collections.Generic;

public class WireGenerator : MonoBehaviour
{
    public int width = 10; // Ширина сетки
    public int height = 10; // Высота сетки
    private int[,] grid; // Двумерный массив для представления сетки
    public GameObject emptyPrefab; // Префаб пустого объекта
    public GameObject startPrefab; // Префаб стартовой точки
    public GameObject endPrefab;
    public GameObject pipePrefab;
    public Transform parentObject;

    void Start()
    {
        InitializeGrid();
        CreatePath(new Vector2Int(0, 0), new Vector2Int(width - 1, height - 1));
        GenerateGrid();
    }

    private void InitializeGrid()
    {
        grid = new int[width, height]; // Инициализация сетки нулями
    }
    private void CreatePath(Vector2Int start, Vector2Int end)
    {
        // Здесь можно реализовать алгоритм поиска пути
        // Для простоты примера я просто заполню путь

        grid[start.x, start.y] = 2; // Начальная точка
        grid[end.x, end.y] = 3; // Конечная точка

        // Пример заполнения пути - заменяете на нужный алгоритм
        for (int x = start.x; x <= end.x; x++)
        {
            for (int y = start.y; y <= end.y; y++)
            {
                if (grid[x, y] == 0) // Если это пустая ячейка
                {
                    grid[x, y] = 1; // Заполняем трубами
                }
            }
        }
    }
    private void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 position = new Vector3(x, 0, y); // Позиция для каждого объекта
                switch (grid[x, y])
                {
                    case 0:
                        Instantiate(emptyPrefab, position, Quaternion.identity,parentObject);
                        break;
                    case 1:
                        // Создаем трубу (вариации труб можно сделать через префаб)
                        Instantiate(pipePrefab, position, Quaternion.identity,parentObject);
                        break;
                    case 2:
                        // Создаем начальную точку
                        Instantiate(startPrefab, position, Quaternion.identity, parentObject);
                        break;
                    case 3:
                        // Создаем конечную точку
                        Instantiate(endPrefab, position, Quaternion.identity, parentObject);
                        break;
                }
            }
        }
    }
}