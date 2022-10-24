using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ProdutoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ProdutoModel Adicionar(ProdutoModel produto)
        {
            _bancoContext.Produtos.Add(produto);

            _bancoContext.SaveChanges();

            return produto;

        }

        public ProdutoModel Atualizar(ProdutoModel produto)
        {
            ProdutoModel ProdutoDB = ListarPorId(produto.Id);
            if (ProdutoDB == null) throw new Exception("Erro ao atualizar o produto!!");
            ProdutoDB.Id = produto.Id;
            ProdutoDB.Nome = produto.Nome;
            
        }

        public List<ProdutoModel> BuscarTodos()
        {
            return _bancoContext.Produtos.ToList();
        }

        public ProdutoModel ListarPorId(int id)
        {
            return _bancoContext.Produtos.FirstOrDefault(L => L.Id == id);
        }
    }
}
