StringsDictionary dictWords = new StringsDictionary();
foreach (var line in File.ReadAllLines("dictionary.txt"))
{
    string[] elements = line.Split("; ");
    string key = elements[0];
    string value = String.Join("; ", elements[1..]);
    
    dictWords.Add(key, value);
}

bool valid = true;
while (valid)
{
    Console.Write("enter a word: ");
    string word = Console.ReadLine();
    Console.WriteLine(dictWords.Get(word.ToUpper()));
    Console.WriteLine();
    Console.Write("do you want to continue?[y/n] ");
    string YesNo = Console.ReadLine();

    if (YesNo == "n")
    {
        Console.WriteLine("goodbye sunshine");
        valid = false;
    }
}

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
        if (_first == null)
        {
            _first = new LinkedListNode(pair);
            _first.Next = null;
        }
        else
        {
            LinkedListNode add = new LinkedListNode(pair);
            var current = _first;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = add;
        }
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
        while (current != null)
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
        var hashKey = CalculateHash(key);
        var bucketNum = hashKey % InitialSize;
        if (_buckets[bucketNum] == null) _buckets[bucketNum] = new LinkedList();
        
        _buckets[bucketNum].Add(new KeyValuePair(key, value));

    }

    public void Remove(string key)
    {
        var hashKey = CalculateHash(key);
        var bucketNum = hashKey % InitialSize;
        if (_buckets[bucketNum] != null)
        {
            _buckets[bucketNum].RemoveByKey(key);
        }
    }

    public string Get(string key)
    {
        var hashKey = CalculateHash(key);
        var bucketNum = hashKey % InitialSize;
        if (_buckets[bucketNum] == null)
        {
            Console.WriteLine("there is no such word in this dict");
            return null;
        }
        
        var value = _buckets[bucketNum].GetItemWithKey(key);
        if (value == null)
        {
            return ("there is no such word in this dict");
        }
        return value.Value;
    }


    private long CalculateHash(string key)
    {
        // function to convert string value to number 
        var keys = key.ToCharArray();
        Int64 hashcode = 0;
        int counter = 0;
        foreach (var variable in keys)
        {
            var byteChar = (Int64)variable;
            hashcode += Convert.ToInt64(byteChar * (Int64)Math.Pow(2, counter));
            counter++;
        }

        return hashcode;
    }
}