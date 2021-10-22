using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGrid<T>
{
    struct gridStructureParameters
    {
        public int row;
        public int col;
        public float radius;
        public Vector2 gridPosition;
    };

    struct hexNode
    {
        public Vector2 nodePosition;
        public T nodeData;
    };

    private gridStructureParameters gridParameters;

    private hexNode[,] hexGrid;

    private Vector2 nodeOffsetValue;

    private Vector2 firstNodePosition;

    private void SetGridRow(int row) => gridParameters.row = row > 0 ? row : 0;

    private void SetGridCol(int col) => gridParameters.col = col > 0 ? col : 0;

    private void SetGridNodeRadius(float radius) => gridParameters.radius = radius > 0 ? radius : 0;

    private void SetGridPosition(Vector2 gridPosition) => gridParameters.gridPosition = gridPosition;

    public void SetGridNodeValue(int i, int j, T value) => hexGrid[i, j].nodeData = value;

    public int GetGridRow() => gridParameters.row;

    public int GetGridCol() => gridParameters.col;

    public float GetGridNodeRadius() => gridParameters.radius;

    public Vector2 GetGridPosition() => gridParameters.gridPosition;

    public Vector2 GetGridNodePosition(int i, int j) => hexGrid[i, j].nodePosition;

    public T GetGridNodeValue(int i, int j) => hexGrid[i, j].nodeData;

    public HexGrid(int row, int col, float radius, Vector2 gridPosition, T defaultValue)
    {
        SetGridRow(row);
        SetGridCol(col);
        SetGridNodeRadius(radius);
        SetGridPosition(gridPosition);

        hexGrid = new hexNode[row,col];

        GenerateNodes(defaultValue);
    }

    private void GenerateNodes(T defaultValue)
    {
        nodeOffsetValue = new Vector2( Mathf.Cos(Mathf.Deg2Rad * 30.0f), Mathf.Sin(Mathf.Deg2Rad * 30.0f) + 1) * GetGridNodeRadius();

        int row = GetGridRow(), col = GetGridCol();
        float rowOffset = row * 0.5f - 0.5f, colOffset = col * 0.5f - 0.5f;

        colOffset = (rowOffset == (int)rowOffset ? colOffset : colOffset + 0.25f);

        firstNodePosition = GetGridPosition() - new Vector2(colOffset * 2 * nodeOffsetValue.x, rowOffset * nodeOffsetValue.y);


        for (int i=0;i<row;i++)
        {

            Vector2 firstRowNodePosition = firstNodePosition + new Vector2(i % 2 == 0 ? 0 : nodeOffsetValue.x, i * nodeOffsetValue.y);

            for(int j=0;j<col;j++)
            {
                hexGrid[i, j].nodePosition = firstRowNodePosition + Vector2.right * j * 2 * nodeOffsetValue.x;
                hexGrid[i, j].nodeData = defaultValue;
            }
        }
    }

    public Vector2Int GetNodeIndexFromPosition(Vector2 position)
    {

        Vector2Int nodeIndex = new Vector2Int(-1, -1);

        Vector2 diffVector = position - firstNodePosition;
        int rowPos = (int)(diffVector.y / nodeOffsetValue.y);
        int colPos = Mathf.Abs(rowPos) % 2 == 0 ? (int)(diffVector.x / (2 * nodeOffsetValue.x)) : (int)((diffVector.x - nodeOffsetValue.x) / (2 * nodeOffsetValue.x));

        float minDist = GetGridNodeRadius();

        for (int i = rowPos - 1; i < rowPos + 2; i++)
        {
            Vector2 rowNodePosition = firstNodePosition + new Vector2(Mathf.Abs(i) % 2 == 0 ? 0 : nodeOffsetValue.x, i * nodeOffsetValue.y);
            for (int j = colPos - 1; j < colPos + 2; j++)
            {
                Vector2 imaginaryNodePos = rowNodePosition + Vector2.right * j * 2 * nodeOffsetValue.x;
                float dist = Vector2.Distance(position, imaginaryNodePos);

                if (dist <= minDist)
                {
                    minDist = dist;
                    if (i >= 0 && i < GetGridRow() && j >= 0 && j < GetGridCol())
                        nodeIndex = new Vector2Int(i, j);
                }

            }
        }

        return nodeIndex;
    }


    private Vector2 VectorFromAngle(float angle)
    {
        return new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
    }

    private void DrawHexWithCenter(Vector2 pos)
    {
        Vector2[] edgeDir = {
            VectorFromAngle(-150f),
            VectorFromAngle(-90f),
            VectorFromAngle(-30f),
            VectorFromAngle(30f),
            VectorFromAngle(90f),
            VectorFromAngle(150f),
        };

        Vector2 currentPosition = pos + new Vector2(0, GetGridNodeRadius());

        for(int i=0;i<6;i++)
        {
            Debug.DrawRay(currentPosition, edgeDir[i] * GetGridNodeRadius(), Color.green, Time.deltaTime);
            currentPosition += edgeDir[i] * GetGridNodeRadius();
        }
    }

    public void DebugDrawGrid()
    {
        for (int i = 0; i < GetGridRow(); i++)
            for (int j = 0; j < GetGridCol(); j++)
                DrawHexWithCenter(hexGrid[i, j].nodePosition);
    }
}
