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
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PreUsuario()
        {
            // exibir o html para receber no método usuariocadastro as informações para cadastrar

            return View("/Views/Usuario/PreUsuario.cshtml");
        }

        [HttpGet]
        public ActionResult UsuarioCadastro(Usuario usuario)
        {
            AplicacaoContext usuarioDoBancoContext = new AplicacaoContext();

            var usuariodobanco = usuarioDoBancoContext.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);
            if (usuariodobanco == null)
            {

            }
            else if (usuariodobanco.Email == usuario.Email)
            {               
                return View("/Views/Usuario/UsuarioExistente.cshtml");
            }
            else if (usuariodobanco.Nome == usuario.Nome)
            {
                return View("/Views/Usuario/UsuarioExistente.cshtml");
            }            
            if (usuario.Nome != null && usuario.Nome.All(x => char.IsLetter(x)))
            {
                AplicacaoContext usuarioContext = new AplicacaoContext();
                usuarioContext.Usuarios.Add(usuario);
                usuarioContext.SaveChanges();
            }
            else
            {
                return View("/views/usuario/Error.cshtml");
            }
            return View("UsuarioSucesso");               
        }

        [HttpGet]
        public ActionResult Entrar(Usuario usuariorecebido)
        {          
            if (usuariorecebido == null)
            {
                return View("Index");
            }

            if (usuariorecebido.Nome != null && usuariorecebido.Nome.All(x => char.IsLetter(x)))
            {

            }
            else
            {
                return View("/views/usuario/Error.cshtml");
            }

            AplicacaoContext usuarioContext = new AplicacaoContext();
           
            var usuarioBancox = usuarioContext.Usuarios.FirstOrDefault(x => x.Email == usuariorecebido.Email);
            if(usuarioBancox == null)
            {
                return View("/Views/Usuario/ErrorGeral.cshtml");
            }
            if(usuarioBancox.Nome != usuariorecebido.Nome)
            {
                return View("/Views/Usuario/ErrorGeral.cshtml");
            }
            if(usuarioBancox.Senha != usuariorecebido.Senha)
            {
                return View("/Views/Usuario/ErrorGeral.cshtml");
            }

            List<Usuario> listaDeUsuarios = new List<Usuario>();
            ViewBag.Usuarios = listaDeUsuarios;

            return View("Escolha");
        }

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            AplicacaoContext usuarioContext = new AplicacaoContext();

            List<Usuario> listaDeUsuarios = new List<Usuario>();

            listaDeUsuarios = usuarioContext.Usuarios.ToList();

            ViewBag.Usuarios = listaDeUsuarios;
            
            return View("/Views/Usuario/ListarUsuarios.cshtml");
        }

        [HttpGet]
        public IActionResult DeletarUsuario(int id)
        {
            Usuario usuario = new Usuario();

            usuario.Id = id;

            AplicacaoContext usuarioContext = new AplicacaoContext();

            var usuariodoBanco = usuario;

            usuarioContext.Usuarios.Remove(usuariodoBanco);
            usuarioContext.SaveChanges();

            return View("/Views/Usuario/DeletarUsuario.cshtml");            
        }

        [HttpGet]
        public IActionResult ChamarEditarUsuario(int id)
        {
            // preciso implementar a confirmação de senha
            Usuario usuario = new Usuario();
            usuario.Id = id;

            int resultado = id;

            ViewData["valor"] = resultado;
                        
            return View("/Views/Usuario/ChamarEditarUsuario.cshtml");
        }

        [HttpGet]
        public IActionResult EditarUsuario(Usuario usuarioeditado)
        {           
            AplicacaoContext usuarioContext = new AplicacaoContext();
            var usuarioDoBanco = usuarioContext.Usuarios.FirstOrDefault(x => x.Id == usuarioeditado.Id);
            if(usuarioDoBanco == null)
            {
                return View("/Views/Usuario/ErrorGeral.cshtml");
            }

            usuarioDoBanco.Nome = usuarioeditado.Nome;
            usuarioDoBanco.Email = usuarioeditado.Email;
            usuarioDoBanco.Senha = usuarioeditado.Senha;
                        
            usuarioContext.Usuarios.Update(usuarioDoBanco);
            usuarioContext.SaveChanges();

            return View("/Views/Usuario/EditarUsuario.cshtml");
        }

        [HttpGet]
        public IActionResult PreCadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            AplicacaoContext produtoContext = new AplicacaoContext();
            produtoContext.Produtos.Add(produto);
            produtoContext.SaveChanges();

            return View("Sucesso");
        }

        [HttpGet]
        public IActionResult Listar()
        {
            AplicacaoContext produtoContext = new AplicacaoContext();

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

            AplicacaoContext produtoContext = new AplicacaoContext();

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
        public IActionResult Editar(Produto produtoEditado)
        {        
            AplicacaoContext produtoContext = new AplicacaoContext();           
            var produtoDoBanco = produtoContext.Produtos.FirstOrDefault(x => x.Id == produtoEditado.Id);
            if (produtoDoBanco  == null)
            {
                return View("/Views/Usuario/ErrorGeral.cshtml");
            }

            produtoDoBanco.Nome = produtoEditado.Nome;
            produtoDoBanco.Marca = produtoEditado.Marca;
            produtoDoBanco.Tipo = produtoEditado.Tipo;
            produtoDoBanco.Quantidade = produtoEditado.Quantidade;

            produtoContext.Produtos.Update(produtoDoBanco);
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
