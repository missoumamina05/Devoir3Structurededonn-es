using System.Collections.Generic;

public class DoublyLinkedList
{
    private Node? head;
    private Node? tail;

    public void AddLast(int value)
    {
        var node = new Node(value);

        if (head == null)
        {
            head = tail = node;
        }
        else
        {
            tail!.Next = node;
            node.Prev = tail;
            tail = node;
        }
    }

    public Node? Find(int value)
    {
        var current = head;

        while (current != null)
        {
            if (!current.IsFree && current.Data == value)
                return current;

            current = current.Next;
        }

        return null;
    }

    public bool LazyDelete(int value)
    {
        var node = Find(value);
        if (node == null)
            return false;

        node.IsFree = true;
        return true;
    }

    public void Compact()
    {
        var current = head;

        while (current != null)
        {
            var next = current.Next;

            if (current.IsFree)
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    tail = current.Prev;
            }

            current = next;
        }
    }

    public IEnumerable<int> ActiveValues()
    {
        var current = head;

        while (current != null)
        {
            if (!current.IsFree)
                yield return current.Data;

            current = current.Next;
        }
    }
}
