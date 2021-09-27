namespace Series
{
    public class Filme : EntidadeBase
    {
        private Genero Genero {get; set;}   
        private string Titulo {get; set;}   
        private string Descricao {get; set;}   
        private int Ano {get; set;}
        private bool Excluido {get; set;}   
        
    public Filme(int id, Genero genero, string titulo, string descricao, int ano )
    {
        this.Id = id;
        this.Genero = genero;
        this.Titulo = titulo;
        this.Descricao = descricao;
        this.Ano = ano;
        this.Excluido = false;
    }

    public override string ToString()
    {
        string retorno = "";
        retorno += "Gênero: " + this.Genero + "\n";
        retorno += "Título: " + this.Titulo + "\n";
        retorno += "Descrição: " + this.Descricao + "\n";
        retorno += "Ano: " + this.Ano + "\n";
        retorno += "Excluido: " + this.Excluido;
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
    public bool retornaExcluido()
    {
        return this.Excluido;
    }
     public void Excluir()
    {
       this.Excluido = true;
    }

    }

    
}