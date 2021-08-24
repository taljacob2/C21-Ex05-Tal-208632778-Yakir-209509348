#region

using System.Collections;

#endregion

namespace C21_Ex02_01.Team.Misc
{
    public static class EnumeratorGetter
    {
        public static IEnumerator GetEnumerator(object i_Container)
        {
            foreach (object o in (IEnumerable) i_Container)
            {
                if (o == null)
                {
                    break;
                }

                yield return o;
            }
        }
    }
}
