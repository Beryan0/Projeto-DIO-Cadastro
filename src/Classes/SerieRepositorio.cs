namespace DIO.Musicas.src.Classes;
using System;
using DIO.Musicas.src.Interfaces;
using System.Collections.Generic;
public class MusicaRepositorio : IRepositorio<Musicas>
{

    private List<Musicas> listaMusicas = new();
    public void Atualiza(int id, Musicas objeto)
    {
        try
        {
            listaMusicas[id] = objeto;
        }
        catch (Exception)
        {
            Console.WriteLine("Música não encontrada");
            return;
        }
    }

    public void Exclui(int id)
    {
        listaMusicas[id].Excluir();
    }

    public void Insere(Musicas objeto)
    {
        listaMusicas.Add(objeto);
    }

    public List<Musicas> Lista()
    {
        return listaMusicas;
    }

    public int ProximoId()
    {
        return listaMusicas.Count;
    }

    public Musicas RetornaPorId(int id)
    {
        return listaMusicas[id];
    }
}
