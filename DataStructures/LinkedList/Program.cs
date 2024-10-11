using System.Text;

/// <summary>
/// The main program class containing the main method
/// </summary>
class Program {

    /// <summary>
    /// Main method
    /// </summary>
    /// <param name="args">Program arguments</param>
    public static void Main(string[] args)
    {   
        LinkedList<string> list = new();
        list.InsertAtHead("First insert");
        list.InsertAtHead("Second Insert");
        Console.WriteLine(list.ToString());
    }
}


/// <summary>
/// Implementation of the linked list data structure.
/// </summary>
/// <typeparam name="T">The data type being stored in the linked list</typeparam>
class LinkedList<T> {

    private Node? head = null;
    private Node? tail = null;

    //TODO: Implement adding to head of the list
    public void InsertAtHead(T data)
    {
        //Create the new node for insertion
        Node NewNode = new(data);

        //Check if the list is empty (the head being equal to null)
        if(head is null) 
        {
            head = NewNode;
            tail = NewNode;
            return;
        }

        //If the list isn't empty, we want to update the beginning of the list
        NewNode.NextNode = head;
        head = NewNode;
    }

    //TODO: Implement adding to the end of the list

    //TODO: Implement finding certain data in the list

    //TODO: Implement getting data stored at certain index.

    //TODO: Implement ToString method
    public override string ToString() {
        //If the list is empty, return a warning that the list is empty
        if(head is null) 
        {
            return "Warning: The list is currently empty";
        }

        Node? currentNode = head;
        
        StringBuilder stringBuilder = new();
        int index = 0;
        do{
            if(currentNode.data is not null)
            {
                //Use the data being stored ToString method to enforce consistency across different types
                stringBuilder.Append($"{index}. {currentNode.data.ToString()}\n");
            }

            currentNode = currentNode.NextNode;
            index++;
        }while(currentNode != null);

        return stringBuilder.ToString();
    }

    /// <summary>
    /// Node used in the data structure. Cannot be accessed outside the LinkedList class.
    /// </summary>
    private sealed class Node {
        public T data {get; set;}

        public Node? NextNode;

        /// <summary>
        /// Constructure for the node. Node cannot be created without holding some sort of data.
        /// </summary>
        /// <param name="data"></param>
        public Node(T data) 
        {
            this.data = data;
        }
    }
}