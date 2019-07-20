
namespace MT.TacticWar.Core
{
    public struct Money
    {
        public int value;

        #region Операторы

        /// <summary>Оператор сложения денег
        /// </summary>
        /// <param name="M1">деньги 1</param>
        /// <param name="M2">деньги 2</param>
        /// <returns></returns>
        public static Money operator +(Money M1, Money M2)
        {
            Money MRes;
            MRes.value = M1.value + M2.value;

            return MRes;
        }

        /// <summary>Оператор сложения числа к деньгам
        /// </summary>
        /// <param name="M1">деньги</param>
        /// <param name="chislo">число</param>
        /// <returns></returns>
        public static Money operator +(Money M1, int chislo)
        {
            Money MRes;
            MRes.value = M1.value + chislo;

            return MRes;
        }

        /// <summary>Оператор вычитания денег
        /// </summary>
        /// <param name="M1">деньги 1</param>
        /// <param name="M2">деньги 2</param>
        /// <returns></returns>
        public static Money operator -(Money M1, Money M2)
        {
            Money MRes;
            MRes.value = M1.value - M2.value;

            return MRes;
        }

        /// <summary>Оператор вычитания числа из денег
        /// </summary>
        /// <param name="M1">деньги</param>
        /// <param name="chislo">число</param>
        /// <returns></returns>
        public static Money operator -(Money M1, int chislo)
        {
            Money MRes;
            MRes.value = M1.value - chislo;

            return MRes;
        }

        /// <summary>Оператор умножения денег на число
        /// </summary>
        /// <param name="M1">деньги</param>
        /// <param name="chislo">число</param>
        /// <returns></returns>
        public static Money operator *(Money M1, int chislo)
        {
            Money MRes;
            MRes.value = M1.value * chislo;

            return MRes;
        }

        /// <summary>Оператор деления денег на число
        /// </summary>
        /// <param name="M1">деньги</param>
        /// <param name="chislo">число</param>
        /// <returns></returns>
        public static Money operator /(Money M1, int chislo)
        {
            Money MRes;
            MRes.value = M1.value / chislo;

            return MRes;
        }

        /// <summary>Оператор сравнения денег
        /// </summary>
        /// <param name="M1">деньги, которые сравнивают</param>
        /// <param name="M2">деньги, с которыми сравнивают</param>
        /// <returns></returns>
        public static bool operator ==(Money M1, Money M2)
        {
            return (M1.value == M2.value);
        }

        /// <summary>Оператор сравнения денег с числом
        /// </summary>
        /// <param name="M1">деньги, которые сравнивают</param>
        /// <param name="chislo">число, с которым сравнивают</param>
        /// <returns></returns>
        public static bool operator ==(Money M1, int chislo)
        {
            return (M1.value == chislo);
        }

        /// <summary>Оператор сравнения денег
        /// </summary>
        /// <param name="M1">деньги, которые сравнивают</param>
        /// <param name="M2">деньги, с которыми сравнивают</param>
        /// <returns></returns>
        public static bool operator !=(Money M1, Money M2)
        {
            return (M1.value != M2.value);
        }

        /// <summary>Оператор сравнения денег с числом
        /// </summary>
        /// <param name="M1">деньги, которые сравнивают</param>
        /// <param name="chislo">число, с которым сравнивают</param>
        /// <returns></returns>
        public static bool operator !=(Money M1, int chislo)
        {
            return (M1.value != chislo);
        }

        #endregion
    }
}
