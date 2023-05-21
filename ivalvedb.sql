-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Maj 22, 2023 at 12:19 AM
-- Wersja serwera: 10.4.28-MariaDB
-- Wersja PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `ivalvedb`
--

DELIMITER $$
--
-- Procedury
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_DeletePerson` (IN `ID` INT)   BEGIN
	DELETE FROM person WHERE person.Person_ID = ID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditPerson` (IN `FirstName` VARCHAR(255), IN `LastName` VARCHAR(255), IN `BirthDate` DATE, IN `Role` INT, IN `Status` INT, IN `Room` INT, IN `ID` INT)   BEGIN
UPDATE person SET Firstname = FirstName, Lastname = LastName, BirthDate = BirthDate, Role = Role, Status = Status, Room = Room WHERE Person_ID = ID;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_EditSupply` (IN `ID` INT, IN `Amount` DECIMAL, IN `Option` VARCHAR(255))   BEGIN
	IF Option = 'Drink' THEN
    	UPDATE drinks SET drinks.Amount = Amount WHERE drinks.Drink_ID = ID;
  	ELSEIF Option = 'Food' THEN
		UPDATE food SET food.Amount = Amount WHERE food.Food_ID = ID;
   	ELSEIF Option = 'Item' THEN
		UPDATE items SET items.Amount = Amount WHERE items.Item_ID = ID;
END IF;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_NewDrink` (IN `Name` VARCHAR(255), IN `Type` INT, IN `Amount` DECIMAL, OUT `new_ID` INT)   BEGIN
	INSERT INTO drinks (drinks.Name, drinks.Amount, drinks.Type) VALUES (Name, Amount, Type);
    SET new_ID = LAST_INSERT_ID();
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_NewFood` (IN `Name` VARCHAR(255), IN `Type` INT, IN `Amount` DECIMAL, OUT `new_ID` INT)   BEGIN
	INSERT INTO food (food.Name, food.Amount, food.Type) VALUES (Name, Amount, Type);
    SET new_ID = LAST_INSERT_ID();
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_NewItem` (IN `Name` VARCHAR(255), IN `Type` INT, IN `Amount` INT, OUT `new_ID` INT)   BEGIN
	INSERT INTO items (items.Name, items.Amount, items.Type) VALUES (Name, Amount, Type);
    SET new_ID = LAST_INSERT_ID();
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_NewPerson` (IN `FirstName` VARCHAR(255), IN `LastName` VARCHAR(255), IN `BirthDate` DATE, IN `Role` INT, IN `Status` INT, IN `Room` INT, OUT `new_id` INT)   BEGIN
	INSERT INTO person (Firstname, Lastname, BirthDate, Role, Status, Room) VALUES (FirstName, LastName, BirthDate, Role, Status, Room);
    SET new_id = LAST_INSERT_ID();
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `drinks`
--

CREATE TABLE `drinks` (
  `Drink_ID` int(11) NOT NULL,
  `Name` varchar(500) NOT NULL,
  `Amount` decimal(10,0) NOT NULL,
  `Type` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `drinks`
--

INSERT INTO `drinks` (`Drink_ID`, `Name`, `Amount`, `Type`) VALUES
(4, 'Water', 15, 2),
(5, 'Sparkling water', 12, 2),
(6, 'Beer', 1, 2),
(7, 'Vodka', 3, 2);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `food`
--

CREATE TABLE `food` (
  `Food_ID` int(11) NOT NULL,
  `Name` varchar(500) NOT NULL,
  `Type` int(11) NOT NULL,
  `Amount` decimal(10,0) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `food`
--

INSERT INTO `food` (`Food_ID`, `Name`, `Type`, `Amount`) VALUES
(1, 'Pineapple', 1, 5),
(2, 'Tuna', 1, 3),
(3, 'Ham', 1, 3),
(4, 'Test', 1, 21),
(6, 'Test12', 1, 23),
(7, 'teste', 1, 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `items`
--

CREATE TABLE `items` (
  `Item_ID` int(11) NOT NULL,
  `Name` varchar(500) NOT NULL,
  `Amount` int(11) NOT NULL,
  `Type` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `items`
--

INSERT INTO `items` (`Item_ID`, `Name`, `Amount`, `Type`) VALUES
(3, 'm10 screw', 45, 3),
(4, 'm15 screw', 115, 3),
(5, 'm8 screw', 114, 3),
(6, 'Toilet paper', 200, 4);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `jobs`
--

CREATE TABLE `jobs` (
  `Job_ID` int(11) NOT NULL,
  `Name` varchar(500) NOT NULL,
  `Deadline` date DEFAULT NULL,
  `JobType` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `jobtypes`
--

CREATE TABLE `jobtypes` (
  `Type_ID` int(11) NOT NULL,
  `Name` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `person`
--

CREATE TABLE `person` (
  `Person_ID` int(11) NOT NULL,
  `Firstname` varchar(255) NOT NULL,
  `Lastname` varchar(255) NOT NULL,
  `BirthDate` date NOT NULL DEFAULT current_timestamp(),
  `Role` int(11) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `Room` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `person`
--

INSERT INTO `person` (`Person_ID`, `Firstname`, `Lastname`, `BirthDate`, `Role`, `Status`, `Room`) VALUES
(1, 'Jan', 'Kowalski', '1998-02-02', 1, 2, 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `personjobs`
--

CREATE TABLE `personjobs` (
  `Person_ID` int(11) NOT NULL,
  `Job_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `roles`
--

CREATE TABLE `roles` (
  `Role_ID` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`Role_ID`, `Name`) VALUES
(1, 'Worker');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `rooms`
--

CREATE TABLE `rooms` (
  `Room_ID` int(11) NOT NULL,
  `Section` int(11) NOT NULL,
  `Capacity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `rooms`
--

INSERT INTO `rooms` (`Room_ID`, `Section`, `Capacity`) VALUES
(1, 1, 5);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `sections`
--

CREATE TABLE `sections` (
  `Section_ID` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `sections`
--

INSERT INTO `sections` (`Section_ID`, `Name`) VALUES
(1, 'Green');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `status`
--

CREATE TABLE `status` (
  `Status_ID` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `status`
--

INSERT INTO `status` (`Status_ID`, `Name`) VALUES
(1, 'Alive'),
(2, 'Dead');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `supplytypes`
--

CREATE TABLE `supplytypes` (
  `Type_ID` int(11) NOT NULL,
  `Name` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Dumping data for table `supplytypes`
--

INSERT INTO `supplytypes` (`Type_ID`, `Name`) VALUES
(1, 'Canned food'),
(2, 'Bottled'),
(3, 'Screw'),
(4, 'Hygiene');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `tools`
--

CREATE TABLE `tools` (
  `Tool_ID` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Amount` int(11) NOT NULL,
  `JobType` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `drinks`
--
ALTER TABLE `drinks`
  ADD PRIMARY KEY (`Drink_ID`),
  ADD UNIQUE KEY `Name` (`Name`),
  ADD KEY `Type` (`Type`);

--
-- Indeksy dla tabeli `food`
--
ALTER TABLE `food`
  ADD PRIMARY KEY (`Food_ID`),
  ADD UNIQUE KEY `Name` (`Name`),
  ADD KEY `Type` (`Type`);

--
-- Indeksy dla tabeli `items`
--
ALTER TABLE `items`
  ADD PRIMARY KEY (`Item_ID`),
  ADD UNIQUE KEY `Name` (`Name`),
  ADD KEY `Type` (`Type`);

--
-- Indeksy dla tabeli `jobs`
--
ALTER TABLE `jobs`
  ADD PRIMARY KEY (`Job_ID`),
  ADD KEY `JobType` (`JobType`);

--
-- Indeksy dla tabeli `jobtypes`
--
ALTER TABLE `jobtypes`
  ADD PRIMARY KEY (`Type_ID`);

--
-- Indeksy dla tabeli `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`Person_ID`),
  ADD KEY `Role` (`Role`),
  ADD KEY `Status` (`Status`),
  ADD KEY `Room` (`Room`);

--
-- Indeksy dla tabeli `personjobs`
--
ALTER TABLE `personjobs`
  ADD PRIMARY KEY (`Person_ID`,`Job_ID`),
  ADD KEY `Job_ID` (`Job_ID`);

--
-- Indeksy dla tabeli `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`Role_ID`);

--
-- Indeksy dla tabeli `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`Room_ID`),
  ADD KEY `Section` (`Section`);

--
-- Indeksy dla tabeli `sections`
--
ALTER TABLE `sections`
  ADD PRIMARY KEY (`Section_ID`);

--
-- Indeksy dla tabeli `status`
--
ALTER TABLE `status`
  ADD PRIMARY KEY (`Status_ID`);

--
-- Indeksy dla tabeli `supplytypes`
--
ALTER TABLE `supplytypes`
  ADD PRIMARY KEY (`Type_ID`);

--
-- Indeksy dla tabeli `tools`
--
ALTER TABLE `tools`
  ADD PRIMARY KEY (`Tool_ID`),
  ADD KEY `JobType` (`JobType`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `drinks`
--
ALTER TABLE `drinks`
  MODIFY `Drink_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `food`
--
ALTER TABLE `food`
  MODIFY `Food_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `items`
--
ALTER TABLE `items`
  MODIFY `Item_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `jobs`
--
ALTER TABLE `jobs`
  MODIFY `Job_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `jobtypes`
--
ALTER TABLE `jobtypes`
  MODIFY `Type_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `person`
--
ALTER TABLE `person`
  MODIFY `Person_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `roles`
--
ALTER TABLE `roles`
  MODIFY `Role_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `rooms`
--
ALTER TABLE `rooms`
  MODIFY `Room_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `sections`
--
ALTER TABLE `sections`
  MODIFY `Section_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `status`
--
ALTER TABLE `status`
  MODIFY `Status_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `supplytypes`
--
ALTER TABLE `supplytypes`
  MODIFY `Type_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `tools`
--
ALTER TABLE `tools`
  MODIFY `Tool_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `drinks`
--
ALTER TABLE `drinks`
  ADD CONSTRAINT `drinks_ibfk_1` FOREIGN KEY (`Type`) REFERENCES `supplytypes` (`Type_ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `food`
--
ALTER TABLE `food`
  ADD CONSTRAINT `food_ibfk_1` FOREIGN KEY (`Type`) REFERENCES `supplytypes` (`Type_ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `items`
--
ALTER TABLE `items`
  ADD CONSTRAINT `items_ibfk_1` FOREIGN KEY (`Type`) REFERENCES `supplytypes` (`Type_ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `jobs`
--
ALTER TABLE `jobs`
  ADD CONSTRAINT `jobs_ibfk_1` FOREIGN KEY (`JobType`) REFERENCES `jobtypes` (`Type_ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `person`
--
ALTER TABLE `person`
  ADD CONSTRAINT `person_ibfk_1` FOREIGN KEY (`Room`) REFERENCES `rooms` (`Room_ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `person_ibfk_2` FOREIGN KEY (`Status`) REFERENCES `status` (`Status_ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `person_ibfk_3` FOREIGN KEY (`Role`) REFERENCES `roles` (`Role_ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `personjobs`
--
ALTER TABLE `personjobs`
  ADD CONSTRAINT `personjobs_ibfk_1` FOREIGN KEY (`Job_ID`) REFERENCES `jobs` (`Job_ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `personjobs_ibfk_2` FOREIGN KEY (`Person_ID`) REFERENCES `person` (`Person_ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `rooms`
--
ALTER TABLE `rooms`
  ADD CONSTRAINT `rooms_ibfk_1` FOREIGN KEY (`Section`) REFERENCES `sections` (`Section_ID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `tools`
--
ALTER TABLE `tools`
  ADD CONSTRAINT `tools_ibfk_1` FOREIGN KEY (`JobType`) REFERENCES `jobtypes` (`Type_ID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
