using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaDoMundo.Models
{
    public class UnitOfWork : IDisposable
    {
        private bool disposed = false;
        private CopaDoMundoContext context = new CopaDoMundoContext();
        private SelecaoRepository selecaoRepository;
        private JogadorRepository jogadorRepository;

        public JogadorRepository JogadorRepository
        {
            get
            {
                if (jogadorRepository == null)
                {
                    jogadorRepository = new JogadorRepository(context);
                }
                return jogadorRepository;
            }
        }

        public SelecaoRepository SelecaoRepository
        {
            get
            {
                if (selecaoRepository == null)
                {
                    selecaoRepository = new SelecaoRepository(context);
                }
                return selecaoRepository;
            }
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
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}