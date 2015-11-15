-- phpMyAdmin SQL Dump
-- version 4.2.7.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Nov 15, 2015 at 01:58 PM
-- Server version: 5.6.20-log
-- PHP Version: 5.4.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `magasin`
--

-- --------------------------------------------------------

--
-- Table structure for table `produit`
--

CREATE TABLE IF NOT EXISTS `produit` (
`id` int(11) NOT NULL,
  `designation` varchar(50) COLLATE latin1_bin NOT NULL,
  `prixUnitaire` double NOT NULL,
  `quantiteEnStock` int(11) NOT NULL
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 COLLATE=latin1_bin AUTO_INCREMENT=11 ;

--
-- Dumping data for table `produit`
--

INSERT INTO `produit` (`id`, `designation`, `prixUnitaire`, `quantiteEnStock`) VALUES
(1, 'MacBook Pro', 9753.1, 24),
(2, 'iPhone', 791.35, 468),
(3, 'iPad', 579.24, 802),
(4, 'Pc', 234.56, 7890),
(5, 'Cle usb', 135.68, 147026),
(6, 'livre Delphi', 99.47, 5274),
(7, 'Laptop MSi', 5748.9, 2),
(8, 'Tablette SamSung', 244.55, 123),
(10, 'Bose Headphone', 360.25, 851),
(9, 'ThinkPad', 458.01, 4286);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `produit`
--
ALTER TABLE `produit`
 ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `produit`
--
ALTER TABLE `produit`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
