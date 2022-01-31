
namespace Series.Interfaces
{
    public interface IRepositorio<T>
    {
        void Inserir(T obj);
        void Atualizar(int id, T obj);
        void Excluir(int id);
        T RetornarporId(int id);
        List<T> RetornarTodos();
        int ProximoId();
    }
}