#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MiscUtil;

#endregion

namespace C21_Ex02_01.Team.Misc
{
    public static class InputUtil
    {
        private const string k_BadInputMessage =
            "Bad input. Please try again...";

        /// <summary>
        ///     Converts a generic input string to an object.
        /// </summary>
        public static T Convert<T>(string i_Message)
        {
            Console.Out.WriteLine(i_Message);
            string input = Console.ReadLine();
            try
            {
                // Create converter
                TypeConverter converter =
                    TypeDescriptor.GetConverter(typeof(T));

                // Cast ConvertFromString(string text) : object to (T)
                return (T) converter.ConvertFromString(input);
            }
            catch (Exception)
            {
                Console.Out.WriteLine(k_BadInputMessage);
                return Convert<T>(i_Message);
            }
        }

        /// <summary>
        ///     Converts a generic input string to an object, with a given range.
        /// </summary>
        public static T Convert<T>(string i_Message, T i_MinimumRange,
            T i_MaximumRange)
        {
            T converted = Convert<T>(i_Message);
            if (!isConvertedInRange(converted, i_MinimumRange, i_MaximumRange)
            )
            {
                Console.Out.WriteLine(k_BadInputMessage);
                return Convert(i_Message, i_MinimumRange, i_MaximumRange);
            }

            return converted;
        }

        /// <summary>
        ///     Generic comparison by range.
        ///     <see cref="Operator" />
        ///     <seealso cref="MiscUtil" />
        /// </summary>
        /// <param name="i_Converted" />
        /// <param name="i_MinimumRange" />
        /// <param name="i_MaximumRange" />
        /// <typeparam name="T">Must be Comparable</typeparam>
        /// <returns />
        private static bool isConvertedInRange<T>(T i_Converted,
            T i_MinimumRange, T i_MaximumRange)
        {
            return Operator.LessThanOrEqual(i_Converted, i_MaximumRange) &&
                   Operator
                       .GreaterThanOrEqual(i_Converted, i_MinimumRange);
        }

        /// <summary>
        ///     Converts a generic input char to an object.
        /// </summary>
        public static T ConvertKey<T>(string i_Message)
        {
            Console.Out.WriteLine(i_Message);
            char input = Console.ReadKey(true).KeyChar;
            try
            {
                // Create converter
                TypeConverter converter =
                    TypeDescriptor.GetConverter(typeof(T));

                // Cast ConvertFromString(string text) : object to (T)
                return (T) converter.ConvertFromString(input.ToString());
            }
            catch (Exception)
            {
                Console.Out.WriteLine(k_BadInputMessage);
                return ConvertKey<T>(i_Message);
            }
        }

        /// <summary>
        ///     Converts a generic input char to an object, with given possible valid
        ///     values.
        /// </summary>
        public static T ConvertKey<T>(string i_Message, params
            T[] i_PossibleValidValues)
        {
            T converted = ConvertKey<T>(i_Message);
            if (!isConvertedPossibleValidValue(converted, i_PossibleValidValues)
            )
            {
                Console.Out.WriteLine(k_BadInputMessage);
                return ConvertKey(i_Message, i_PossibleValidValues);
            }

            return converted;
        }

        /// <summary>
        ///     Generic comparison, to check if the
        ///     <param name="i_Converted"></param>
        ///     is a possible valid value.
        ///     <see cref="Operator" />
        ///     <seealso cref="MiscUtil" />
        /// </summary>
        /// <param name="i_Converted" />
        /// <param name="i_PossibleValidValues">All possible valid values.</param>
        /// <typeparam name="T">Must be Comparable</typeparam>
        /// <returns></returns>
        private static bool isConvertedPossibleValidValue<T>(T i_Converted,
            params T[] i_PossibleValidValues)
        {
            return i_PossibleValidValues.Any(i_T =>
                Operator.Equal(i_Converted, i_T));
        }

        /// <summary>
        ///     Converts a generic input char to an object, with given possible valid
        ///     values.
        /// </summary>
        public static T ConvertKey<T>(string i_Message, List<T> i_List)
        {
            T converted = ConvertKey<T>(i_Message);
            if (!isConvertedPossibleValidValue(converted, i_List)
            )
            {
                Console.Out.WriteLine(k_BadInputMessage);
                return ConvertKey(i_Message, i_List);
            }

            return converted;
        }

        /// <summary>
        ///     Converts a generic input char to an object, with given possible valid
        ///     values.
        /// </summary>
        private static bool isConvertedPossibleValidValue<T>(T
            i_Converted, List<T> i_List)
        {
            return i_List.Any(i_T =>
                Operator.Equal(i_Converted, i_T));
        }

        public static List<char> Range(char i_Start, char i_End)
        {
            return Enumerable.Range(i_Start, i_End - i_Start + 1)
                .Select(i_C => (char) i_C).ToList();
        }
    }
}
