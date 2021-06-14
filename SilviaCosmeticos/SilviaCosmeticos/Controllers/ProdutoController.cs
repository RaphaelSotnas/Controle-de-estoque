using Microsoft.AspNetCore.Mvc;
using SilviaCosmeticos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilviaCosmeticos.Controllers
{
    public class ProdutoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PreCadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(string Nome, string Marca, string Tipo, int Valor, int Quantidade)
        {
            Produto produto = new Produto();

            produto.Nome = Nome;
            produto.Marca = Marca;
            produto.Tipo = Tipo;
            produto.Valor = Valor;
            produto.Quantidade = Quantidade;

            ProdutoContext produtoContext = new ProdutoContext();
            produtoContext.Produtos.Add(produto);
            produtoContext.SaveChanges();

            return View("Sucesso");
        }

        [HttpGet]
        public IActionResult Listar()
        {
            ProdutoContext produtoContext = new ProdutoContext();

            List<Produto> listaDeProdutos = new List<Produto>();

            listaDeProdutos = produtoContext.Produtos.ToList();

            ViewBag.Produtos = listaDeProdutos;
            
            return View();
        }
        [HttpGet]
        public IActionResult Deletar(int id)
        {
            Produto produto = new Produto();

            produto.Id = id;

            ProdutoContext produtoContext = new ProdutoContext();

            var ProdutodoBanco = produto;

            produtoContext.Produtos.Remove(ProdutodoBanco);
            produtoContext.SaveChanges();

            return View();
        }
        [HttpGet]
        public IActionResult ChamarEditar(int id)
        {
            Produto produto = new Produto();
            produto.Id = id;

            int resultado = id;

            ViewData["valor"] = resultado;

            return View();
        }
        [HttpPost]
        public IActionResult Editar(int id, string Nome, string tipo, string Marca, int valor, int Quantidade)
        {
            Produto produtoEditado = new Produto();

            produtoEditado.Id = id;
            produtoEditado.Nome = Nome;
            produtoEditado.Tipo = tipo;
            produtoEditado.Marca = Marca;
            produtoEditado.Valor = valor;
            produtoEditado.Quantidade = Quantidade;

            ProdutoContext produtoContext = new ProdutoContext();        

            produtoContext.Produtos.Update(produtoEditado);
            produtoContext.SaveChanges();

            return View();
        }

        [HttpGet]
        public IActionResult Fim()
        {
            return View();
        }


    }
}
