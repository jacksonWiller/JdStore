using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    [Table("Produtos")]
    public class Produto : Base
    {
        [Key]
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }        
        public string Descption { get; protected set; }
        public string Observacao { get; protected set; }
        public decimal Valor { get; protected set; }
        public string ImagemURL { get; set; }
        public int QuantidadeEmEstoque { get; protected set; }

        public void EditarImagens(string imagem)
        {
            ImagemURL = imagem.ToString();
        }

        public void EditarProduto(string nome, string descricao, string observacao, decimal valor, int quantidadeEmEstoque)
        {
            Name = nome;
            Descption = descricao;
            Observacao = observacao;
            Valor = valor;
            QuantidadeEmEstoque = quantidadeEmEstoque;
        }

        public static Produto CriarProduto(string nome, string descricao, string observacao, decimal valor,
                                        int quantidadeEmEstoque)
        {
            Produto produto = new Produto()
            {
                Name = nome,
                Descption = descricao,
                Observacao = observacao,
                Valor = valor,
                QuantidadeEmEstoque = quantidadeEmEstoque,
                Estado = true,
                DataDeCriacao = DateTime.Now,
                DataDeAlteracao = DateTime.Now,
            };

            return produto;
        }

        public static Produto CriarProduto(string nome, string descricao, string observacao, decimal valor, 
                                        int quantidadeEmEstoque, string imagemURL)
        {
            return CriarProduto(Guid.NewGuid(), nome, descricao, observacao, valor, quantidadeEmEstoque, imagemURL);
        }
        public static Produto CriarProduto(Guid id, string nome, string descricao, string observacao, 
                                        decimal valor, int quantidadeEmEstoque, string imagemURL)
        {
            Produto produto = new Produto()
            {
                Name = nome,
                Descption = descricao,
                Observacao = observacao,
                Valor = valor,
                QuantidadeEmEstoque = quantidadeEmEstoque,
                ImagemURL = imagemURL,
                Estado = true,
                DataDeCriacao = DateTime.Now,
                DataDeAlteracao = DateTime.Now
            }; 

            return produto;         
        }
    }    
}

