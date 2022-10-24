using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Controllers
{
    public class ClienteController : Controller 
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            //injeção de dependecias.
            _clienteRepositorio = clienteRepositorio;
        }
        public IActionResult Index() 
        {
            List<ClienteModel> clienteList = _clienteRepositorio.BuscarTodos();
            return View(clienteList);
        }

        public IActionResult CriarCliente()
        {
            return View();
        }

        public IActionResult EditarCliente(int id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(id);
            return View(cliente);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ClienteModel cliente = _clienteRepositorio.ListarPorId(id);
            return View(cliente);
        }

        public IActionResult Apagar(int id)
        {
            bool apagar = _clienteRepositorio.Apagar(id);

            try
            {
                if(apagar)
                {
                    TempData["MensagemSucesso"] = "Cliente apagado com sucesso";
                } else
                {
                    TempData["MensagemError"] = "Não conseguimos apagar o cliente!";
                }

                return RedirectToAction("Index");

            } catch(Exception error)
            {
                TempData["MensagemError"] = $"Não conseguimos apagar o cliente, erro: {error.Message}";
                return RedirectToAction("Index");
            }

            
        }

        [HttpPost]
        public IActionResult CriarCliente(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Adicionar(cliente);
                    TempData["MensagemSucesso"] = "Cliente cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(cliente);
            } catch(Exception error)
            {
                TempData["MensagemError"] = $"Não foi possivel cadastrar o cliente, erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "Cliente alterado com sucesso";
                    return RedirectToAction("Index");
                }
                //Força o nome da view para cair em EditarCliente
                return View("EditarCliente", cliente);
            } catch(Exception error)
            {
                TempData["MensagemError"] = $"Não foi possivel realizar a edição do cliente, erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
