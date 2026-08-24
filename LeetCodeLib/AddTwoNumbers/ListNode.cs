
using System.Text;

namespace LeetCodeLib.AddTwoNumbers;
public class ListNode : IEquatable<ListNode>, IEquatable<int>
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    /// <summary>
    /// Структурное сравнение: списки равны, если у них одинаковая длина
    /// и одинаковые значения val на каждой позиции.
    /// </summary>
    public bool Equals(ListNode other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        var a = this;
        var b = other;
        while (a != null && b != null)
        {
            if (a.val != b.val) return false;
            a = a.next;
            b = b.next;
        }

        return a is null && b is null;
    }

    /// <summary>
    /// Список интерпретируется как число (цифры от младшего разряда к старшему)
    /// и сравнивается с обычным int.
    /// </summary>
    public bool Equals(int other) => ToLong() == other;

    public override bool Equals(object obj)
    {
        return obj switch
        {
            ListNode node => Equals(node),
            int number => Equals(number),
            _ => false
        };
    }

    public override int GetHashCode()
    {
        // Приводим к int, чтобы хэш совпадал с int.GetHashCode() для тех же значений
        // (long.GetHashCode() для чисел в диапазоне int даёт то же самое значение,
        // но явное приведение делает это гарантией, а не совпадением).
        return unchecked((int)ToLong()).GetHashCode();
    }

    /// <summary>Переводит список цифр в число.</summary>
    public long ToLong()
    {
        long result = 0;
        long multiplier = 1;
        var node = this;
        while (node != null)
        {
            result += node.val * multiplier;
            multiplier *= 10;
            node = node.next;
        }
        return result;
    }

    public static bool operator ==(ListNode left, ListNode right)
        => left is null ? right is null : left.Equals(right);

    public static bool operator !=(ListNode left, ListNode right) => !(left == right);

    public static bool operator ==(ListNode left, int right) => left is not null && left.Equals(right);
    public static bool operator !=(ListNode left, int right) => !(left == right);

    public static bool operator ==(int left, ListNode right) => right == left;
    public static bool operator !=(int left, ListNode right) => !(right == left);

    /// <summary>Удобно для Assert.Equal(352, node) в тестах и для отладки.</summary>
    public static implicit operator int(ListNode node) => node is null ? 0 : (int)node.ToLong();

    /// <summary>Быстрый конструктор из числа — удобно для тестовых данных.</summary>
    public static ListNode FromNumber(int number)
    {
        if (number < 0)
            throw new ArgumentOutOfRangeException(nameof(number), "Ожидается неотрицательное число.");

        var dummy = new ListNode();
        var current = dummy;
        do
        {
            current.next = new ListNode(number % 10);
            current = current.next;
            number /= 10;
        } while (number > 0);

        return dummy.next;
    }

    public override string ToString()
    {
        var sb = new StringBuilder("[");
        var node = this;
        var first = true;
        while (node != null)
        {
            if (!first) sb.Append(", ");
            sb.Append(node.val);
            first = false;
            node = node.next;
        }
        sb.Append(']');
        return sb.ToString();
    }
}