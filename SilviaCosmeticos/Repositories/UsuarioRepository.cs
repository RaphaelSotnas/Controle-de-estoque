using SilviaCosmeticos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilviaCosmeticos.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario BuscarUsuarioPorEmail(string email)
        {
            AplicacaoContext usuarioDoBanco = new AplicacaoContext();

            var usuario = usuarioDoBanco.Usuarios.FirstOrDefault(x => x.Email == email);

            return usuario;
        }

        public Usuario EntrarBuscarUsuarioPorEmail(Usuario usuariorecebido)
        {
            AplicacaoContext aplicacaoContext = new AplicacaoContext();
            var usuarioDoBancox = aplicacaoContext.Usuarios.FirstOrDefault(x => x.Email == usuariorecebido.Email);
            return usuarioDoBancox;
        }

        public Usuario CadastrarUsuario(Usuario usuario)
        {
            AplicacaoContext aplicacaoContext = new AplicacaoContext();
            aplicacaoContext.Usuarios.Add(usuario);
            aplicacaoContext.SaveChanges();
            return usuario;
        }

        public List<Usuario> ListarUsuarios()
        {
            AplicacaoContext usuarioContext = new AplicacaoContext();

            var listaDeUsuarios = usuarioContext.Usuarios.ToList();

            return listaDeUsuarios;
        }

        public Usuario DeletarUsuario(int id)
        {
            AplicacaoContext aplicacaoContext = new AplicacaoContext();
            var usuarioDoBancoDelete = aplicacaoContext.Usuarios.FirstOrDefault(x => x.Id == id);
            aplicacaoContext.Usuarios.Remove(usuarioDoBancoDelete);
            aplicacaoContext.SaveChanges();
            return usuarioDoBancoDelete;
        }

        public Usuario ChamarEditarUsuario(int id)
        {
            AplicacaoContext aplicacaoContext = new AplicacaoContext();
            var usuario = aplicacaoContext.Usuarios.FirstOrDefault(x => x.Id == id);
            return usuario;
        }

        public Usuario EditarUsuario(Usuario usuarioRecebido)
        {
            AplicacaoContext aplicacaoContext = new AplicacaoContext();
            var usuarioDoBanco = aplicacaoContext.Usuarios.FirstOrDefault(x => x.Id == usuarioRecebido.Id);

            usuarioDoBanco.Nome = usuarioRecebido.Nome;
            usuarioDoBanco.Email = usuarioRecebido.Email;
            usuarioDoBanco.Senha = usuarioRecebido.Senha;

            aplicacaoContext.Usuarios.Update(usuarioDoBanco);
            aplicacaoContext.SaveChanges();

            return usuarioDoBanco;
        }

        public Produto CadastrarProduto(Produto produto)
        {
            AplicacaoContext produtoContext = new AplicacaoContext();
            produtoContext.Produtos.Add(produto);
            produtoContext.SaveChanges();
            return produto;
        }

        public List<Produto> ListarProdutos()
        {
            AplicacaoContext produtoContext = new AplicacaoContext();
            
            var listadeProdutos = produtoContext.Produtos.ToList();
            
            return listadeProdutos;
        }

        public Produto DeletarProduto(int id) 
        {
            AplicacaoContext produtoContext = new AplicacaoContext();
            var produtoDoBancoDelete = produtoContext.Produtos.FirstOrDefault(x => x.Id == id);
            produtoContext.Produtos.Remove(produtoDoBancoDelete);
            produtoContext.SaveChanges();

            return produtoDoBancoDelete;
        }


        public Produto ChamarEditarProduto(int id) 
        {
            AplicacaoContext aplicacaoContext = new AplicacaoContext();
            var produto = aplicacaoContext.Produtos.FirstOrDefault(x => x.Id == id);
            return produto;
      
        }

        public Produto EditarProduto(Produto produtoEditado) 
        {
            AplicacaoContext produtoContext = new AplicacaoContext();
            var produtoDoBanco = produtoContext.Produtos.FirstOrDefault(x => x.Id == produtoEditado.Id);

            produtoDoBanco.Nome = produtoEditado.Nome;
            produtoDoBanco.Marca = produtoEditado.Marca;
            produtoDoBanco.Tipo = produtoEditado.Tipo;
            produtoDoBanco.Quantidade = produtoEditado.Quantidade;

            produtoContext.Produtos.Update(produtoDoBanco);
            produtoContext.SaveChanges();

            return produtoDoBanco;
        }
    }        
}
