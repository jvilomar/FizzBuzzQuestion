using WillDom.TechDemo.Interfaces;

namespace WillDom.TechDemo.Common
{
    public class Operations
    {
        public string GetWord(IWordexInfo info)
        {
            var result = string.Empty;

            if (info == null) { return result; }


            if (info.Multiple % info.Multiplier == 0)
            {
                result = info.Word;
            }
            return result;
        }
    }
}
