using UnityEngine;
using System.Collections.Generic;

public class WireGenerator : MonoBehaviour
{
    public int width = 10; // ������ �����
    public int height = 10; // ������ �����
    private int[,] grid; // ��������� ������ ��� ������������� �����
    public GameObject emptyPrefab; // ������ ������� �������
    public GameObject startPrefab; // ������ ��������� �����
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
        grid = new int[width, height]; // ������������� ����� ������
    }
    private void CreatePath(Vector2Int start, Vector2Int end)
    {
        // ����� ����� ����������� �������� ������ ����
        // ��� �������� ������� � ������ ������� ����

        grid[start.x, start.y] = 2; // ��������� �����
        grid[end.x, end.y] = 3; // �������� �����

        // ������ ���������� ���� - ��������� �� ������ ��������
        for (int x = start.x; x <= end.x; x++)
        {
            for (int y = start.y; y <= end.y; y++)
            {
                if (grid[x, y] == 0) // ���� ��� ������ ������
                {
                    grid[x, y] = 1; // ��������� �������
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
                Vector3 position = new Vector3(x, 0, y); // ������� ��� ������� �������
                switch (grid[x, y])
                {
                    case 0:
                        Instantiate(emptyPrefab, position, Quaternion.identity,parentObject);
                        break;
                    case 1:
                        // ������� ����� (�������� ���� ����� ������� ����� ������)
                        Instantiate(pipePrefab, position, Quaternion.identity,parentObject);
                        break;
                    case 2:
                        // ������� ��������� �����
                        Instantiate(startPrefab, position, Quaternion.identity, parentObject);
                        break;
                    case 3:
                        // ������� �������� �����
                        Instantiate(endPrefab, position, Quaternion.identity, parentObject);
                        break;
                }
            }
        }
    }
}