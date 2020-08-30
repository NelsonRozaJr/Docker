CREATE DATABASE ProductDB;

USE ProductDB;

DROP TABLE IF EXISTS `Products`;

CREATE TABLE `Products` (
    `ProductId` INT AUTO_INCREMENT,
    `Name` VARCHAR(80) NOT NULL,
    `Category` VARCHAR(50) NOT NULL,
    `Price` DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (`ProductId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `Products` WRITE;
INSERT INTO `Products` VALUES (1, 'Product 01', 'Category 01', 10);
INSERT INTO `Products` VALUES (2, 'Product 02', 'Category 02', 15);
INSERT INTO `Products` VALUES (3, 'Product 03', 'Category 03', 13);
INSERT INTO `Products` VALUES (4, 'Product 04', 'Category 04', 11);
INSERT INTO `Products` VALUES (5, 'Product 05', 'Category 01', 19);
INSERT INTO `Products` VALUES (6, 'Product 06', 'Category 03', 15);
INSERT INTO `Products` VALUES (7, 'Product 07', 'Category 02', 16);
INSERT INTO `Products` VALUES (8, 'Product 08', 'Category 02', 19);
INSERT INTO `Products` VALUES (9, 'Product 09', 'Category 01', 20);
INSERT INTO `Products` VALUES (10, 'Product 10', 'Category 01', 14);
UNLOCK TABLES;