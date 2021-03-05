namespace DIO.Series.Lib.Identificavel
{
    public interface Identificaveis
    {
         void SetId(int id);
         int GetId();
         
         int GerarId();
    }
}