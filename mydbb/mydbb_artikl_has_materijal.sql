-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: mydbb
-- ------------------------------------------------------
-- Server version	8.0.28

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
-- Table structure for table `artikl_has_materijal`
--

DROP TABLE IF EXISTS `artikl_has_materijal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `artikl_has_materijal` (
  `idahm` int NOT NULL AUTO_INCREMENT,
  `artikl_idartikl` int NOT NULL,
  `materijal_idmaterijal` int NOT NULL,
  `kolicina` float NOT NULL,
  PRIMARY KEY (`idahm`),
  KEY `fk_artikl_has_materijal_materijal1_idx` (`materijal_idmaterijal`),
  KEY `fk_artikl_has_materijal_artikl1_idx` (`artikl_idartikl`),
  CONSTRAINT `fk_artikl_has_materijal_artikl1` FOREIGN KEY (`artikl_idartikl`) REFERENCES `artikl` (`idartikl`),
  CONSTRAINT `fk_artikl_has_materijal_materijal1` FOREIGN KEY (`materijal_idmaterijal`) REFERENCES `materijal` (`idmaterijal`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `artikl_has_materijal`
--

LOCK TABLES `artikl_has_materijal` WRITE;
/*!40000 ALTER TABLE `artikl_has_materijal` DISABLE KEYS */;
/*!40000 ALTER TABLE `artikl_has_materijal` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-02-25 23:35:40
