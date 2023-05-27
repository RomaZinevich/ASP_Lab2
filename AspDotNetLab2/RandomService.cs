namespace AspDotNetLab2
{
    public class RandomService
    {
        private int _value;
        static Random rand = new Random();
        public RandomService()
        {
            _value = rand.Next(1, 999);
        }

        public string GetRandom()
        {
            string tempp = "Число від 1 до 999 :" + _value.ToString();
            return tempp;
        }
    }
}
