CREATE DATABASE StudentDB;

USE StudentDB;

DROP TABLE IF EXISTS `Students`;

CREATE TABLE `Students` (
    `Id` INT AUTO_INCREMENT,
    `Name` VARCHAR(80) NOT NULL,
    `Email` VARCHAR(30) NOT NULL,
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `Students` WRITE;
INSERT INTO `Students` VALUES (1, 'Nome 1', 'email1@email.com');
INSERT INTO `Students` VALUES (2, 'Nome 2', 'email2@email.com');
INSERT INTO `Students` VALUES (3, 'Nome 3', 'email3@email.com');
INSERT INTO `Students` VALUES (4, 'Nome 4', 'email4@email.com');
INSERT INTO `Students` VALUES (5, 'Nome 5', 'email5@email.com');
UNLOCK TABLES;