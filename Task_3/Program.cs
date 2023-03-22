public class KeyValuePair
{
    public string Key { get; }

    public string Value { get; }

    public KeyValuePair(string key, string value)
    {
        Key = key;
        Value = value;
    }
}


public class LinkedListNode
{
    public KeyValuePair Pair { get; }
        
    public LinkedListNode Next { get; set; }

    public LinkedListNode(KeyValuePair pair, LinkedListNode next = null)
    {
        Pair = pair;
        Next = next;
    }
}


public class LinkedList
{
    private LinkedListNode _first;

    public void Add(KeyValuePair pair)
    {
        // add provided pair to the end of the linked list
    }

    public void RemoveByKey(string key)
    {
        // remove pair with provided key
        if (_first == null) return;
        if (_first.Next.Pair.Key == key)
        {
            _first = _first.Next;
            return;
        }
        LinkedListNode current = _first;
        while (current.Next != null)
        {
            if (current.Next.Pair.Key == key)
            {
                current.Next = current.Next.Next;
                return;
            }

            current = current.Next;
        }
    }

    public KeyValuePair GetItemWithKey(string key)
    {
        // get pair with provided key, return null if not found
        if (_first == null) return null;
    
        LinkedListNode current = _first;
        while (current.Next != null)
        {
            if (current.Pair.Key == key)
            {
                return current.Pair;
            }

            current = current.Next;
        }

        return null;
    }
}



// dictionary
public class StringsDictionary
{
    private const int InitialSize = 10;

    private LinkedList[] _buckets = new LinkedList[InitialSize];
        
    public void Add(string key, string value)
    {
            
    }

    public void Remove(string key)
    {
            
    }

    public string Get(string key)
    {
            
    }


    private int CalculateHash(string key)
    {
        // function to convert string value to number 
    }
}