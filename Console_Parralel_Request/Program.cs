using Console_Parralel_Request.Operations;

ThreadComparing threadComparing = new ();
WaitThreadFinished waitThreadFinished = new ();
ParallelProcessing parallelProcessing = new();


#region thread in sonlanmasını beklemeden yanı anda başlatınca içerideki verinin tamamı alınamıyor
//threadComparing.ComparerThreads();
#endregion

Console.WriteLine();

#region thread in sonlanması beklenirse
//waitThreadFinished.ComparerThreads();
#endregion

Console.WriteLine();

#region parallel processing
parallelProcessing.Process();
#endregion

Console.ReadLine();