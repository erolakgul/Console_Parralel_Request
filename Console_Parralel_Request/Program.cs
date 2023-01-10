using Console_Parralel_Request.Operations;
using Console_Parralel_Request.RemoteRequest;
using Console_Parralel_Request.RemoteRequest.Dto;

ThreadComparing threadComparing = new();
WaitThreadFinished waitThreadFinished = new();
ParallelProcessing parallelProcessing = new();
AkaryakitApi akaryakitApi = new();

#region thread in sonlanmasını beklemeden yanı anda başlatınca içerideki verinin tamamı alınamıyor
//threadComparing.ComparerThreads();
#endregion

Console.WriteLine();

#region thread in sonlanması beklenirse
//waitThreadFinished.ComparerThreads();
#endregion

Console.WriteLine();

#region parallel processing
//parallelProcessing.Process();
//parallelProcessing.Process_ParalelForeach();
#endregion


#region akaryakit

List<State> stateList = await akaryakitApi.CustomReqAsync();

//foreach (var item in akaryakitApi._cityList)
//{

//}

foreach (var item in stateList)
{
    Console.WriteLine($"city List => {item.name}  : {item.premium}");
}

stateList.Clear();

List<State> stateListThreads = await akaryakitApi.CustomReqAsyncMultiThread();

foreach (var item in stateListThreads)
{
    Console.WriteLine($"city List => {item.name}  : {item.premium}");
}

#endregion

Console.ReadLine();