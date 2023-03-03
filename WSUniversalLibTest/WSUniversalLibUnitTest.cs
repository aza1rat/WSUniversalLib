using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.InteropServices;
using WSUniversalLib;

namespace WSUniversalLibTest
{
    [TestClass]
    public class WSUniversalLibUnitTest
    {
        [TestMethod]
        public void GetQuantityForProduct_ProductTypeIs3MaterialIs1()
        {
            //Arrange
            int productType = 3;
            int materialType = 1;
            int count = 15;
            float width = 20;
            float length = 45;
            int expected = 114148;
            //Act
            int result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetQuantityForProduct_ProductTypeIs3MaterialIs2()
        {
            //Arrange
            int productType = 3;
            int materialType = 2;
            int count = 15;
            float width = 20;
            float length = 45;
            int expected = 113942;
            //Act
            int result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetQuantityForProduct_ProductTypeIs1MaterialIs1()
        {
            //Arrange
            int productType = 1;
            int materialType = 1;
            int count = 15;
            float width = 20;
            float length = 20;
            int expected = 6620;
            //Act
            int result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetQuantityForProduct_ProductTypeIs1MaterialIs2()
        {
            //Arrange
            int productType = 1;
            int materialType = 2;
            int count = 15;
            float width = 20;
            float length = 20;
            int expected = 6608;
            //Act
            int result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetQuantityForProduct_ProductTypeIs2MaterialIs1()
        {
            //Arrange
            int productType = 2;
            int materialType = 1;
            int count = 5;
            float width = 20;
            float length = 45;
            int expected = 11284;
            //Act
            int result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetQuantityForProduct_ProductTypeIs2MaterialIs2()
        {
            //Arrange
            int productType = 2;
            int materialType = 2;
            int count = 5;
            float width = 20;
            float length = 45;
            int expected = 11264;
            //Act
            int result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetQuantityForProduct_IsResultRoundedToUp()
        {
            //Arrange
            int productType = 2;
            int materialType = 2;
            int count = 1;
            float width = 20;
            float length = 20;
            float square = width * length;
            float afterUseСoefficients = (square * 2.5f) / (0.9988f);
            int expected = (int)(afterUseСoefficients * count) + 1;
            //Act
            int result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            //Assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void GetQuantityForProduct_ZeroCount()
        {
            //Arrange
            int productType = 3;
            int materialType = 1;
            int count = 0;
            float width = 20;
            float length = 45;
            int expected = 0;
            //Act
            int result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetQuantityForProduct_CountLessZero()
        {
            //Arrange
            int productType = 3;
            int materialType = 1;
            int count = -1;
            float width = 20;
            float length = 45;
            int expected = -1;
            //Act
            int result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetQuantityForProduct_NonExistingProductType()
        {
            //Arrange
            int productType = 4;
            int materialType = 1;
            int count = 15;
            float width = 20;
            float length = 45;
            int expected = -1;
            //Act
            int result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetQuantityForProduct_NonExistingMaterialType()
        {
            //Arrange
            int productType = 3;
            int materialType = 3;
            int count = 15;
            float width = 20;
            float length = 45;
            int expected = -1;
            //Act
            int result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetQuantityForProduct_BothSideNegativeButSquarePositive()
        {
            //Arrange
            int productType = 3;
            int materialType = 1;
            int count = 15;
            float width = -20;
            float length = -45;
            int expected = -1;
            //Act
            int result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetQuantityForProduct_SquareLessZero()
        {
            //Arrange
            int productType = 3;
            int materialType = 1;
            int count = 15;
            float width = -20;
            float length = 45;
            int expected = -1;
            //Act
            int result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetQuantityForProduct_WidthValueLimitedByFloat()
        {
            //Arrange
            int productType = 3;
            int materialType = 1;
            int count = 15;
            float width = 5.0000000001f;
            float length = 5;
            int expected = 3171;
            double square = 5.0000000001 * length;
            double afterUseK = (square * 2.5) / (0.0012);
            int notExpected = (int)(afterUseK * count) + 1;
            //Act
            int result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            //Assert
            Assert.IsTrue(result == expected && result != notExpected);
        }

        [TestMethod]
        public void GetQuantityForProduct_ResultCantBePlacedInInt()
        {
            //Arrangle
            int productType = 2;
            int materialType = 1;
            int count = 100000;
            float width = 1200;
            float length = 1200;
            int expected = -1;
            //Act
            int result = Calculation.GetQuantityForProduct(productType, materialType, count, width, length);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
