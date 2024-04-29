### Script de criação do banco de dados

```sql
-- ----------------------------
-- Estrutura da tabela `cliente`
-- ----------------------------
DROP TABLE IF EXISTS `cliente`;
CREATE TABLE `cliente` (
  `cliente_id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(120) NOT NULL DEFAULT "",
  `cpf` char(11) NOT NULL DEFAULT "",
  `identidade` varchar(15) NOT NULL DEFAULT "",
  `cnpj` char(14) NOT NULL DEFAULT "",
  `inscricao_estadual` varchar(15) NOT NULL DEFAULT "",
  `ativo` tinyint(1) NOT NULL DEFAULT '0',
  `excluido` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`cliente_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Estrutura da tabela `produto`
-- ----------------------------
DROP TABLE IF EXISTS `produto`;
CREATE TABLE `produto` (
  `produto_id` int(11) NOT NULL AUTO_INCREMENT,
  `descricao` varchar(200) NOT NULL DEFAULT "",
  `preco_custo` decimal(11,4) NOT NULL DEFAULT '0.0000',
  `preco_venda` decimal(11,4) NOT NULL DEFAULT '0.0000',
  `ativo` tinyint(1) NOT NULL DEFAULT '0',
  `excluido` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`produto_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Estrutura da tabela `venda`
-- ----------------------------
DROP TABLE IF EXISTS `venda`;
CREATE TABLE `venda` (
  `venda_id` int(11) NOT NULL AUTO_INCREMENT,
  `data_hora` datetime NOT NULL DEFAULT '1000-01-01 00:00:00',
  `cliente_id` int(11) DEFAULT NULL,
  `valor_bruto` decimal(10,4) NOT NULL DEFAULT '0.0000',
  `acrescimo` decimal(10,4) NOT NULL DEFAULT '0.0000',
  `desconto` decimal(10,4) NOT NULL DEFAULT '0.0000',
  `valor_liquido` decimal(10,4) NOT NULL DEFAULT '0.0000',
  `cancelada` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`venda_id`),
  KEY `fk_1_venda` (`cliente_id`),
  CONSTRAINT `fk_1_venda` FOREIGN KEY (`cliente_id`) REFERENCES `cliente` (`cliente_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Estrutura da tabela `venda_item`
-- ----------------------------
DROP TABLE IF EXISTS `venda_item`;
CREATE TABLE `venda_item` (
  `venda_item_id` int(11) NOT NULL AUTO_INCREMENT,
  `venda_id` int(11) NOT NULL DEFAULT '0',
  `numero_item` int(5) NOT NULL DEFAULT '0',
  `quantidade` decimal(11,4) NOT NULL DEFAULT '0.0000',
  `preco_venda` decimal(11,4) NOT NULL DEFAULT '0.0000',
  `excluido` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`venda_item_id`),
  KEY `fk_1_venda_item` (`venda_id`),
  CONSTRAINT `fk_1_venda_item` FOREIGN KEY (`venda_id`) REFERENCES `venda` (`venda_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
```
