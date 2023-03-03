using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Calculation
    {
        public static int GetQuantityForProduct(int productType,int materialType,int count,float width,float length)
        {
            if (count < 0)
                return -1;
            if (width <= 0 || length <= 0)
                return -1;

            float square = 0;
            float rawMaterials = 0;
            square = width * length;

            switch(productType)
            {
                case 1:rawMaterials = square * 1.1f;break;
                case 2:rawMaterials = square * 2.5f;break;
                case 3:rawMaterials = square * 8.43f;break;
                default:return -1;
            }
            switch (materialType)
            {
                case 1:rawMaterials /= (1.0f - 0.3f / 100f);break;
                case 2: rawMaterials /= (1.0f - 0.12f / 100f); break;
                default:return -1;
            }

            float needMaterials = (float)count * rawMaterials;
            int result = (int)Math.Ceiling(needMaterials);
            if (result < 0) return -1;
            return result;
        }
    }
}
