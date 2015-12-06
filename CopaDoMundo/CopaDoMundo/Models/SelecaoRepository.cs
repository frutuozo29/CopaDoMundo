using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaDoMundo.Models
{
    public class SelecaoRepository : IDisposable
    {
        private bool disposed = false;

        private CopaDoMundoContext context;

        public Selecao Buscar(int Id)
        {
            return context.Selecoes.Find(Id);
        }

        public void Excluir(int Id)
        {
            Selecao selecao = Buscar(Id);
            context.Selecoes.Remove(selecao);
        }

        public SelecaoRepository(CopaDoMundoContext context)
        {
            this.context = context;
        }

        public void Adiciona(Selecao selecao)
        {
            context.Selecoes.Add(selecao);
        }

        public List<Selecao> Selecoes
        {
            get { return context.Selecoes.ToList(); }
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