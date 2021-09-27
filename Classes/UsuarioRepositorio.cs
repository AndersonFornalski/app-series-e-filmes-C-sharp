using System;
using System.Collections.Generic;
using Series.Interfaces;
using Series.Classes;

namespace Series
{
    public class UsuarioRepositorio : IRepositorio<Usuario>
    {
        private List<Usuario> listaUsuario = new List<Usuario>();

        public void Atualiza(int id, Usuario usuario)
        {
            listaUsuario[id] = usuario;
        }

        public void Exclui(int id)
        {
            listaUsuario[id].Excluir();
        }

        public void Insere(Usuario usuario)
        {
            listaUsuario.Add(usuario);
        }

        public List<Usuario> Lista()
        {
            return listaUsuario;
        }

        public int ProximoId()
        {
            return listaUsuario.Count;
        }

        public Usuario RetornaPorId(int id)
        {
            return listaUsuario[id];
        }
    }
}