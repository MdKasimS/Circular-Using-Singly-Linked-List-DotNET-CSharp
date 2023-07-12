namespace DSA
{
    public class CircularSLL
    {
        private static int count = 0;
        private SLLNode? temp;
        private SLLNode? head;
        public SLLNode? Temp { get => temp; set => temp = value; }
        public SLLNode? Head { get => head; set => head = value; }
        public static int Count { get => count; set => count = value; }
        public CircularSLL()
        {
            Head = null;
            Temp = null;
        }
        public void AppendList(int data)
        {
            if (Head == null)
            {
                Head = new SLLNode(data);
                Head.Next = Head;
                Temp = Head;
                ++Count;
            }
            else
            {
                SLLNode newNode = new SLLNode(data);
                newNode.Next = Temp.Next;
                Temp.Next = newNode;
                Temp = Temp.Next;
                ++Count;
            }
        }
        public void DisplayList()
        {
            if (Head != null)
            {
                SLLNode? iterator = this.Head;
                for (int i = 0; i < Count; ++i)
                {
                    Console.Write($"{iterator.Data}-");
                    iterator = iterator.Next;
                }

                Console.WriteLine();
                iterator = Head;

                Console.WriteLine("Press DownArrow For Next Data. And Press Q To End....");
                ConsoleKeyInfo key = Console.ReadKey();
                while (key.Key != ConsoleKey.Q)// || iterator.Next != Head)
                {
                    if (key.Key == (ConsoleKey.DownArrow))
                    {
                        Console.Write($"{iterator.Data}-");
                        iterator = iterator.Next;
                    }
                    key = Console.ReadKey();
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("List Is Empty");
            }
        }
        public void PrependList(int data)
        {
            if (Head == null)
            {
                AppendList(data);
            }
            else
            {
                SLLNode oldHead = Head;
                Head = new SLLNode(data);
                Head.Next = oldHead;
                Temp.Next = Head;
                ++Count;
            }
        }
        public void InsertInList(int data, int pos)
        {
            SLLNode iterator = Head;
            SLLNode temp;
            if (pos <= Count + 1 || pos == 1)
            {
                if (Head != null)
                {
                    if (pos == 1)
                    {
                        PrependList(data);
                    }
                    else if (pos == Count + 1)
                    {
                        AppendList(data);
                    }
                    else
                    {
                        for (int i = 1; i < pos - 1; ++i)
                        {
                            // Console.Write($"{i}.{iterator.Data} - ");
                            // Console.ReadKey();
                            iterator = iterator.Next;
                        }
                        temp = iterator.Next;
                        iterator.Next = new SLLNode(data);
                        iterator = iterator.Next;
                        iterator.Next = temp;
                        ++Count;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Position");
            }
        }
        public void RotateForward(int pos)
        {
            if (pos < count)
            {
                for (int i = 0; i < pos; ++i)
                {
                    Head = Head.Next;
                    Temp = Temp.Next;
                }
            }
        }
        public void RotateBackward(int pos)
        {
            if (pos < Count)
            {
                for (int i = 0; i < pos; ++i)
                {
                    if (Head == null || Count == 1)
                    {
                        return;
                    }
                    SLLNode temp = Head;
                    while (temp.Next != Head && Count > 1)
                    {
                        if (Head == null || Count == 1)
                        {
                            return;
                        }
                        temp = temp.Next;
                    }
                    temp = temp.Next;
                    Head = Head.Next;
                    Temp = temp;

                }
            }
        }
        public void DeletListNode(int pos)
        {
            if (Head != null && pos <= Count)
            {
                SLLNode temp = Head;

                if (pos == 1)
                {
                    Head = Head.Next;
                    Temp.Next = Head;
                    --Count;
                    if (Count == 0)
                    {
                        Head = null;
                        Temp = null;
                    }
                }
                else if (pos == Count)
                {
                    for (int i = 0; i < pos - 2; ++i)
                    {
                        temp = temp.Next;
                    }
                    temp.Next = Head;
                    --Count;
                    Temp = temp;
                }
                else
                {
                    for (int i = 0; i < pos - 2; ++i)
                    {
                        // Console.Write($"{i}.{temp.Data} - ");
                        // Console.ReadKey();
                        temp = temp.Next;
                    }
                    if (temp.Next.Next != null)
                    {
                        temp.Next = temp.Next.Next;
                    }
                    else
                    {
                        temp.Next = null;
                        Temp = temp;
                    }
                    --Count;
                }
            }
            else
            {
                Console.WriteLine("Out Of Bound");
            }
        }
        public void UpdateNode(int data, int pos)
        {
            if (Head != null)
            {
                SLLNode temp = Head;
                if (pos <= Count)
                {

                    for (int i = 0; i < pos - 1; ++i)
                    {
                        // Console.Write($"{i + 1}. {temp.Data}");
                        Console.ReadKey();
                        temp = temp.Next;
                    }
                    temp.Data = data;
                    Console.WriteLine("Data updated successfully.....");
                }
                else
                {
                    Console.WriteLine("List is out of bound");
                }
            }
            else
            {
                Console.WriteLine("List Is Empty");
                Console.ReadKey();
            }
        }
    }
}