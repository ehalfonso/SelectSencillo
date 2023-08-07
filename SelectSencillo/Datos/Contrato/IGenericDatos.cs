namespace SelectSencillo.Datos.Contrato
{
    public interface IGenericDatos<T> where T : class
    {
        List<T> GetList();
        bool Guardar(T model);
       
    }
}
