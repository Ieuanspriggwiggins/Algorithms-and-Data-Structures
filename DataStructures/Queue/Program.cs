class Program 
{
    public static void Main(string[] args) 
    {
        Queue<string> queue = new();

        queue.Enqueue("First insert");
        queue.Enqueue("Second insert");
        queue.Enqueue("Third insert");
        queue.Enqueue("Fourth insert");

        Console.WriteLine(queue.Size());
    }
}

class Queue<T> 
{

    Node? head;
    Node? tail;


    /// <summary>
    /// Insert an item into the queue
    /// </summary>
    /// <param name="data">The data being inserted</param>
    public void Enqueue(T data) 
    {
        Node NewNode = new(data);
        
        if(head == null || tail == null)
        {
            head = NewNode;
            tail = NewNode;
            return;
        }
        else
        {
            tail.NextNode = NewNode;
            tail = NewNode;
        }
    }


    /// <summary>
    /// Remove an item from the queue (removes from the front) and returns data.
    /// </summary>
    /// <returns>Returned object</returns>
    public T? Dequeue()
    {
        //If the queue is empty, return null.
        if(head == null || tail == null)
        {
            return default;
        }

        //Remove the current head (front of list).
        Node CurrentHead = head;
        head = CurrentHead.NextNode;
        return CurrentHead.data;
    }


    /// <summary>
    /// Return the item at start of the queue without removing it.
    /// </summary>
    /// <returns></returns>
    public T? Peek() 
    {
        if(head == null || tail == null)
        {
            return default;
        }

        return head.data;
    }

    /// <summary>
    /// Returns a boolean representing if the list is empty.
    /// </summary>
    /// <returns>False - queue is not empty, True - queue is empty</returns>
    public bool IsEmpty()
    {
        return head == null || tail == null;
    }

    /// <summary>
    /// Returns the amount of items stored in the queue (runtime O(n) )
    /// </summary>
    /// <returns>Size of elements in the queue</returns>
    public int Size() 
    {
        //If there are no items in the queue, return 0.
        if(tail == null || head == null)
        {
            return 0;
        }

        //Otherwise count the queue 
        int count = 0;
        Node? CurrentNode = head;
        while(CurrentNode != null)
        {
            CurrentNode = CurrentNode.NextNode;
            count++;
        }

        return count;
    }

    private class Node
    {
        public T data;

        public Node? NextNode;

        public Node(T data)
        {
            this.data = data;
            this.NextNode = null;
        }
    }
}