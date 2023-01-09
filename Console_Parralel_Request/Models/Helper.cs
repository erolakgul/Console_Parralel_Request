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
            for (int i = 0; i < 999999999; i++) //999999999
            {
                sonuc += Convert.ToDouble(Math.Sin(i) / Math.Cos(i));
            }
        }


        public void ParallelCalculator()
        {
            Parallel.For(0, 999999999, i =>
            {
                sonuc += Convert.ToDouble(Math.Sin(i) / Math.Cos(i));
            });
        }

        private double Topla(int ite,double sonuc)
        {
            sonuc += ite;
            return sonuc;
        }
    }
}
