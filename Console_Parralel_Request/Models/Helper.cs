namespace Console_Parralel_Request.Models
{
    public class Helper : Initialized
    {
        public Helper()
        {

        }

        public void Counter(string name,int basla,int Limit)
        {
            Console.WriteLine();
            while (basla <= Limit)
            {
                basla++;
                Console.WriteLine($"{name} => {basla.ToString()}");
            }
            
            DataList.Add(name); 
        }


        public void Calculator()
        {
            double sonuc = 0;

            for (int i = 0; i < 999999999; i++)
            {
                sonuc += Convert.ToDouble(Math.Sin(i) / Math.Cos(i));
            }
        }


        public void ParallelCalculator()
        {
            double sonuc = 0;

            Parallel.For(0, 999999999, i =>
            {
                sonuc += Convert.ToDouble(Math.Sin(i) / Math.Cos(i));
            });
        }
    }
}
