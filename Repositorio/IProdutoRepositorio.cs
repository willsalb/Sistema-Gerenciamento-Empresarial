using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio
{
    public interface IProdutoRepositorio
    {
        ProdutoModel Adicionar(ProdutoModel produto);
        ProdutoModel ListarPorId(int id);
        ProdutoModel Atualizar(ProdutoModel produto);
        List<ProdutoModel> BuscarTodos();
    }
}
