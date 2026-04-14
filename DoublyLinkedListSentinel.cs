public class DoublyLinkedListSentinel
{
    private Node headSentinel;
    private Node tailSentinel;

    public DoublyLinkedListSentinel()
    {
        headSentinel = new Node(-1);
        tailSentinel = new Node(-1);

        headSentinel.Next = tailSentinel;
        tailSentinel.Prev = headSentinel;
    }

    public void Add(int value)
    {
        var current = headSentinel.Next;

        while (current != tailSentinel)
        {
            if (current.IsFree)
            {
                current.Data = value;
                current.IsFree = false;
                return;
            }

            current = current.Next;
        }

        var node = new Node(value);
        node.IsFree = false;

        var last = tailSentinel.Prev;

        last.Next = node;
        node.Prev = last;

        node.Next = tailSentinel;
        tailSentinel.Prev = node;
    }

    public Node? Find(int value)
    {
        var current = headSentinel.Next;

        while (current != tailSentinel)
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
        var current = headSentinel.Next;

        while (current != tailSentinel)
        {
            var next = current.Next;

            if (current.IsFree)
            {
                current.Prev!.Next = current.Next;
                current.Next!.Prev = current.Prev;
            }

            current = next;
        }
    }

    public IEnumerable<int> ActiveValues()
    {
        var current = headSentinel.Next;

        while (current != tailSentinel)
        {
            if (!current.IsFree)
                yield return current.Data;

            current = current.Next;
        }
    }
}

