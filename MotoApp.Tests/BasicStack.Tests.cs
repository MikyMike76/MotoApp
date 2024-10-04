using MotoApp;

namespace MotoApp.Tests
{
    public class BasicStackTests
    {
        [Test]
        public void WhenUsePushAndPop_ShouldGetCorrectSum()
        {
            //arrange
            BasicStack stack = new BasicStack();
            stack.Push(1);
            stack.Push(4);
            stack.Push(10);
            double sum = 0;
            //act
            while(stack.Count > 0)
            {
                double item = stack.Pop();
                sum += item;
            }
            //assert
            Assert.AreEqual(15, sum);
        }
    }
}