using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class YPathProxy : FindMonobehaviour, IFindPathProxy
{
    public async UniTask<Vector3[]> CalculatePath(Vector3 start, Vector3 end)
    {
        isCalculated = true;
        progress = 0.0F;

        try
        {
            List<Vector3> path = new List<Vector3>();
            for (int y = 0; y < 200; ++y)
            {
                path.Add(new Vector3(0, y, 0));
                await UniTask.Delay(200);
                progress += y / (float)200;
            }

            isCalculated = false;

            return path.ToArray();
        }
        finally
        {
            isCalculated = false;
            progress = 0.0f;
        }
    }

    public bool IsCalculated => isCalculated;
    public float Progress => progress;
}