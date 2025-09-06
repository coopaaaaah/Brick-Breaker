using UnityEngine;

public class BoardManager : MonoBehaviour
{

    public GameObject block;
    private Vector2[,] _board = new Vector2[3, 8]
    {
        { new (-4, 3), new (-3, 3), new (-2, 3), new (-1, 3),  new (0, 3), new (1, 3), new (2, 3), new (3, 3)  },
        { new (-4, 2),new (-3, 2),new (-2, 2),new (-1, 2),  new (0, 2), new (1, 2), new (2, 2), new (3, 2)  },
        { new (-4, 1),new (-3, 1),new (-2, 1),new (-1, 1),  new (0, 1), new (1, 1), new (2, 1), new (3, 1) }
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                Instantiate(block, _board[i, j], Quaternion.identity, gameObject.transform);
            }
        }
    }

}
