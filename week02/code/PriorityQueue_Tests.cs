using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Adding three items with different priorities, where the highest priority
    // item is added last (at the back of the queue): "Low" (priority 1), "Medium"
    // (priority 5), "High" (priority 10). Dequeue once.
    // Expected Result: "High" should come out, since it has the highest priority,
    // regardless of the order the items were added in.
    // Defect(s) Found: Dequeue's loop condition was `index < _queue.Count - 1`, which
    // stops one index before the end of the list, so the last item was never being compared
    // With "High" as the last item added, it never got checked, and "Medium" (a lower
    // priority item that isn't last) was returned instead.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Add two items with the SAME priority (5): "First" then "Second", plus
    // a lower priority item "Low" (priority 1) in between them. Dequeue twice.
    // Expected Result: Since "First" and "Second" are tied for highest priority, the
    // one closer to the front of the queue ("First") should come out before "Second",
    // following FIFO order for ties. "Low" should not come out yet.
    // Defect(s) Found: Dequeue never removes the item it finds from the internal list
    // (_queue) before returning its value — it only reads _queue[highPriorityIndex].Value.
    // So the same item ("First") is found and returned again on the second call instead
    // of "Second".
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Second", 5);

        var firstResult = priorityQueue.Dequeue();
        var secondResult = priorityQueue.Dequeue();

        Assert.AreEqual("First", firstResult);
        Assert.AreEqual("Second", secondResult);
    }

    [TestMethod]
    // Scenario: Try to dequeue from a brand new empty priority queue
    // Expected Result: An InvalidOperationException should be thrown with the message
    // "The queue is empty."
    // Defect(s) Found: None — this test passed without any changes.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                    e.GetType(), e.Message)
            );
        }
    }

    // Add more test cases as needed below.
}