namespace Series
{
    public class Usuario : EntidadeBase
    {
        private string Nome {get; set;}   
        private string Email {get; set;}   
        private bool Excluido {get; set;}   
        
    public Usuario(int id, string nome, string email)
    {
        this.Id = id;
        this.Nome = nome;
        this.Email = email;
        this.Excluido = false;
    }

    public override string ToString()
    {
        string retorno = "";
        retorno += "  Nome:  " + this.Nome + "\n";
        retorno += "  E-mail:  " + this.Email + "\n";
        retorno += "  Excluido:  " + this.Excluido + "\n";
        return retorno;
    }

    public int retornaId()
    {
        return this.Id;
    }
    public string retornaNome()
    {
        return this.Nome;
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