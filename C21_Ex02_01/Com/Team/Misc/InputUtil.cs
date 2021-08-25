﻿#region

 using System;
 using System.Collections.Generic;
 using System.ComponentModel;
 using System.Linq;
 using System.Text.RegularExpressions;
 using MiscUtil;

 #endregion

namespace C21_Ex02_01.Com.Team.Misc
{
    public static class InputUtil
    {
        private const string k_BadInputMessage =
            "Bad input. Please try again...";

        /// <summary>
        ///     Converts a generic <see langword="string" /> input to a
        ///     <see cref="IComparable" /> object.
        /// </summary>
        public static T Convert<T>(string i_Message)
        {
            Console.Out.Write(i_Message);
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
        ///     Converts a generic <see cref="IComparable" /> input
        ///     <see langword="string" /> to an object,
        ///     asserted by a given range.
        /// </summary>
        public static T ConvertWithAssertByRange<T>(string i_Message,
            T i_MinimumRange,
            T i_MaximumRange)
        {
            T converted = Convert<T>(i_Message);
            if (!isConvertedInRange(converted, i_MinimumRange, i_MaximumRange)
            )
            {
                Console.Out.WriteLine(k_BadInputMessage);
                return ConvertWithAssertByRange(i_Message, i_MinimumRange,
                    i_MaximumRange);
            }

            return converted;
        }
        
        public static string ConvertWithAssertByRegexWithException(
            string i_Message, Regex i_Regex)
        {
            string converted = Convert<string>(i_Message);
            if (!i_Regex.IsMatch(converted))

            {
                Console.Out.WriteLine(k_BadInputMessage);
                throw new FormatException();
            }

            return converted;
        }
        
        public static string ConvertWithAssertByRegex(
            string i_Message, Regex i_Regex)
        {
            string converted = Convert<string>(i_Message);
            if (!i_Regex.IsMatch(converted))

            {
                Console.Out.WriteLine(k_BadInputMessage);
                return ConvertWithAssertByRegex(i_Message, i_Regex);
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
        ///     Converts a generic <see cref="IComparable" /> input type to an object,
        ///     asserted by given possible valid values.
        /// </summary>
        public static T Convert<T>(string i_Message, List<T> i_List)
        {
            T converted = ConvertKey<T>(i_Message);
            if (!isConvertedPossibleValidValue(converted, i_List)
            )
            {
                Console.Out.WriteLine(k_BadInputMessage);
                return Convert(i_Message, i_List);
            }

            return converted;
        }

        /// <summary>
        ///     Converts a generic <see cref="IComparable" /> input type to an object,
        ///     asserted by given possible valid values.
        /// </summary>
        public static T ConvertIgnoreCase<T>(string i_Message, List<T> i_List)
        {
            T converted = ConvertKey<T>(i_Message);
            if (!isConvertedPossibleValidValueIgnoreCase(converted, i_List)
            )
            {
                Console.Out.WriteLine(k_BadInputMessage);
                return ConvertIgnoreCase(i_Message, i_List);
            }

            return converted;
        }

        /// <summary>
        ///     Converts a generic <see cref="IComparable" /> input <see langword="char" />
        ///     to an object,
        ///     asserted by given possible valid values, case-ignored.
        /// </summary>
        public static T ConvertKeyIgnoreCase<T>(string i_Message,
            List<T> i_List)
        {
            T converted = ConvertKey<T>(i_Message);
            if (!isConvertedPossibleValidValueIgnoreCase(converted, i_List)
            )
            {
                Console.Out.WriteLine(k_BadInputMessage);
                return ConvertKeyIgnoreCase(i_Message, i_List);
            }

            return converted;
        }

        /// <summary>
        ///     Converts a generic <see cref="IComparable" /> input
        ///     <see langword="string" />
        ///     to an object,
        ///     asserted by given possible valid values.
        /// </summary>
        public static T Convert<T>(string i_Message, params
            T[] i_PossibleValidValues)
        {
            T converted = Convert<T>(i_Message);
            if (!isConvertedPossibleValidValue(converted, i_PossibleValidValues)
            )
            {
                Console.Out.WriteLine(k_BadInputMessage);
                return Convert(i_Message, i_PossibleValidValues);
            }

            return converted;
        }

        /// <summary>
        ///     Converts a generic <see cref="IComparable" /> input
        ///     <see langword="string" />
        ///     to an object,
        ///     asserted by given possible valid values.
        /// </summary>
        public static T ConvertIgnoreCase<T>(string i_Message, params
            T[] i_PossibleValidValues)
        {
            T converted = Convert<T>(i_Message);
            if (!isConvertedPossibleValidValueIgnoreCase(converted,
                i_PossibleValidValues)
            )
            {
                Console.Out.WriteLine(k_BadInputMessage);
                return ConvertIgnoreCase(i_Message, i_PossibleValidValues);
            }

            return converted;
        }

        /// <summary>
        ///     Converts a generic <see cref="IComparable" /> input <see langword="char" />
        ///     to an object.
        /// </summary>
        public static T ConvertKey<T>(string i_Message)
        {
            Console.Out.Write(i_Message);
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
        ///     Converts a generic <see cref="IComparable" /> input <see langword="char" />
        ///     to an object,
        ///     asserted by given possible valid values.
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
        ///     Converts a generic <see cref="IComparable" /> input <see langword="char" />
        ///     to an object,
        ///     asserted by given possible valid values, case-ignored.
        /// </summary>
        public static T ConvertKeyIgnoreCase<T>(string i_Message, params
            T[] i_PossibleValidValues)
        {
            T converted = ConvertKey<T>(i_Message);
            if (!isConvertedPossibleValidValueIgnoreCase(converted,
                i_PossibleValidValues)
            )
            {
                Console.Out.WriteLine(k_BadInputMessage);
                return ConvertKeyIgnoreCase(i_Message, i_PossibleValidValues);
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
        /// <returns />
        private static bool isConvertedPossibleValidValue<T>(T i_Converted,
            params T[] i_PossibleValidValues)
        {
            return i_PossibleValidValues.Any(i_T =>
                Operator.Equal(i_Converted, i_T));
        }

        /// <summary>
        ///     Generic comparison, to check if the
        ///     <param name="i_Converted"></param>
        ///     is a possible valid value, case-ignored.
        ///     <see cref="Operator" />
        ///     <seealso cref="MiscUtil" />
        /// </summary>
        /// <param name="i_Converted" />
        /// <param name="i_PossibleValidValues">All possible valid values.</param>
        /// <typeparam name="T">Must be Comparable</typeparam>
        /// <returns />
        private static bool isConvertedPossibleValidValueIgnoreCase<T>(
            T i_Converted,
            params T[] i_PossibleValidValues)
        {
            return i_PossibleValidValues.Any(i_T =>
                Operator.Equal(i_Converted.ToString().ToUpper(), i_T.ToString
                    ().ToUpper()));
        }

        /// <summary>
        ///     Converts a generic <see cref="IComparable" /> input <see langword="char" />
        ///     to an object,
        ///     asserted by given possible valid values.
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
        ///     Converts a generic <see cref="IComparable" /> input <see langword="char" />
        ///     to an object,
        ///     asserted by given possible valid values.
        /// </summary>
        private static bool isConvertedPossibleValidValue<T>(T
            i_Converted, List<T> i_List)
        {
            return i_List.Any(i_T =>
                Operator.Equal(i_Converted, i_T));
        }

        /// <summary>
        ///     Converts a generic <see cref="IComparable" /> input <see langword="char" />
        ///     to an object,
        ///     asserted by given possible valid values, case-ignored.
        /// </summary>
        private static bool isConvertedPossibleValidValueIgnoreCase<T>(T
            i_Converted, List<T> i_List)
        {
            return i_List.Any(i_T =>
                Operator.Equal(i_Converted.ToString().ToUpper(), i_T.ToString
                    ().ToUpper()));
        }

        public static List<char> Range(char i_Start, char i_End)
        {
            return Enumerable.Range(i_Start, i_End - i_Start + 1)
                .Select(i_C => (char) i_C).ToList();
        }
    }
}
