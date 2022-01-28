namespace DIO.Musicas.src.Classes;
using DIO.Musicas.src.Enum;

public class Musicas : EntidadeBase
{
    //Atributos
    public Genero Genero { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public int Ano { get; set; }

    private bool Excluido { get; set; }
    //Métodos
    public Musicas(int id, Genero genero, string titulo, string descricao, int ano)
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
        retorno += "Gênero: " + this.Genero + Environment.NewLine;
        retorno += "Título: " + this.Titulo + Environment.NewLine;
        retorno += "Descrição: " + this.Descricao + Environment.NewLine;
        retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
        retorno += "Excluído?" + this.Excluido + Environment.NewLine;
        return retorno;
    }
    public string retornaTitulo()
    {
        return this.Titulo;
    }

    public int retornaId()
    {
        return this.Id;
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