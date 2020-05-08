using UnityEngine;
using System.Collections.Generic;

public class ScrollingBackground : MonoBehaviour
{
    public List<Transform> bgPatternColumns;
    public Transform columnFarthestToRight;
    [SerializeField] private int _offScreenXPos;
    [SerializeField] private float _distanceBetweenCollums;
    [SerializeField, Range(1f, 100f)] private int _scrollSpeed = 10;

    void Start()
    {
        InvokeRepeating("RepositionOffScreenColumns", 0, 0.5f);
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(RepositionOffScreenColumns), 0, 0.5f);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(RepositionOffScreenColumns));
    }

    void Update()
    {
        MoveColumns();
    }

    public void RepositionOffScreenColumns()
    {
        foreach (Transform column in bgPatternColumns)
        {
            if (column.localPosition.x > columnFarthestToRight.localPosition.x)
            {
                columnFarthestToRight = column;
            }
            if (column.localPosition.x < _offScreenXPos)
            {
                column.localPosition = new Vector3(columnFarthestToRight.localPosition.x + _distanceBetweenCollums, 0, 1);
            }
        }
    }

    public void MoveColumns()
    {
        foreach (Transform column in bgPatternColumns)
        {
            column.Translate(Vector3.left * (Time.deltaTime * _scrollSpeed));
        }
    }
}
