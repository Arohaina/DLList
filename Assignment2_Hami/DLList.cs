using Assignment2_Hami;
using System;
using System.Text;

public class DLList
{
    public Node Head { get; set; }
    public Node Tail { get; set; }
    public Node Current { get; set; }
    public int Count { get; private set; }

    public DLList()
    {
        Head = null;
        Tail = null;
        Current = null;
        Count = 0;
    }

    public void Insert(string word)
    {
        // Check for duplicates
        if (Find(word) != null)
            return;

        Node newNode = new Node(word);
        if (Head == null)
        {
            Head = Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
        }
        Count++;
    }

    public Node Find(string word)
    {
        Node current = Head;
        while (current != null)
        {
            if (current.Word.Equals(word, StringComparison.OrdinalIgnoreCase))
                return current;
            current = current.Next;
        }
        return null;
    }

    public bool Delete(string word)
    {
        Node nodeToDelete = Find(word);
        if (nodeToDelete == null)
            return false;

        if (nodeToDelete == Head)
        {
            Head = Head.Next;
            if (Head != null)
                Head.Prev = null;
        }
        else if (nodeToDelete == Tail)
        {
            Tail = Tail.Prev;
            if (Tail != null)
                Tail.Next = null;
        }
        else
        {
            nodeToDelete.Prev.Next = nodeToDelete.Next;
            nodeToDelete.Next.Prev = nodeToDelete.Prev;
        }
        Count--;
        return true;
    }

    public override String ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (Head == null)
        {
            sb.Append("List is empty");
            return sb.ToString();
        }
        else
        {
            Current = Head;
            int pos = 1;
            while (Current != null)
            {
                sb.Append("Node " + pos.ToString() + " -> " + Current.ToPrint() + "\n");

                Current = Current.Next;
                pos++;
            }
        }
        return sb.ToString();
    }
}
