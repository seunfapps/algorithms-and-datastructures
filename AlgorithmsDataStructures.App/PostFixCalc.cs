using System;
using AlgorithmsDataStructures.Algorithms;

namespace AlgorithmsDataStructures.App
{
    public class PostFixCalc
    {
        Stack<int> stack = new Stack<int>();

        public int Solve(string input)
        {
            char[] inputArray = input.ToCharArray();

            for(int i = 0; i < inputArray.Length; i++)
            {
                int operand;
                if(Int32.TryParse(inputArray[i].ToString(), out operand))
                {
                    stack.Push(operand);
                }
                else
                {
                    int operandB = stack.Pop(); //rhs
                    int operandA = stack.Pop(); //lhs

                    int result = Operate(operandA, operandB, inputArray[i].ToString());

                    stack.Push(result);
                }
            }

            return stack.Pop();
        }

        public int Operate (int operandA, int operandB, string op)
        {
            switch (op)
            {
                case "+":
                    return operandA + operandB;
                case "-":
                    return operandA - operandB;
                case "/":
                    return operandA / operandB;
                case "*":
                    return operandA * operandB;
                default:
                    throw new InvalidOperationException("Invalid Operator");
            }
        }
    }
}
