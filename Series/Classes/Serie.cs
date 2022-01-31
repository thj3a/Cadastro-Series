namespace Series
{
    public class Serie : BaseClass
    {
        private E_Genero Genero { get; set; }
        private string Titulo { get; set; }
        private int Temporadas { get; set; }
        private int Episodios { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, E_Genero genero, string titulo, int temporadas, int episodios)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Temporadas = temporadas;
            this.Episodios = episodios;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Id: " + this.Id.ToString();
            retorno += "\tGenero: " + this.retornaGeneroString();
            retorno += "\tTitulo: " + this.Titulo;
            retorno += "\tEpisodios: " + this.Episodios;
            retorno += "\tTemporadas: " + this.Temporadas;

            return retorno; 
        }
        public int retornaId()
        {
            return this.Id;
        }
        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public string retornaGeneroString()
        {
            return this.Genero.ToString();
        }
        public E_Genero retornaGenero()
        {
            return this.Genero;
        }
        public string retornaTemporadasString()
        {
            return this.Temporadas.ToString();
        }
        public int retornaTemporadas()
        {
            return this.Temporadas;
        }
        public string retornaEpisodiosString()
        {
            return this.Episodios.ToString();
        }
        public int retornaEpisodios()
        {
            return this.Episodios;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
    }
}