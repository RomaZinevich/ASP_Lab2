using System.Text;

namespace AspDotNetLab2
{
    public class GeneralCounterService
    {
        private int _count = 0;
        private Dictionary<string, int> Counter = new Dictionary<string, int>();
        public void IncrementValue(string url)
        {
            if (Counter.ContainsKey(url))
            {
                Counter[url]++;
            }
            else
            {
                Counter[url] = 1;
            }
            _count++;
        }
        public string GetHtml()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table style='border-collapse: collapse;'>");
            str.Append($"<tr><th style='border:1px solid;'>Загальна кiлькiсть запитiв</th><th style='border:1px solid;'>{_count}</th></tr>");
            str.Append("<tr><th style='border:1px solid;'>URL</th><th style='border:1px solid;'>Кількість</th></tr>");
            foreach (var url in Counter)
            {
                str.Append($"<tr><td style='border:1px solid;'>{url.Key}</td><td style='border:1px solid;'>{url.Value}</td></tr>");
            }
            str.Append("</table>");
            return str.ToString();
        }
    }
}
