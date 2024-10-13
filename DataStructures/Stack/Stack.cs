/// <summary>
/// The stack class 
/// </summary>
/// <typeparam name="T">Data type stored in instance of stack</typeparam>
class Stack<T> {


    //The top of the stack
    private Node? top;

    public Stack() 
    {
        this.top = null;
    }

    /// <summary>
    /// Pushes a new item onto the stack
    /// </summary>
    /// <param name="data"></param>
    public void Push(T data) 
    {
        //Create a new node to be pushed onto the stack
        Node NewNode = new(data);

        //If there are no items currently in the stack, set the top of the stack to the new item
        if(this.IsEmpty())
        {
            top = NewNode;
            return;
        }

        //Otherwise, set the next node of the new node to the currenet top node, and set the top to the new node.
        NewNode.NextNode = top;
        top = NewNode;
    }
    
    /// <summary>
    /// Returns boolean value for if the stack is empty or not 
    /// </summary>
    /// <returns>Boolean - is list empty or not</returns>
    public bool IsEmpty() 
    {
        //If the top is null, there are no items in the stack
        return this.top == null;
    } 

    /// <summary>
    /// Returns the object stored at the top of the stack without removing it from the stack.
    /// </summary>
    /// <returns></returns>
    public T? Peek() 
    {
        //If the list is empty return default. Otherwise return the top item.
        if(top is null)
        {
            return default;
        }else{
            return top.data;
        }
    }

    /// <summary>
    /// Returns the item at the top of the stack and removes it from the stack.
    /// </summary>
    /// <returns>Object at the top of the stack</returns>
    public T? Pop() 
    {
        if(top is null)
        {
            return default;
        }
        else
        {
            //Temporarily store the top object
            Node TopCopy = top;
            top = TopCopy.NextNode;
            return TopCopy.data;
        }
    }

    /// <summary>
    /// Returns the amount of items currently present in the stack as an integer value. Starts counting frm 1 (if only one item is in the stack it will return 1 rather than 0 indexing).
    /// </summary>
    /// <returns>Integer value for size of stack</returns>
    public int Size()
    {
        //if the list is empty, return 0.
        if(top is null)
        {
            return 0;
        }

        //Otherwise, iterate through items and count
        int count = 0;
        Node? CurrentNode = top;
        do{
            count++;
            CurrentNode = CurrentNode.NextNode;
        }while(CurrentNode != null);

        return count;
    }

    /// <summary>
    /// Node used for storing data in the stack.
    /// </summary>
    private class Node {
        public T data;

        //Reference to the node 'under' this node in the stack. Null represents bottom of the stack
        public Node? NextNode;

        public Node(T data) 
        {
            this.data = data;
            NextNode = null;
        }
    }
}