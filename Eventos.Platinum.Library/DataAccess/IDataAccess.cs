namespace Eventos.Platinum.Library
{
    public interface IDataAccess
    {
        Task<List<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters);
        Task<object> SaveDataAsync<T>(string storedProcedure, T parameters);
        List<T> LoadData<T, U>(string storedProcedure, U parameters);
    }
}