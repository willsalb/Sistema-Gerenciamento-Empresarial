using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        //Injetar o contexto, é ele que vai gravar no BD.
        private readonly BancoContext _bancoContext;
        public ClienteRepositorio(BancoContext bancoContext)
        {
            //injeção de dependecias.
            _bancoContext = bancoContext;
        }

        public List<ClienteModel> BuscarTodos()
        {
                                          //Carrega tudo que ta no bando de dados.
            return _bancoContext.Clientes.ToList();
        }

        public ClienteModel ListarPorId(int id)
        {
                                          //Buscar o primeiro ou o unico registro que está dentro do BD.
            return _bancoContext.Clientes.FirstOrDefault(y => y.Id == id);
        }

        public ClienteModel Adicionar(ClienteModel cliente)
        {
            //Gravar o cliente no banco de dados.
            //Contexto da ta bela Clientes adicionando cliente
            _bancoContext.Clientes.Add(cliente);
            //Comitando
            _bancoContext.SaveChanges(); 
            return cliente;
        }

        public ClienteModel Atualizar(ClienteModel cliente)
        {
            ClienteModel ClienteDB = ListarPorId(cliente.Id);

            if (ClienteDB == null) throw new Exception("Erro na alteração de cliente!");

            ClienteDB.Nome = cliente.Nome;
            ClienteDB.Cpf = cliente.Cpf;
            ClienteDB.Email = cliente.Email;
            ClienteDB.Celular = cliente.Celular;

            _bancoContext.Clientes.Update(ClienteDB);
            _bancoContext.SaveChanges();

            return ClienteDB;
        }

        public bool Apagar(int id)
        {
            ClienteModel ClienteDB = ListarPorId(id);

            if (ClienteDB == null) throw new Exception("Houve um erro ao remover o cliente!");

            _bancoContext.Clientes.Remove(ClienteDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
