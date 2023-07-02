using UnityEngine;

namespace JSLizards.Iguana.Scripts
{
    public class RandomPositionGenerator
    {
        public static Vector3 GetRandomPosition()
        {
            float x, y, z;

            if (Random.Range(0, 2) == 0)
            {
                x = (Random.Range(0, 2) == 0) ? -10f : 10f;
                z = Random.Range(-4f, 4f);
            }
            else
            {
                x = Random.Range(-10f, 10f);
                z = (Random.Range(0, 2) == 0) ? -7f : 7f;
            }

            y = 0f;

            return new Vector3(x, y, z);
        }
    }
}