using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace APIAutomationBDD.StepDefinitions
{
    [Binding]
    public class SumOfTwoNumbersStepDefinitions
    {
        int FirstNumber;
        int SecondNumber;
        int FinalNumber = 0;

        [Given(@"first number is (.*)")]
        public void GivenFirstNumberIs(int NumberOne)
        {
            FirstNumber = NumberOne;
            Console.WriteLine(FirstNumber);
        }

        [Given(@"Second number is (.*)")]
        public void GivenSecondNumberIs(int NumberTwo)
        {
            SecondNumber = NumberTwo;
            Console.WriteLine(SecondNumber);
        }

        [When(@"two numbers are added")]
        public void WhenTwoNumbersAreAdded()
        {
            FinalNumber = FirstNumber + SecondNumber;
            Console.WriteLine(FinalNumber);
        }

        [Then(@"result should be (.*)")]
        public void ThenResultShouldBe(int NumberThree)
        {
            Assert.AreEqual(FinalNumber, NumberThree);
        }
    }
}
