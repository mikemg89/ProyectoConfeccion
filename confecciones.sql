-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 18-11-2022 a las 03:02:46
-- Versión del servidor: 5.7.36
-- Versión de PHP: 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `confecciones`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

DROP TABLE IF EXISTS `clientes`;
CREATE TABLE IF NOT EXISTS `clientes` (
  `id` int(5) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(10) NOT NULL,
  `RUT` varchar(20) NOT NULL,
  `nombre` text NOT NULL,
  `direccion` text NOT NULL,
  `telefono` text NOT NULL,
  `correo` text NOT NULL,
  `jefe_produccion` int(5) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `jefe_produccion` (`jefe_produccion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `jefe_produccion`
--

DROP TABLE IF EXISTS `jefe_produccion`;
CREATE TABLE IF NOT EXISTS `jefe_produccion` (
  `id` int(5) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(10) NOT NULL,
  `nombre` text NOT NULL,
  `apellido` text NOT NULL,
  `correo` varchar(50) NOT NULL,
  `telefono` varchar(13) NOT NULL,
  `referencia` int(5) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `referencia` (`referencia`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `maquina`
--

DROP TABLE IF EXISTS `maquina`;
CREATE TABLE IF NOT EXISTS `maquina` (
  `id` int(5) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(10) NOT NULL,
  `nombre` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `operarios`
--

DROP TABLE IF EXISTS `operarios`;
CREATE TABLE IF NOT EXISTS `operarios` (
  `id` int(5) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(5) NOT NULL,
  `documento` varchar(10) NOT NULL,
  `nombre` text NOT NULL,
  `apellido` text NOT NULL,
  `edad` int(3) NOT NULL,
  `correo` varchar(30) NOT NULL,
  `telefono` varchar(13) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `referencia`
--

DROP TABLE IF EXISTS `referencia`;
CREATE TABLE IF NOT EXISTS `referencia` (
  `id` int(5) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(10) NOT NULL,
  `OP` varchar(10) NOT NULL,
  `nombre` text NOT NULL,
  `valor` int(6) NOT NULL,
  `SAM` int(5) NOT NULL,
  `operarios` int(5) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `SAM` (`SAM`),
  KEY `operarios` (`operarios`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sam`
--

DROP TABLE IF EXISTS `sam`;
CREATE TABLE IF NOT EXISTS `sam` (
  `id` int(5) NOT NULL AUTO_INCREMENT,
  `codigo` varchar(10) NOT NULL,
  `operacion` text NOT NULL,
  `tiempo` time NOT NULL,
  `valor_operacion` int(5) NOT NULL,
  `maquina` int(5) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `maquina` (`maquina`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `jefe_produccion`
--
ALTER TABLE `jefe_produccion`
  ADD CONSTRAINT `jefe_produccion_ibfk_1` FOREIGN KEY (`id`) REFERENCES `clientes` (`jefe_produccion`) ON DELETE CASCADE;

--
-- Filtros para la tabla `maquina`
--
ALTER TABLE `maquina`
  ADD CONSTRAINT `maquina_ibfk_1` FOREIGN KEY (`id`) REFERENCES `sam` (`maquina`) ON DELETE CASCADE;

--
-- Filtros para la tabla `operarios`
--
ALTER TABLE `operarios`
  ADD CONSTRAINT `operarios_ibfk_1` FOREIGN KEY (`id`) REFERENCES `referencia` (`operarios`) ON DELETE CASCADE;

--
-- Filtros para la tabla `referencia`
--
ALTER TABLE `referencia`
  ADD CONSTRAINT `referencia_ibfk_1` FOREIGN KEY (`id`) REFERENCES `jefe_produccion` (`referencia`) ON DELETE CASCADE;

--
-- Filtros para la tabla `sam`
--
ALTER TABLE `sam`
  ADD CONSTRAINT `sam_ibfk_1` FOREIGN KEY (`id`) REFERENCES `referencia` (`SAM`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
