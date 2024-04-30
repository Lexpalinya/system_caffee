-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 30, 2024 at 08:34 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cafe_shop_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `tb_account`
--

CREATE TABLE `tb_account` (
  `accId` int(11) NOT NULL,
  `accEmpId` int(11) NOT NULL,
  `accLevel` enum('Seller','Admin') NOT NULL,
  `accUserName` varchar(100) NOT NULL,
  `accPassword` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tb_bill`
--

CREATE TABLE `tb_bill` (
  `blId` int(11) NOT NULL,
  `blMbId` int(11) NOT NULL,
  `blAccId` int(11) NOT NULL,
  `blTotalMoney` double NOT NULL,
  `blDate` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tb_billdetail`
--

CREATE TABLE `tb_billdetail` (
  `bdblID` int(11) NOT NULL,
  `bdPId` int(11) NOT NULL,
  `bdSize` varchar(1) NOT NULL,
  `bdPrice` int(11) NOT NULL,
  `bdAmount` int(11) NOT NULL,
  `bdTotal` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tb_employee`
--

CREATE TABLE `tb_employee` (
  `empId` int(11) NOT NULL,
  `empName` varchar(100) NOT NULL,
  `empLastName` varchar(100) NOT NULL,
  `empAddress` varchar(100) NOT NULL,
  `empPhoneNumber` varchar(15) NOT NULL,
  `empPosition` varchar(100) NOT NULL,
  `empSalary` int(11) NOT NULL,
  `empImage` longblob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tb_member`
--

CREATE TABLE `tb_member` (
  `mbId` int(11) NOT NULL,
  `mbName` varchar(100) NOT NULL,
  `mbPhoneNumber` varchar(15) NOT NULL,
  `mbAddress` varchar(100) NOT NULL,
  `mbPoints` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tb_paidrecord`
--

CREATE TABLE `tb_paidrecord` (
  `prId` int(11) NOT NULL,
  `prText` text NOT NULL,
  `prAumout` int(11) NOT NULL,
  `prPrice` int(11) NOT NULL,
  `prDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tb_products`
--

CREATE TABLE `tb_products` (
  `pId` int(11) NOT NULL,
  `pName` varchar(100) NOT NULL,
  `pType` enum('hot','cool','mix','other') NOT NULL,
  `pSize` varchar(50) NOT NULL,
  `pPrice` int(11) NOT NULL,
  `pImage` longblob NOT NULL,
  `pStauts` tinyint(1) NOT NULL,
  `pPriceOriginal` int(11) NOT NULL,
  `pExp` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tb_salarypayment`
--

CREATE TABLE `tb_salarypayment` (
  `spId` int(11) NOT NULL,
  `spEmpId` int(11) NOT NULL,
  `spSalary` int(11) NOT NULL,
  `spPayday` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tb_account`
--
ALTER TABLE `tb_account`
  ADD PRIMARY KEY (`accId`),
  ADD KEY `accempId` (`accEmpId`);

--
-- Indexes for table `tb_bill`
--
ALTER TABLE `tb_bill`
  ADD PRIMARY KEY (`blId`),
  ADD KEY `blMbId` (`blMbId`),
  ADD KEY `blAccId` (`blAccId`);

--
-- Indexes for table `tb_billdetail`
--
ALTER TABLE `tb_billdetail`
  ADD KEY `bdblID` (`bdblID`),
  ADD KEY `bdPId` (`bdPId`);

--
-- Indexes for table `tb_employee`
--
ALTER TABLE `tb_employee`
  ADD PRIMARY KEY (`empId`);

--
-- Indexes for table `tb_member`
--
ALTER TABLE `tb_member`
  ADD PRIMARY KEY (`mbId`);

--
-- Indexes for table `tb_paidrecord`
--
ALTER TABLE `tb_paidrecord`
  ADD PRIMARY KEY (`prId`);

--
-- Indexes for table `tb_products`
--
ALTER TABLE `tb_products`
  ADD PRIMARY KEY (`pId`);

--
-- Indexes for table `tb_salarypayment`
--
ALTER TABLE `tb_salarypayment`
  ADD PRIMARY KEY (`spId`),
  ADD KEY `spEmpId` (`spEmpId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tb_account`
--
ALTER TABLE `tb_account`
  MODIFY `accId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tb_bill`
--
ALTER TABLE `tb_bill`
  MODIFY `blId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tb_employee`
--
ALTER TABLE `tb_employee`
  MODIFY `empId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `tb_member`
--
ALTER TABLE `tb_member`
  MODIFY `mbId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tb_paidrecord`
--
ALTER TABLE `tb_paidrecord`
  MODIFY `prId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tb_products`
--
ALTER TABLE `tb_products`
  MODIFY `pId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tb_salarypayment`
--
ALTER TABLE `tb_salarypayment`
  MODIFY `spId` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tb_account`
--
ALTER TABLE `tb_account`
  ADD CONSTRAINT `tb_account_ibfk_1` FOREIGN KEY (`accempId`) REFERENCES `tb_employee` (`empId`);

--
-- Constraints for table `tb_bill`
--
ALTER TABLE `tb_bill`
  ADD CONSTRAINT `tb_bill_ibfk_2` FOREIGN KEY (`blMbId`) REFERENCES `tb_member` (`mbId`),
  ADD CONSTRAINT `tb_bill_ibfk_3` FOREIGN KEY (`blAccId`) REFERENCES `tb_account` (`accId`);

--
-- Constraints for table `tb_billdetail`
--
ALTER TABLE `tb_billdetail`
  ADD CONSTRAINT `tb_billdetail_ibfk_1` FOREIGN KEY (`bdblID`) REFERENCES `tb_bill` (`blId`),
  ADD CONSTRAINT `tb_billdetail_ibfk_2` FOREIGN KEY (`bdPId`) REFERENCES `tb_products` (`pId`);

--
-- Constraints for table `tb_salarypayment`
--
ALTER TABLE `tb_salarypayment`
  ADD CONSTRAINT `tb_salarypayment_ibfk_1` FOREIGN KEY (`spEmpId`) REFERENCES `tb_employee` (`empId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
