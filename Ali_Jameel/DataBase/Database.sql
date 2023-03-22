-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: alijameel
-- ------------------------------------------------------
-- Server version	5.7.33-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `news`
--

DROP TABLE IF EXISTS `news`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `news` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(1000) DEFAULT NULL,
  `description` longtext,
  `logo` varchar(1000) DEFAULT NULL,
  `WebsiteLink` varchar(1000) DEFAULT NULL,
  `htmlContent` longtext,
  `PublishDate` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=65 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `news`
--

LOCK TABLES `news` WRITE;
/*!40000 ALTER TABLE `news` DISABLE KEYS */;
INSERT INTO `news` VALUES (58,'a','grnata is hiring new stuff grnata is hiring new stuff grnata is hiring new stuff grnata is hiring new stuff grnata is hiring new stuff grnata is hiring new stuff grnata is hiring new stuff grnata is hiring new stuff','whatsapp.png','https://www.microcentergulf.com/',NULL,'3/15/2023 12:44:18 PM'),(62,'ali','ss','Picture_–_Heathen_Rock_Festival_2016_08.jpg','https://localhost:44309/Home/News',NULL,'3/20/2023 11:06:11 AM'),(63,'aaaa','a','whatsapp.png','aaa',NULL,'3/22/2023 10:43:15 AM'),(64,'sss','sss','Picture_–_Heathen_Rock_Festival_2016_08.jpg','sss',NULL,'3/22/2023 11:16:31 AM');
/*!40000 ALTER TABLE `news` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (0,'User'),(1,'Administrator');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `userid` int(11) NOT NULL AUTO_INCREMENT,
  `fullname` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `date_of_birth` varchar(45) DEFAULT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `Role` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`userid`),
  UNIQUE KEY `email_UNIQUE` (`email`),
  UNIQUE KEY `username_UNIQUE` (`username`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Admin','Admin@hotmail.com','1/2/1996 12:00:00 AM','Admin','alimohdjas',1),(41,'Ali Jameel','ali-jameel@hotmail.com',NULL,'ali_jameel','1108',0),(42,'Jassim Ali','jassim-96@live.com',NULL,'Jassim_Ali','1437',1),(43,'mohammed ','logical86@gmail.com',NULL,'mohd_f','2112',1);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendor`
--

DROP TABLE IF EXISTS `vendor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vendor` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `CompanyName` varchar(100) DEFAULT NULL,
  `CompanyLogo` varchar(100) DEFAULT NULL,
  `CompanyURL` varchar(100) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `Address` varchar(100) DEFAULT NULL,
  `ContactNumber` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendor`
--

LOCK TABLES `vendor` WRITE;
/*!40000 ALTER TABLE `vendor` DISABLE KEYS */;
INSERT INTO `vendor` VALUES (12,'microcenter group','123.jfif','3fq','iiiiiiiiiiiiiiiisimbas@hotmail.com','wrg','11166165'),(13,'ahmed','thumbnail_image0 (2).jpg','rwg','pknsimbas@hotmail.com','gw','66666666'),(14,'ahmed company','123.jfif','wrg','aliabbas@hotmail.com','SEWSE','66666655'),(15,'ahmed company','123.jfif','aaa','sss@hotmail.com','ahmed@hotmail.com','39977044'),(16,'microcenter group','thumbnail_image0 (2).jpg','ww','ww','ww','ww');
/*!40000 ALTER TABLE `vendor` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-03-22 11:35:23
