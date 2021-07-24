using Microsoft.AspNetCore.Mvc;
using SilviaCosmeticos.Models;
using SilviaCosmeticos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilviaCosmeticos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public ProdutoController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

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
            var usuariodobanco = _usuarioRepository.BuscarUsuarioPorEmail(usuario.Email);
            
            if (usuariodobanco != null)
            {
                return View("/Views/Usuario/UsuarioExistente.cshtml");
            }
            _usuarioRepository.CadastrarUsuario(usuario);
            return View("UsuarioSucesso");               
        }

        [HttpGet]
        public ActionResult EntrarBuscarUsuarioPorId(Usuario usuariorecebido)
        {
            var usuarioDoBancox = _usuarioRepository.EntrarBuscarUsuarioPorId(usuariorecebido);
           
            if(usuarioDoBancox == null || usuarioDoBancox.Nome != usuariorecebido.Nome 
                || usuarioDoBancox.Senha != usuariorecebido.Senha)
            {
                return View("/Views/Usuario/ErrorGeral.cshtml");
            }
            List<Usuario> listadeusuarios = new List<Usuario>();
            ViewBag.Usuarios = listadeusuarios;
          
            return View("/Views/Produto/Escolha.cshtml");
        }

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            var usuarios = _usuarioRepository.ListarUsuarios();

            ViewBag.Usuarios = usuarios;
            
            return View("/Views/Usuario/ListarUsuarios.cshtml");
        }

        [HttpGet]
        public IActionResult DeletarUsuario(int id)
        {
            _usuarioRepository.DeletarUsuario(id);
            return View("/Views/Usuario/DeletarUsuario.cshtml");            
        }

        [HttpGet]
        public IActionResult ChamarEditarUsuario(int id)
        {
            var resultado = _usuarioRepository.ChamarEditarUsuario(id);

            ViewData["valor"] = resultado.Id;
                        
            return View("/Views/Usuario/ChamarEditarUsuario.cshtml");
        }

        [HttpGet]
        public IActionResult EditarUsuario(Usuario usuarioRecebido)
        {
            _usuarioRepository.EditarUsuario(usuarioRecebido);
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
            _usuarioRepository.CadastrarProduto(produto);

            return View("Sucesso");
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var listaDeProdutos = _usuarioRepository.ListarProdutos();

            ViewBag.Produtos = listaDeProdutos;
            
            return View();
        }

        [HttpGet]
        public IActionResult Deletar(int id)
        {
            _usuarioRepository.DeletarProduto(id);
            return View();
        }
        [HttpGet]
        public IActionResult ChamarEditar(int id)
        {
            var produtoDoBanco = _usuarioRepository.ChamarEditarProduto(id);

            ViewData["valor"] = produtoDoBanco.Id;

            return View();
        }
        [HttpGet]
        public IActionResult EditarProduto(Produto produtoEditado)
        {
            _usuarioRepository.EditarProduto(produtoEditado);

            return View();
        }

        [HttpGet]
        public IActionResult Fim()
        {
            return View();
        }


    }
}
