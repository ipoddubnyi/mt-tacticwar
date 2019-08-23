using System;

namespace MT.TacticWar.Core
{
    public class Operation
    {
        private string opstr;
        private OperationType operation;

        public Operation(string opstr)
        {
            this.opstr = opstr;
            operation = ConvertOperationType(opstr);
        }

        public bool Compare(int num1, int num2)
        {
            switch (operation)
            {
                case OperationType.Eq:
                    return num1 == num2;
                case OperationType.NotEq:
                    return num1 != num2;
                case OperationType.Lt:
                    return num1 < num2;
                case OperationType.Lte:
                    return num1 <= num2;
                case OperationType.Gt:
                    return num1 > num2;
                case OperationType.Gte:
                    return num1 >= num2;
            }

            return false;
        }

        public override string ToString()
        {
            return opstr;
        }

        //

        public static bool TryConvertOperationType(string op, out OperationType type)
        {
            try
            {
                type = ConvertOperationType(op);
            }
            catch
            {
                type = OperationType.Eq;
                return false;
            }

            return true;
        }

        public static OperationType ConvertOperationType(string opstr)
        {
            if (opstr.Equals("=") || opstr.Equals("=="))
                return OperationType.Eq;
            else if (opstr.Equals("!=") || opstr.Equals("<>"))
                return OperationType.NotEq;
            else if (opstr.Equals("<"))
                return OperationType.Lt;
            else if (opstr.Equals("<="))
                return OperationType.Lte;
            else if (opstr.Equals(">"))
                return OperationType.Gt;
            else if (opstr.Equals(">="))
                return OperationType.Gte;

            throw new Exception("Неизвестная операция.");
        }
    }
}
