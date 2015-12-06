using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaDoMundo.Models
{
    public class JogadorRepository
    {
        private bool disposed = false;

        private CopaDoMundoContext context;

        public Jogador Buscar(int Id)
        {
            return context.Jogadores.Find(Id);
        }

        public JogadorRepository(CopaDoMundoContext context)
        {
            this.context = context;
        }

        public void Adiciona(Jogador jogador)
        {
            context.Jogadores.Add(jogador);
        }

        public void Excluir(int Id)
        {
            Jogador jogador = Buscar(Id);
            context.Jogadores.Remove(jogador);
        }

        public List<Jogador> Jogadores
        {
            get { return context.Jogadores.ToList(); }
        }

        public void Salvar()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}