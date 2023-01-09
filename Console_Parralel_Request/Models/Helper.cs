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



    }
}
