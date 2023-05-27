using System.Text;

namespace AspDotNetLab2
{
    public static class Info
    {
        public static string PrintHtml(IServiceCollection services)
        {
            var str = new StringBuilder();
            str.Append("<style>table {border-collapse: collapse;} th, td {border: 1px solid #ddd; padding: 8px;} tr:nth-child(even){background-color: #f2f2f2;} th {padding-top: 12px; padding-bottom: 12px; text-align: center; background-color: #4CAF50; color: white;}</style>");
            str.Append("<h1>Сервіси</h1><table>");
            str.Append("<tr>" +
                "<th>Type</th>" +
                "<th>Implementation</th>" +
                "<th>LIfetime</th>" +
                "</tr>");
            foreach (var item in services)
            {
                str.Append("<tr>");
                str.Append($"<td>{item.ServiceType.Name}</td>");
                str.Append($"<td>{item.ImplementationType?.Name}</td>");
                str.Append($"<td>{item.Lifetime}</td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            return str.ToString();
        }

    }
}
