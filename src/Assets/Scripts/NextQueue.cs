using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ォ��ɏo�Ă���Ղ悽���̊Ǘ�
class NextQueue
{
    private enum Constants
    {
        PUYO_TYPE_MAX = 4,      // �������(6�ȉ�)
        PUYO_NEXT_HISTORIES = 2,// NEXT�̌�
    };

    Queue<Vector2Int> _nexts = new();

    Vector2Int CreateNext()
    {
        return new Vector2Int(
            Random.Range(0, (int)Constants.PUYO_TYPE_MAX) + 1,// [1,PUYO_TYPE_MAX]�̒l
            Random.Range(0, (int)Constants.PUYO_TYPE_MAX) + 1);
    }

    public void Initialize()
    {
        // �L���[��PUYO_NEXT_HISTORIES�Z�b�g�̗����Ŗ�����
        for (int t = 0; t < (int)Constants.PUYO_NEXT_HISTORIES; t++)
        {
            _nexts.Enqueue(CreateNext());
        }
    }

    public Vector2Int Update()
    {
        // �擪���o���āA���ɐV���������Z�b�g��ǉ�
        Vector2Int next = _nexts.Dequeue();
        _nexts.Enqueue(CreateNext());

        return next;
    }

    // �L���[�ɓo�^����Ă���v�f�����ԂɃR�[���o�b�N�֐��ŌĂяo��(�O���ł̗v�f�̎Q�Ɨp)
    public void Each(System.Action<int, Vector2Int> cb)
    {
        int idx = 0;
        foreach (Vector2Int n in _nexts)
        {
            cb(idx++, n);
        }
    }
}