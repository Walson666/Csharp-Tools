using System;

struct RangeArray<T>
{
    private T[] array;
    public int Length { get; private set; }
    public int lowerBound { get; private set; }
    public int upperBound { get; private set; }
    public RangeArray(int lowerIndex, int upperIndex)
    {
        upperIndex++;
        if (upperIndex < lowerIndex)
        {
            throw new RangeArrayException("Lower index less than upper");
        }
        array = new T[upperIndex - lowerIndex];
        Length = upperIndex - lowerIndex;
        lowerBound = lowerIndex;
        upperBound = --upperIndex;
    }
    public T this[int index]
    {
        get
        {
            if (CheckIndex(index))
            {
                return array[index - lowerBound];
            }
            else throw new RangeArrayException("Index out of range");

        }
        set
        {
            if (CheckIndex(index))
            {
                array[index - lowerBound] = value;
            }
            else throw new RangeArrayException("Index out of range");
        }
    }
    private bool CheckIndex(int index)
    {
        return index >= lowerBound & index <= upperBound;
    }
}
class RangeArrayException : Exception
{
    public RangeArrayException() : base() { }
    public RangeArrayException(string message) : base(message) { }
    public RangeArrayException(string message, Exception innerException) : base(message, innerException) { }
    public RangeArrayException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    public override string ToString()
    {
        return Message;
    }
}
