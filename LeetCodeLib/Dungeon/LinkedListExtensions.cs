namespace LeetCodeLib.Dungeon;

internal static class LinkedListExtensions
{
    public static void InsertBefore<T>(this LinkedList<T> list, T newV, Func<T, T, bool> skipPredicate)
    {
        var element = list.First;
        if(element == null)
        {
            list.AddFirst(newV);
            return;
        }

        while (skipPredicate(newV, element.Value))
        {
            if(element.Next == null)
            {
                list.AddLast(newV);
                return;
            }
            element = element.Next;
        }

        var newNode = new LinkedListNode<T>(newV);
        list.AddBefore(element, newNode);
    }

    public static T Pop<T>(this LinkedList<T> list)
    {
        var element = list.First;
        list.RemoveFirst();

        return element.Value;
    }
}
