-- MariaDB dump 10.17  Distrib 10.4.13-MariaDB, for Linux (x86_64)
--
-- Host: 127.0.0.1    Database: ravenous
-- ------------------------------------------------------
-- Server version	10.4.13-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `grocery_list`
--

DROP TABLE IF EXISTS `grocery_list`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `grocery_list` (
  `pk_grocery_list` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `fk_ingredient` int(10) unsigned NOT NULL,
  `ingredient_amount` float NOT NULL,
  `fk_measurement` int(10) unsigned NOT NULL,
  PRIMARY KEY (`pk_grocery_list`),
  KEY `grocery_list_ibfk_1_idx` (`fk_ingredient`),
  KEY `grocery_list_ibfk_2_idx` (`fk_measurement`),
  CONSTRAINT `grocery_list_ibfk_1` FOREIGN KEY (`fk_ingredient`) REFERENCES `ingredient` (`pk_ingredient`) ON UPDATE CASCADE,
  CONSTRAINT `grocery_list_ibfk_2` FOREIGN KEY (`fk_measurement`) REFERENCES `measurement` (`pk_measurement`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grocery_list`
--

LOCK TABLES `grocery_list` WRITE;
/*!40000 ALTER TABLE `grocery_list` DISABLE KEYS */;
/*!40000 ALTER TABLE `grocery_list` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredient`
--

DROP TABLE IF EXISTS `ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ingredient` (
  `pk_ingredient` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ingredient_name` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `fk_ingredient_type` int(10) unsigned NOT NULL,
  PRIMARY KEY (`pk_ingredient`),
  UNIQUE KEY `ingredient_name_UNIQUE` (`ingredient_name`),
  KEY `ingredient_type_ibfk_1_idx` (`fk_ingredient_type`),
  CONSTRAINT `ingredient_ibfk_1` FOREIGN KEY (`fk_ingredient_type`) REFERENCES `ingredient_type` (`pk_ingredient_type`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=205 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredient`
--

LOCK TABLES `ingredient` WRITE;
/*!40000 ALTER TABLE `ingredient` DISABLE KEYS */;
INSERT INTO `ingredient` VALUES (1,'Tequila',1),(2,'Vodka',1),(3,'Gin',1),(4,'Rum',1),(5,'White Bread',2),(6,'Whole Wheat Bread',2),(7,'Sourdough Bread',2),(8,'Garlic Bread',2),(9,'Tortilla',2),(10,'Pita Bread',2),(11,'Scallion Pancake',2),(12,'Chicken Stock',3),(13,'Chicken Broth',3),(14,'Vegetable Broth',3),(15,'Vegetable Stock',3),(16,'Beef Broth',3),(17,'Beef Stock',3),(19,'Sliced Mozzarella',7),(20,'Shredded Mozzarella',7),(21,'Sliced Cheddar',7),(22,'Shredded Cheddar',7),(23,'Shredded Mexican Cheese',7),(24,'Sliced Gouda',7),(25,'Sliced Colby',7),(26,'Sliced Colby Jack',7),(27,'Egg',10),(28,'Duck Egg',10),(29,'Whole Salmon',11),(30,'Salmon Fillet',11),(31,'Canned Tuna',11),(32,'Tuna Steak',11),(33,'Tilapia Fillet',11),(34,'Cod Fillet',11),(35,'Shrimp',11),(36,'Crab Legs',11),(37,'Crab Claws',11),(38,'Crab Meat',11),(39,'Lobster Tail',11),(40,'Sea Scallops',11),(41,'Bread Crumbs',2),(42,'Corn Meal',13),(43,'Buttermilk',7),(44,'Heavy Cream',7),(45,'Greek Yogurt',7),(46,'Sour Cream',7),(47,'Whipped Cream',7),(48,'Whole Milk',7),(49,'Golden Delicious Apple',4),(50,'Red Delicious Apple',4),(51,'Granny Smith Apple',4),(52,'Fuji Apple',4),(53,'Honeycrisp Apple',4),(54,'Pink Lady Apple',4),(55,'Green Grapes',4),(56,'Red Grapes',4),(57,'Cotton Candy Grapes',4),(58,'Watermellon',4),(59,'Apricot',4),(60,'Strawberries',4),(61,'Blueberries',4),(62,'Blackberries',4),(63,'Raspberries',4),(64,'Peach',4),(65,'Nectarine',4),(66,'Pineapple',4),(67,'Orange',4),(68,'Grits',13),(69,'Tortilla Chips',13),(70,'Corn On the Cobb',13),(71,'Canned Corn',13),(72,'Short Grain White Rice',13),(73,'Long Grain White Rice',13),(74,'Quinoa',13),(75,'Biscuit',2),(76,'Bagel',2),(77,'Yellow Rice',13),(78,'Wild Rice',13),(79,'Brown Rice',13),(80,'Oats',13),(81,'Whole Wheat Flour',13),(82,'All Purpose Flour',13),(83,'Bread Flour',13),(84,'Rice Flour',13),(85,'Hominy',13),(86,'Apple Juice',5),(87,'Orange Juice',5),(88,'Lemonade',5),(89,'Grape Juice',5),(90,'Cranberry Juice',5),(91,'Passion Fruit Juice',5),(92,'Beer',1),(93,'Strawberry Lemonade',5),(94,'New York Strip',9),(95,'Ribeye',9),(96,'Ground Beef',9),(97,'Ground Turkey',9),(98,'Filet Mignon',9),(99,'Whole Chicken',9),(100,'Baby Back Ribs',9),(101,'Pork Chop',9),(102,'Chicken Thighs',9),(103,'Chicken Breast',9),(104,'Bonless Skinless Chicken Thigh',9),(105,'Country Ribs',9),(106,'Pork Butt',9),(107,'Beef Roast',9),(108,'Soy Milk',15),(109,'Almond Milk',15),(110,'Coconut Milk',15),(111,'Tofu',15),(112,'Coconut Milk Yogurt',15),(113,'Coconut Milk Whipped Cream',15),(114,'Coconut Milk Ice Cream',15),(115,'Spaghetti',14),(116,'Thin Spaghetti',14),(117,'Mostaccioli',14),(118,'Hot Dogs',9),(119,'Bratwurst',9),(120,'Ground Sausage',9),(121,'Suasage Links',9),(122,'Sausage Patties',9),(123,'Angel Hair',14),(124,'Fettuccine',14),(125,'Lasagna',14),(126,'Vermicelli',14),(127,'Farfalle',14),(128,'Gnocchi',14),(129,'Penne',14),(130,'Orzo',14),(131,'Tortellini',14),(132,'Macaroni',14),(133,'Ramen Noodles',14),(134,'Soba Noodles',14),(135,'Garlic Powder',12),(136,'Oregano',12),(137,'Dried Basil',12),(138,'Basil',12),(139,'Dried Oregano',12),(140,'Bay Leaf',12),(141,'Berbere',12),(142,'Onion Powder',12),(143,'Celery Salt',12),(144,'Thyme',12),(145,'Dried Thyme',12),(146,'Paprika',12),(147,'Smoked Paprika',12),(148,'Old Bay Seasoning',12),(149,'Sugar',12),(150,'Brown Sugar',12),(151,'Powdered Sugar',12),(152,'Onion',6),(153,'Sweet Onion',6),(154,'Tomatoes',6),(155,'Crushed Tomatoes',6),(156,'Diced Tomatoes',6),(157,'Bell Pepper',6),(158,'Zucchini',6),(159,'Eggplant',6),(160,'Garlic',6),(161,'Tomatillos',6),(162,'Poblano',6),(163,'Potato',6),(164,'Sweet Potato',6),(165,'Squash',6),(166,'Spaghetti Squash',6),(167,'Cilantro',12),(168,'Parsley',12),(169,'Dried Parsley',12),(170,'Mint',12),(171,'Spinach',6),(172,'Lettuce',6),(173,'Carrot',6),(174,'Baby Carrots',6),(175,'Cucumber',6),(176,'Brussel Sprouts',6),(177,'Asparagus',6),(178,'Green Beans',6),(179,'Canned Green Beans',6),(180,'Canned French Green Beans',6),(181,'Canned Italian Green Beans',6),(182,'Cabbage Slaw',6),(183,'Black Beans',16),(184,'Great Northern Beans',16),(185,'Chick Peas',16),(186,'Red Lentils',16),(187,'Green Lentils',16),(188,'Cashews',16),(189,'Roasted Peanuts',16),(190,'Olive Oil',17),(191,'Vegetable Oil',17),(192,'Canola Oil',17),(193,'Apple Cider Vinegar',18),(194,'White Vinegar',18),(195,'Red Vinegar',18),(196,'Water',8),(197,'Simple Syrup',20),(198,'Agave Syrup',20),(199,'Lime Juice',5),(200,'Sweet and Sour Mix',20),(201,'Bitters',20),(202,'Orange Peel',12),(203,'Lime Peel',12),(204,'Elderberry Syrup',20);
/*!40000 ALTER TABLE `ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredient_type`
--

DROP TABLE IF EXISTS `ingredient_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ingredient_type` (
  `pk_ingredient_type` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `ingredient_type_name` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`pk_ingredient_type`),
  UNIQUE KEY `ingredient_type_UNIQUE` (`ingredient_type_name`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredient_type`
--

LOCK TABLES `ingredient_type` WRITE;
/*!40000 ALTER TABLE `ingredient_type` DISABLE KEYS */;
INSERT INTO `ingredient_type` VALUES (1,'Alcohol'),(2,'Bread'),(3,'Broth'),(7,'Dairy'),(10,'Egg'),(4,'Fruit'),(13,'Grain'),(5,'Juice'),(16,'Legumes'),(9,'Meat'),(20,'Mixer'),(15,'Non-Dairy'),(17,'Oil'),(14,'Pasta'),(11,'Seafood'),(12,'Spice'),(6,'Vegetable'),(18,'Vinegar'),(8,'Water');
/*!40000 ALTER TABLE `ingredient_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `measurement`
--

DROP TABLE IF EXISTS `measurement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `measurement` (
  `pk_measurement` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `measurement_name` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`pk_measurement`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `measurement`
--

LOCK TABLES `measurement` WRITE;
/*!40000 ALTER TABLE `measurement` DISABLE KEYS */;
INSERT INTO `measurement` VALUES (1,'tablespoon'),(2,'teaspoon'),(9,'cup'),(10,'quart'),(11,'gallon'),(12,'milliliter'),(13,'ounce'),(14,'gram'),(15,'pound');
/*!40000 ALTER TABLE `measurement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe`
--

DROP TABLE IF EXISTS `recipe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recipe` (
  `pk_recipe` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `recipe_name` varchar(128) COLLATE utf8_unicode_ci NOT NULL,
  `prep_time` time NOT NULL DEFAULT '00:00:00',
  `cook_time` time NOT NULL DEFAULT '00:00:00',
  `fk_recipe_type` int(10) unsigned NOT NULL,
  `rating` int(10) unsigned DEFAULT 0,
  PRIMARY KEY (`pk_recipe`),
  UNIQUE KEY `recipe_name_UNIQUE` (`recipe_name`),
  KEY `recipe_type_ibfk_1_idx` (`fk_recipe_type`),
  CONSTRAINT `recipe_ibfk_1` FOREIGN KEY (`fk_recipe_type`) REFERENCES `recipe_type` (`pk_recipe_type`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe`
--

LOCK TABLES `recipe` WRITE;
/*!40000 ALTER TABLE `recipe` DISABLE KEYS */;
INSERT INTO `recipe` VALUES (1,'Scotch','00:00:00','00:00:00',10,0);
/*!40000 ALTER TABLE `recipe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe_ingredient`
--

DROP TABLE IF EXISTS `recipe_ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recipe_ingredient` (
  `pk_recipe_ingredient` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `fk_ingredient` int(10) unsigned NOT NULL,
  `ingredient_amount` float NOT NULL,
  `fk_measurement` int(10) unsigned NOT NULL,
  PRIMARY KEY (`pk_recipe_ingredient`),
  KEY `fk_ingredient_ibfk_1_idx` (`fk_ingredient`),
  KEY `fk_recipe_ingredient_ibfk_2_idx` (`fk_measurement`),
  CONSTRAINT `recipe_ingredient_ibfk_1` FOREIGN KEY (`fk_ingredient`) REFERENCES `ingredient` (`pk_ingredient`) ON UPDATE CASCADE,
  CONSTRAINT `recipe_ingredient_ibfk_2` FOREIGN KEY (`fk_measurement`) REFERENCES `measurement` (`pk_measurement`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_ingredient`
--

LOCK TABLES `recipe_ingredient` WRITE;
/*!40000 ALTER TABLE `recipe_ingredient` DISABLE KEYS */;
/*!40000 ALTER TABLE `recipe_ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe_step`
--

DROP TABLE IF EXISTS `recipe_step`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recipe_step` (
  `pk_recipe_step` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `fk_recipe` int(10) unsigned NOT NULL,
  `recipe_step_number` int(10) unsigned NOT NULL,
  `recipe_step_instruction` varchar(512) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`pk_recipe_step`),
  KEY `recipe_step_ibfk_1_idx` (`fk_recipe`),
  CONSTRAINT `recipe_step_ibfk_1` FOREIGN KEY (`fk_recipe`) REFERENCES `recipe` (`pk_recipe`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_step`
--

LOCK TABLES `recipe_step` WRITE;
/*!40000 ALTER TABLE `recipe_step` DISABLE KEYS */;
/*!40000 ALTER TABLE `recipe_step` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe_tag`
--

DROP TABLE IF EXISTS `recipe_tag`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recipe_tag` (
  `pk_recipe_tag` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `fk_recipe` int(10) unsigned NOT NULL,
  `fk_tag` int(10) unsigned NOT NULL,
  PRIMARY KEY (`pk_recipe_tag`),
  KEY `recipe_tag_ibfk_1_idx` (`fk_recipe`),
  KEY `recipe_tag_ibfk_2_idx` (`fk_tag`),
  CONSTRAINT `recipe_tag_ibfk_1` FOREIGN KEY (`fk_recipe`) REFERENCES `recipe` (`pk_recipe`) ON UPDATE CASCADE,
  CONSTRAINT `recipe_tag_ibfk_2` FOREIGN KEY (`fk_tag`) REFERENCES `tag` (`pk_tag`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_tag`
--

LOCK TABLES `recipe_tag` WRITE;
/*!40000 ALTER TABLE `recipe_tag` DISABLE KEYS */;
INSERT INTO `recipe_tag` VALUES (1,1,2);
/*!40000 ALTER TABLE `recipe_tag` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe_type`
--

DROP TABLE IF EXISTS `recipe_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recipe_type` (
  `pk_recipe_type` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `recipe_type_name` varchar(64) COLLATE utf8_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`pk_recipe_type`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_type`
--

LOCK TABLES `recipe_type` WRITE;
/*!40000 ALTER TABLE `recipe_type` DISABLE KEYS */;
INSERT INTO `recipe_type` VALUES (5,'Appitizer'),(6,'Main Course'),(8,'Side Dish'),(9,'Dessert'),(10,'Alcohol');
/*!40000 ALTER TABLE `recipe_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tag`
--

DROP TABLE IF EXISTS `tag`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tag` (
  `pk_tag` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `tag_name` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  PRIMARY KEY (`pk_tag`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tag`
--

LOCK TABLES `tag` WRITE;
/*!40000 ALTER TABLE `tag` DISABLE KEYS */;
INSERT INTO `tag` VALUES (1,'Dairy Free'),(2,'Comfort Food');
/*!40000 ALTER TABLE `tag` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-20 21:32:35
