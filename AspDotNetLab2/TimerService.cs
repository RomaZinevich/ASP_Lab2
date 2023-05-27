namespace AspDotNetLab2
{
    public class TimerService
    {
        public string Time()
        {
            return "Час :" + DateTime.Now.ToString();
        }
    }
}
