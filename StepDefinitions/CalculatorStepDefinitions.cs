using NUnit.Framework;
using TechTalk.SpecFlow;

namespace APIAutomationBDD.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        int FirstNumber;
        int SecondNumber;
        int sum = 0;

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number1)
        {
            FirstNumber = number1;
            Console.WriteLine(FirstNumber);
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number2)
        {
           SecondNumber = number2;
            Console.WriteLine(SecondNumber);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            sum = FirstNumber + SecondNumber;
            Console.WriteLine(sum);
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.AreEqual(sum, result);
        }
    }
}