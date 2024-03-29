﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibraryLab10;
using MsTestClassLab10;
using System.IO;
using System.Linq;

namespace MsTestClassLab10
{
    [TestClass]
    public class UnitTestClassLibrary
    {
        [TestMethod]
        public void TestValidId()
        {
            // Arrange
            Card card = new Card();

            // Act
            card.Id = "1234 5678 9012 3456";

            // Assert
            Assert.AreEqual("1234 5678 9012 3456", card.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestInvalidId()
        {
            // Arrange
            Card card = new Card();

            // Act
            card.Id = "invalid_id";
        }
        [TestMethod]
        public void Id_SetValidId_ShouldNotThrowException()
        {
            // Arrange
            Card card = new Card();
            string validId = "1234 5678 9012 3456";

            // Act
            card.Id = validId;

            // Assert
            Assert.AreEqual(validId, card.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Id_SetInvalidId_ShouldThrowException()
        {
            // Arrange
            Card card = new Card();
            string invalidId = "invalid_id";

            // Act
            card.Id = invalidId;
        }

        [TestMethod]
        public void Name_SetValidName_ShouldNotThrowException()
        {
            // Arrange
            Card card = new Card();
            string validName = "John Doe";

            // Act
            card.Name = validName;

            // Assert
            Assert.AreEqual(validName, card.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Name_SetInvalidName_ShouldThrowException()
        {
            // Arrange
            Card card = new Card();
            string invalidName = "A"; // Invalid name length

            // Act
            card.Name = invalidName;
        }

        [TestMethod]
        public void Time_SetValidTime_ShouldNotThrowException()
        {
            // Arrange
            Card card = new Card();
            string validTime = "01 23";

            // Act
            card.Time = validTime;

            // Assert
            Assert.AreEqual(validTime, card.Time);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Time_SetNullTime_ShouldThrowException()
        {
            // Arrange
            Card card = new Card();

            // Act
            card.Time = null;
        }
        [TestMethod]
        public void CardConstructor_CreateCardWithValidParameters_ShouldNotThrowException()
        {
            // Arrange
            string validId = "1234 5678 9012 3456";
            string validName = "John Doe";
            string validTime = "12 25";
            int validNumber = 42;

            // Act
            Card card = new Card(validId, validName, validTime, validNumber);

            // Assert
            Assert.AreEqual(validId, card.Id);
            Assert.AreEqual(validName, card.Name);
            Assert.AreEqual(validTime, card.Time);
            Assert.AreEqual(validNumber, card.num.number);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CardConstructor_CreateCardWithInvalidId_ShouldThrowException()
        {
            // Arrange
            string invalidId = "invalid";

            // Act
            Card card = new Card(invalidId, "John Doe", "12 25", 42);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CardConstructor_CreateCardWithInvalidName_ShouldThrowException()
        {
            // Arrange
            string invalidName = "A"; // Invalid name length

            // Act
            Card card = new Card("1234 5678 9012 3456", invalidName, "12 25", 42);
        }
        [TestMethod]
        public void CardShowMethod_DisplayCardInfo_ShouldWriteToConsole()
        {
            // Arrange
            Card card = new Card("1234 5678 9012 3456", "John Doe", "12 25", 42);

            // Redirect Console output to a StringWriter
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                card.Show();

                // Assert
                string expectedOutput = $"ID: {card.Id} \t Имя: {card.Name} \t Срок действия: {card.Time} \t Номер: {card.num}";
                Assert.AreEqual(expectedOutput, sw.ToString().Trim());
            }
        }
        [TestMethod]
        public void CardInitMethod_SetPropertiesFromUserInput_ShouldInitializeProperties()
        {
            // Arrange
            Card card = new Card();
            string userInput =
                "1234 5678 9012 3456\n" +   // ID
                "John Doe\n" +             // Name
                "12 25\n" +                 // Time
                "42";                       // Number

            using (StringReader sr = new StringReader(userInput))
            {
                Console.SetIn(sr);

                // Act
                card.Init();

                // Assert
                Assert.AreEqual("1234 5678 9012 3456", card.Id);
                Assert.AreEqual("John Doe", card.Name);
                Assert.AreEqual("12 25", card.Time);
                Assert.AreEqual(42, card.num.number);
            }
        }
        public class CardGenerateRandomIdMethodTests
        {
            [TestMethod]
            public void CardGenerateRandomIdMethod_ShouldGenerateValidId()
            {
                // Arrange
                Card card = new Card();

                // Act
                string randomId = card.GenerateRandomId();

                // Assert
                Assert.IsNotNull(randomId);
                Assert.IsTrue(randomId.Length == 19, "Length of generated ID should be 19");
                Assert.IsTrue(randomId.All(char.IsDigit) || randomId[4] == ' ' || randomId[9] == ' ' || randomId[14] == ' ',
                              "Generated ID should contain only digits and spaces at positions 4, 9, and 14");
            }
        }
        [TestMethod]
        public void CardToStringMethod_ShouldReturnValidString()
        {
            // Arrange
            Card card = new Card
            {
                Id = "1234 5678 9012 3456",
                Name = "John Doe",
                Time = "12 25",
                num = new IdNumber(42)
            };

            // Act
            string resultString = card.ToString();

            // Assert
            string expectedString = "1234 5678 9012 3456 John Doe 12 25 42";
            Assert.AreEqual(expectedString, resultString, $"Expected: {expectedString}, Actual: {resultString}");
        }
        [TestMethod]
        public void CardEqualsMethod_ShouldReturnTrueForEqualObjects()
        {
            // Arrange
            Card card1 = new Card
            {
                Id = "1234 5678 9012 3456",
                Name = "John Doe",
                Time = "12 25",
                num = new IdNumber(42)
            };

            Card card2 = new Card
            {
                Id = "1234 5678 9012 3456",
                Name = "John Doe",
                Time = "12 25",
                num = new IdNumber(42)
            };

            // Act
            bool areEqual = card1.Equals(card2);

            // Assert
            Assert.IsTrue(areEqual, "Expected objects to be equal");
        }

        [TestMethod]
        public void CardEqualsMethod_ShouldReturnFalseForDifferentObjects()
        {
            // Arrange
            Card card1 = new Card
            {
                Id = "1234 5678 9012 3456",
                Name = "John Doe",
                Time = "12 25",
                num = new IdNumber(42)
            };

            Card card2 = new Card
            {
                Id = "9876 5432 1098 7654",
                Name = "Jane Doe",
                Time = "09 21",
                num = new IdNumber(99)
            };

            // Act
            bool areEqual = card1.Equals(card2);

            // Assert
            Assert.IsFalse(areEqual, "Expected objects to be different");
        }
        [TestMethod]
        public void CardCompareToMethod_ShouldReturnNegativeValueWhenThisIsLessThanOther()
        {
            // Arrange
            Card card1 = new Card
            {
                Id = "1234 5678 9012 3456",
                Name = "John Doe",
                Time = "12 25",
                num = new IdNumber(42)
            };

            Card card2 = new Card
            {
                Id = "5678 1234 9012 3456",
                Name = "Jane Doe",
                Time = "09 21",
                num = new IdNumber(99)
            };

            // Act
            int result = card1.CompareTo(card2);

            // Assert
            Assert.IsTrue(result < 0, "Expected negative value");
        }

        [TestMethod]
        public void CardCompareToMethod_ShouldReturnZeroWhenThisIsEqualToOther()
        {
            // Arrange
            Card card1 = new Card
            {
                Id = "1234 5678 9012 3456",
                Name = "John Doe",
                Time = "12 25",
                num = new IdNumber(42)
            };

            Card card2 = new Card
            {
                Id = "1234 5678 9012 3456",
                Name = "Jane Doe",
                Time = "09 21",
                num = new IdNumber(99)
            };

            // Act
            int result = card1.CompareTo(card2);

            // Assert
            Assert.AreEqual(0, result, "Expected zero");
        }

        [TestMethod]
        public void CardCompareToMethod_ShouldReturnPositiveValueWhenThisIsGreaterThanOther()
        {
            // Arrange
            Card card1 = new Card
            {
                Id = "5678 1234 9012 3456",
                Name = "John Doe",
                Time = "12 25",
                num = new IdNumber(42)
            };

            Card card2 = new Card
            {
                Id = "1234 5678 9012 3456",
                Name = "Jane Doe",
                Time = "09 21",
                num = new IdNumber(99)
            };

            // Act
            int result = card1.CompareTo(card2);

            // Assert
            Assert.IsTrue(result > 0, "Expected positive value");
        }
    }
    [TestClass]
    public class DebitCardTests
    {
        [TestMethod]
        public void TestBalanceProperty_WithValidValue_ShouldSetBalance()
        {
            // Arrange
            DebitCard debitCard = new DebitCard();

            // Act
            debitCard.Balance = 5000;

            // Assert
            Assert.AreEqual(5000, debitCard.Balance);
        }


        [TestMethod]
        public void TestBalanceProperty_WithExceedingLimit_ShouldThrowException()
        {
            // Arrange
            DebitCard debitCard = new DebitCard();

            // Act & Assert
            Assert.ThrowsException<Exception>(() => debitCard.Balance = 15000000);
        }

        [TestMethod]
        public void TestDebitCardDefaultConstructor_ShouldSetBalanceToZero()
        {
            // Arrange & Act
            DebitCard debitCard = new DebitCard();

            // Assert
            Assert.AreEqual(0, debitCard.Balance);
        }

        [TestMethod]
        public void TestDebitCardParameterizedConstructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string id = "1234 5678 9012 3456";
            string name = "John Doe";
            string time = "12 25";
            int num = 42;
            int balance = 5000;

            // Act
            DebitCard debitCard = new DebitCard(id, name, time, num, balance);

            // Assert
            Assert.AreEqual(id, debitCard.Id);
            Assert.AreEqual(name, debitCard.Name);
            Assert.AreEqual(time, debitCard.Time);
            Assert.AreEqual(num, debitCard.num.number);
            Assert.AreEqual(balance, debitCard.Balance);
        }
        [TestMethod]
        public void TestDebitCardShallowCopyMethod_ShouldReturnShallowCopy()
        {
            // Arrange
            DebitCard originalDebitCard = new DebitCard("1234 5678 9012 3456", "John Doe", "12 25", 1, 5000);

            // Act
            DebitCard shallowCopy = (DebitCard)originalDebitCard.ShallowCopy();

            // Assert
            Assert.AreEqual(originalDebitCard.Id, shallowCopy.Id);
            Assert.AreEqual(originalDebitCard.Name, shallowCopy.Name);
            Assert.AreEqual(originalDebitCard.Time, shallowCopy.Time);
            Assert.AreEqual(originalDebitCard.Balance, shallowCopy.Balance);
        }
        [TestMethod]
        public void TestDebitCardShowMethod_ShouldPrintCorrectInfo()
        {
            // Arrange
            DebitCard debitCard = new DebitCard("1234 5678 9012 3456", "John Doe", "12 25", 1, 5000);

            // Create a StringWriter to redirect console output
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                debitCard.Show();

                // Assert
                string expectedOutput = $"ID: {debitCard.Id} \t Имя: {debitCard.Name} \t Срок действия: {debitCard.Time} \t Баланс: {debitCard.Balance}" + Environment.NewLine;
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
        [TestMethod]
        public void TestDebitCardGenerateRandomBalance_ShouldReturnValidBalance()
        {
            // Arrange
            DebitCard debitCard = new DebitCard();

            // Act
            double randomBalance = debitCard.GenerateRandomBalance();

            // Assert
            Assert.IsTrue(randomBalance >= 1 && randomBalance <= 100000);
        }
    }
    [TestClass]
    public class CreditCardTests
    {
        [TestMethod]
        public void TestCreditCardLimit_SetValidLimit_ShouldSetLimit()
        {
            // Arrange
            CreditCard creditCard = new CreditCard();

            // Act
            creditCard.Limit = 5000;

            // Assert
            Assert.AreEqual(5000, creditCard.Limit);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestCreditCardLimit_SetInvalidLimit_ShouldThrowException()
        {
            // Arrange
            CreditCard creditCard = new CreditCard();

            // Act and Assert
            creditCard.Limit = 0;  // This should throw an exception
        }

        [TestMethod]
        public void TestCreditCardTimeCredit_SetValidTimeCredit_ShouldSetTimeCredit()
        {
            // Arrange
            CreditCard creditCard = new CreditCard();

            // Act
            creditCard.TimeCredit = 24;

            // Assert
            Assert.AreEqual(24, creditCard.TimeCredit);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestCreditCardTimeCredit_SetInvalidTimeCredit_ShouldThrowException()
        {
            // Arrange
            CreditCard creditCard = new CreditCard();

            // Act and Assert
            creditCard.TimeCredit = 0;  // This should throw an exception
        }
        [TestMethod]
        public void TestCreditCardInit_InvalidInput_ShouldThrowException()
        {
            // Arrange
            CreditCard creditCard = new CreditCard();
            string invalidInput = "invalid input\n";

            // Act
            using (StringReader stringReader = new StringReader(invalidInput))
            {
                Console.SetIn(stringReader);

                // Assert
                Assert.ThrowsException<Exception>(() => creditCard.Init());
            }
        }
        [TestMethod]
        public void TestCreditCardRandomInit_ShouldInitializePropertiesRandomly()
        {
            // Arrange
            CreditCard creditCard = new CreditCard();

            // Act
            creditCard.RandomInit();

            // Assert
            Assert.IsTrue(creditCard.Limit >= 10000 && creditCard.Limit <= 10000000);
            Assert.IsTrue(creditCard.TimeCredit >= 1 && creditCard.TimeCredit <= 97);
        }
    }
    [TestClass]
    public class JunCardTests
    {
        [TestMethod]
        public void TestJunCardRandomInitMethod_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            JunCard junCard = new JunCard();

            // Act
            junCard.RandomInit();

            // Assert
            Assert.IsNotNull(junCard.Id);
            Assert.IsNotNull(junCard.Name);
            Assert.IsNotNull(junCard.Time);
            Assert.IsTrue(junCard.CashBack >= 1 && junCard.CashBack <= 100);
        }
        [TestMethod]
        public void TestJunCardParameterizedConstructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            string id = "1111 1111 1111 1111";
            string name = "John Doe";
            string time = "12 25";
            int num = 42;
            int balance = 1000;
            int cashBack = 5;

            // Act
            JunCard junCard = new JunCard(id, name, time, num, balance, cashBack);

            // Assert
            Assert.AreEqual(id, junCard.Id);
            Assert.AreEqual(name, junCard.Name);
            Assert.AreEqual(time, junCard.Time);
            Assert.AreEqual(num, junCard.num.number);
            Assert.AreEqual(balance, junCard.Balance);
            Assert.AreEqual(cashBack, junCard.CashBack);
        }
    }
    [TestClass]
    public class SortByTimeTests
    {
        [TestMethod]
        public void Compare_TwoCardsWithEarlierFirst_ShouldReturnNegative()
        {
            // Arrange
            SortByTime sorter = new SortByTime();
            Card card1 = new Card { Time = "01 22" };
            Card card2 = new Card { Time = "03 23" };

            // Act
            int result = sorter.Compare(card1, card2);

            // Assert
            Assert.IsTrue(result < 0, "Expected negative value");
        }

        [TestMethod]
        public void Compare_TwoCardsWithLaterFirst_ShouldReturnPositive()
        {
            // Arrange
            SortByTime sorter = new SortByTime();
            Card card1 = new Card { Time = "05 24" };
            Card card2 = new Card { Time = "02 23" };

            // Act
            int result = sorter.Compare(card1, card2);

            // Assert
            Assert.IsTrue(result > 0, "Expected positive value");
        }

        [TestMethod]
        public void Compare_TwoCardsWithSameTime_ShouldReturnZero()
        {
            // Arrange
            SortByTime sorter = new SortByTime();
            Card card1 = new Card { Time = "04 23" };
            Card card2 = new Card { Time = "04 23" };

            // Act
            int result = sorter.Compare(card1, card2);

            // Assert
            Assert.AreEqual(0, result, "Expected zero");
        }
    }
    [TestClass]
    public class IdNumberTests
    {
        [TestMethod]
        public void IdNumber_Constructor_ValidNumber_ShouldInitializeNumber()
        {
            // Arrange
            int validNumber = 42;

            // Act
            IdNumber idNumber = new IdNumber(validNumber);

            // Assert
            Assert.AreEqual(validNumber, idNumber.number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IdNumber_Constructor_InvalidNumber_ShouldThrowArgumentException()
        {
            // Arrange
            int invalidNumber = -5;

            // Act
            IdNumber idNumber = new IdNumber(invalidNumber);
        }

        [TestMethod]
        public void IdNumber_ToString_ShouldReturnNumberAsString()
        {
            // Arrange
            int number = 42;
            IdNumber idNumber = new IdNumber(number);

            // Act
            string result = idNumber.ToString();

            // Assert
            Assert.AreEqual(number.ToString(), result);
        }

        [TestMethod]
        public void IdNumber_Equals_SameNumber_ShouldReturnTrue()
        {
            // Arrange
            int number = 42;
            IdNumber idNumber1 = new IdNumber(number);
            IdNumber idNumber2 = new IdNumber(number);

            // Act
            bool result = idNumber1.Equals(idNumber2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IdNumber_Equals_DifferentNumber_ShouldReturnFalse()
        {
            // Arrange
            IdNumber idNumber1 = new IdNumber(42);
            IdNumber idNumber2 = new IdNumber(99);

            // Act
            bool result = idNumber1.Equals(idNumber2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IdNumber_Equals_NullObject_ShouldReturnFalse()
        {
            // Arrange
            IdNumber idNumber = new IdNumber(42);

            // Act
            bool result = idNumber.Equals(null);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IdNumber_Equals_NonIdNumberObject_ShouldReturnFalse()
        {
            // Arrange
            IdNumber idNumber = new IdNumber(42);
            object nonIdNumberObject = new object();

            // Act
            bool result = idNumber.Equals(nonIdNumberObject);

            // Assert
            Assert.IsFalse(result);
        }
    }
}