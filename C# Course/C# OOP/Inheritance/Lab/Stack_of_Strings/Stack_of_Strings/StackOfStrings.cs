using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count != 0)
            {
                return false;
            }
            return true;
        }

        public Stack<string> AddRange()
        {

            return this;
        }
    }
}
