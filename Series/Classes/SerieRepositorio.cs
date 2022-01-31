using Series.Interfaces;

namespace Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> series = new List<Serie>();
        public void Atualizar(int id, Serie obj)
        {
            series[id-1] = obj;
        }

        public void Excluir(int id)
        {
            series[id-1].Excluir();
        }

        public void Inserir(Serie obj)
        {
            series.Add(obj);
        }

        public int ProximoId()
        {
            int maiorId = 0;
            foreach (Serie serie in series)
            {
                if (serie.Id > maiorId)
                {
                    maiorId = serie.Id;
                }
            }
            return maiorId + 1;
        }

        public Serie RetornarporId(int id)
        {
            return series[id];
        }

        public List<Serie> RetornarTodos()
        {
            return series;
        }
    }
}