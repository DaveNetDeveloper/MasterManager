-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 22-04-2018 a las 02:11:29
-- Versión del servidor: 10.1.16-MariaDB
-- Versión de PHP: 5.6.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `qsg265`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `category`
--

CREATE TABLE `category` (
  `id` int(11) NOT NULL,
  `name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `slug` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `description` varchar(1000) COLLATE utf8_unicode_ci DEFAULT NULL,
  `weight` int(11) NOT NULL,
  `created` datetime NOT NULL,
  `updated` datetime NOT NULL,
  `discr` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `category`
--

INSERT INTO `category` (`id`, `name`, `slug`, `description`, `weight`, `created`, `updated`, `discr`) VALUES
(1, 'Examenes', 'examenes', NULL, 10, '2013-05-02 12:40:51', '2013-05-02 12:40:51', 'product-category');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `center`
--

CREATE TABLE `center` (
  `id` int(11) NOT NULL,
  `name_code` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `slug` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `description_code` varchar(1000) COLLATE utf8_unicode_ci DEFAULT NULL,
  `created` datetime NOT NULL,
  `updated` datetime NOT NULL,
  `weight` int(11) NOT NULL,
  `address` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `cp` varchar(10) COLLATE utf8_unicode_ci DEFAULT NULL,
  `city` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `infowindow_code` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `center`
--

INSERT INTO `center` (`id`, `name_code`, `slug`, `description_code`, `created`, `updated`, `weight`, `address`, `cp`, `city`, `infowindow_code`) VALUES
(1, 'CENTER_NAME_1', 'puerto', 'CENTER_DESCRIPTION_1', '2013-05-02 13:30:26', '2013-07-19 11:28:48', 0, 'Moll de Xaloc', '08005', 'Barcelona', 'CENTER_INFOWINDOW_1'),
(2, 'CENTER_NAME_2', 'escuela', 'CENTER_DESCRIPTION_2', '2013-05-02 13:30:56', '2013-07-19 11:28:48', 0, 'Carrer de Santaló, 134', '08021', 'Barcelona', 'CENTER_INFOWINDOW_2'),
(3, 'CENTER_NAME_3', 'puerto-tarragona', 'CENTER_DESCRIPTION_3', '2013-05-02 13:31:16', '2015-06-14 00:49:19', 0, 'N-241', '43006', 'Tarragona', 'CENTER_INFOWINDOW_3');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contact`
--

CREATE TABLE `contact` (
  `id` int(11) NOT NULL,
  `name` varchar(245) COLLATE utf8_unicode_ci NOT NULL,
  `subject` varchar(245) COLLATE utf8_unicode_ci DEFAULT NULL,
  `email` varchar(245) COLLATE utf8_unicode_ci NOT NULL,
  `phone` varchar(245) COLLATE utf8_unicode_ci DEFAULT NULL,
  `body` longtext COLLATE utf8_unicode_ci NOT NULL,
  `TEXT_CODE` varchar(100) COLLATE utf8_unicode_ci DEFAULT NULL,
  `created` datetime NOT NULL,
  `updated` datetime DEFAULT NULL,
  `isNew` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `contact`
--

INSERT INTO `contact` (`id`, `name`, `subject`, `email`, `phone`, `body`, `TEXT_CODE`, `created`, `updated`, `isNew`) VALUES
(19, 'Alejandro Quesada Vázquez', NULL, 'jandro.quesada@gmail.com', '665015068', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_19', '2013-08-11 11:27:28', '2013-08-11 11:27:28', 0),
(22, 'Maximiliano Mali', NULL, 'maximali@hotmail.es', '625566513', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_22', '2013-08-12 16:51:51', '2013-08-12 16:51:51', 0),
(23, 'cristina alonso', NULL, 'alonsopodence@hotmail.com', '625760606', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Octubre en el centro Escuela', 'USER_CONTACT_23', '2013-08-12 23:00:02', '2013-08-12 23:00:02', 0),
(28, 'Rubén Martínez', NULL, 'frogman1024@gmail.com', '600665125', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Septiembre en el centro Escuela\r\n\r\nTambién la duración del mismo.\r\n\r\nMuchas gracias.', 'USER_CONTACT_28', '2013-08-15 14:35:38', '2013-08-15 14:35:38', 0),
(29, 'odurich@hotmail.com', NULL, 'Oriol Durich', NULL, 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_29', '2013-08-16 12:35:45', '2013-08-16 12:35:45', 0),
(30, 'SONIA LOPEZ', NULL, 'lopsonic@hotmail.com', '658976110', 'Buena tardes, estaba interesada en el curso para obtener el PER que haréis el 16 de setiembre, martes y jueves. Me gustaría saber el precio de las clases presenciales y el precio de las practicas y lo que incluye.\r\nMuchas gracias.', 'USER_CONTACT_30', '2013-08-18 19:20:11', '2013-08-18 19:20:11', 0),
(31, 'POL JAQUET POUS', NULL, 'pol.jaquet@gmail.com', '609788161', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_31', '2013-08-19 13:25:18', '2013-08-19 13:25:18', 0),
(32, 'María Velasco Figueras', NULL, 'mariavelascofigueras@gmail.com', '661289571', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_32', '2013-08-19 13:38:27', '2013-08-19 13:38:27', 0),
(33, 'Ramon Duran', NULL, 'rdmiro@hotmail.com', '664851951', 'Hola,\r\nRecientemente me examine de teoria de patron de yate aprovando el examen. Estoy interesado en un centro donde poder realizar las prácticas de radio y motor.\r\nMe pueden informar de disponibilidad y precios?\r\nActualmente tengo el PER de motor y vela.\r\nMuchas gracias.\r\nRamon Duran', 'USER_CONTACT_33', '2013-08-19 21:29:06', '2013-08-19 21:29:06', 0),
(34, 'Jose', NULL, 'ringos_666@hotmail.com', '652419559', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela.\r\nMe gustaria saber el precio con todos los gastos de examen y practicas de vela incluidas, y la direccion donde se impartira el curso teorico, gracias.', 'USER_CONTACT_34', '2013-08-20 01:39:06', '2013-08-20 01:39:06', 0),
(36, 'Eduard Castro Capafons', NULL, 'eduardcc90@gmail.com', '617419330', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela.\r\nInformación sobre precios por favor.', 'USER_CONTACT_36', '2013-08-21 01:24:55', '2013-08-21 01:24:55', 0),
(37, 'Miguel Garcia Saiz', NULL, 'mgsaiz@hotmail.com', '636715000', 'Me gustaria informarme sobre el curso teorico de Capitán de Yate (CY) que inicia el dia 2 de Noviembre en el centro Escuela', 'USER_CONTACT_37', '2013-08-22 14:52:56', '2013-08-22 14:52:56', 0),
(38, 'isaac macia', NULL, 'isaac_882@hotmail.com', NULL, 'Una pregunta yo soi de igualada y me gustaria saber cuando se tarda en sacarse el carnet de embarcaciones de recreo', 'USER_CONTACT_38', '2013-08-23 12:54:02', '2013-08-23 12:54:02', 0),
(39, 'CRISTINA DURAN', NULL, 'cristivanesonia@hotmail.com', '686526477', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Noviembre en el centro Escuela', 'USER_CONTACT_39', '2013-08-24 20:31:40', '2013-08-24 20:31:40', 0),
(40, 'Gustavo Arnal', NULL, 'arnalga@yahoo.com', '+41797411272', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_40', '2013-08-24 23:34:04', '2013-08-24 23:34:04', 0),
(41, 'Edgar Gueto de la Rosa', NULL, 'edgar.gueto@gmail.com', '635115338', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Octubre en el centro Escuela.\r\n\r\nHe visto que en la web el PER tiene un precio, pero este precio incluye las clases teóricas y prácticas? \r\n¿Y cuál sería el horario tanto de teórica como de prácticas?\r\nGracias!', 'USER_CONTACT_41', '2013-08-25 21:02:15', '2013-08-25 21:02:15', 0),
(42, 'Carles Amatller Xampeny', NULL, 'carles@skema.cat', '637516999', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_42', '2013-08-25 23:05:58', '2013-08-25 23:05:58', 0),
(43, 'Carles Amatller Xampeny', NULL, 'carles@skema.cat', '637516999', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Octubre en el centro Escuela', 'USER_CONTACT_43', '2013-08-25 23:07:12', '2013-08-25 23:07:12', 0),
(44, 'Facundo Simons', NULL, 'facundo.simons@gmail.com', '644463228', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela. Precio total, incluyendo las prácticas de radio, motor y vela!\r\n\r\nGracias', 'USER_CONTACT_44', '2013-08-26 00:37:42', '2013-08-26 00:37:42', 0),
(45, 'Xavier Rabaseda Bertran', NULL, 'xavi.rabaseda@gmail.com', '660835026', 'Bon dia,\r\n\r\nVaig venir farà un mes demanant informació per fer el curs PER a partir de setembre. He tingut canvis d''última hora de cara al meu futur i no seré a Barcelona l''any vinent, així que tampoc podré fer el curs. \r\n\r\nVaig deixar 10€ com a senyal per el llibre d''apunts, m''agradaria poder fer el curs abans de l''estiu que ve, així que si m''ho podeu guardar, depenent de cuan acabi la temporada, em tornaria a posar en contacte amb vostés per poder fer el curs.\r\n\r\nMoltes gràcies, i espero notícies seves.\r\n\r\nXavi Rabaseda', 'USER_CONTACT_45', '2013-08-26 10:29:12', '2013-08-26 10:29:12', 0),
(46, 'cristian marc huerta verges', NULL, 'chuertav@oc.edu', '669866081', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_46', '2013-08-26 13:57:34', '2013-08-26 13:57:34', 0),
(47, 'cristian marc huerta verges', NULL, 'chuertav@uoc.edu', '669866081', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Octubre en el centro Escuela', 'USER_CONTACT_47', '2013-08-26 13:58:34', '2013-08-26 13:58:34', 0),
(48, 'Mercedes lopez', NULL, 'gaby20italia@hotmail.com', '635683352', 'Hola. Hace 10 años obtuve la titulación del PER, ahora que tengo que renovar la documentación desearía realizar las `practicas de vela.\r\n\r\nLes agradezco la información de horarios , en Septiembre, y precios de las practicas y papeleo.\r\n\r\nSaludos , Att. Mercedes', 'USER_CONTACT_48', '2013-08-26 16:42:57', '2013-08-26 16:42:57', 0),
(49, 'david molina', NULL, 'david.molinarosdevall@gmail.com', '603457941', 'Me gustaria recibir la informacion necesaria para apuntarme al PER o PNB.', 'USER_CONTACT_49', '2013-08-26 16:48:51', '2013-08-26 16:48:51', 0),
(50, 'Carla Rosich Guerin', NULL, 'rosichcarla@gmail.com', '667474551', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_50', '2013-08-27 12:02:39', '2013-08-27 12:02:39', 0),
(51, 'MARTA TRIAS SAEZ', NULL, 'mtriassaez@gmail.com', '678092421', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Octubre en el centro Escuela', 'USER_CONTACT_51', '2013-08-27 13:14:52', '2013-08-27 13:14:52', 0),
(52, 'mireia', NULL, 'mireiamellado@hotmail.com', NULL, 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_52', '2013-08-28 15:10:23', '2013-08-28 15:10:23', 0),
(53, 'Carme Prieto Soria', NULL, 'gorgues_7@hotmail.com', '615590276', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de septiembre en el centro Escuela', 'USER_CONTACT_53', '2013-08-29 11:29:05', '2013-08-29 11:29:05', 0),
(54, 'jaume', NULL, 'solanelles', '660493381', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de setiembre en el centro Escuela asi como los precios.', 'USER_CONTACT_54', '2013-08-29 15:11:52', '2013-08-29 15:11:52', 0),
(55, 'Vicenç Riera', NULL, 'vicen10@gmail.com', '669303280', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Octubre en el centro Escuela', 'USER_CONTACT_55', '2013-08-29 17:39:01', '2013-08-29 17:39:01', 0),
(56, 'Julián Guardado Rubio', NULL, 'julian.guardado@gmail.com', '607308262', 'Buenas tardes, estoy interesado en realizar un curso de PER, me gustaría información sobre dicho curso.', 'USER_CONTACT_56', '2013-08-29 18:44:18', '2013-08-29 18:44:18', 0),
(57, 'Josep llopis', NULL, 'josepllopis75@gmail.com', '665774837', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Octubre en el centro Escuela', 'USER_CONTACT_57', '2013-08-31 01:00:50', '2013-08-31 01:00:50', 0),
(58, 'caroline duchamp', NULL, 'duchamp.carolinema@gmail.com', '622463036', 'Buenos dias,\r\nEstaria interesada en conseguir el permiso PNB. Ya ha visto la informacion en su web pero faltaria el presupuesto exacto y tambien queria saber los plazos/horarios.\r\ngracias\r\ncaroline', 'USER_CONTACT_58', '2013-08-31 14:03:32', '2013-08-31 14:03:32', 0),
(59, 'sergio fernandez ochoa', NULL, 'sergio.fernandez@frigicoll.es', '680408983', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_59', '2013-09-01 04:08:10', '2013-09-01 04:08:10', 0),
(60, 'EVA ALEJANDRE HERNANDEZ', NULL, 'evatae@hotmail.com', '649509922', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 18 de Diciembre en el centro Escuela', 'USER_CONTACT_60', '2013-09-01 11:43:30', '2013-09-01 11:43:30', 0),
(61, 'Marc Carreras', NULL, 'marc.carreras@gmail.com', '670028085', 'Me gustaria informarme sobre el curso teorico de  (PY) que inicia el dia 17 de Octubre en el centro', 'USER_CONTACT_61', '2013-09-02 01:02:36', '2013-09-02 01:02:36', 0),
(62, 'Alfonso Cuesta Serrano', NULL, 'alf961@msn.com', '34-607330375', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_62', '2013-09-02 08:51:35', '2013-09-02 08:51:35', 0),
(63, 'joan mas', NULL, 'joanmas83@hotmail.com', '636627220', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de octubre en el centro Escuela', 'USER_CONTACT_63', '2013-09-02 10:55:15', '2013-09-02 10:55:15', 0),
(64, 'aurora mateo', NULL, 'sognia1@gmail.com', '615296148', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_64', '2013-09-02 12:28:04', '2013-09-02 12:28:04', 0),
(65, 'Xavier Roig', NULL, 'xavier.roig@pepsico.com', 'PER', 'Estaba interesado en tener información de precios y horarios para la consecución del PER.\r\nNo tengo demasiada disponibilidad horaria por lo que estoy interesado en alguna propuesta con las horas condensadas en pocos dias.\r\nNo tengo ningun conocimiento náutico previo.\r\nMi nombre es Xavier Roig, mi email es xavier.roig@pepsico.com y mi móvil es el 618768537', 'USER_CONTACT_65', '2013-09-02 16:14:09', '2013-09-02 16:14:09', 0),
(66, 'Marta', NULL, 'marta.s0511@gmail.com', '615296148', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_66', '2013-09-03 10:26:46', '2013-09-03 10:26:46', 0),
(67, 'Esther Gracia', NULL, 'conchi.sp@hotmail.es', '687 506 206', 'Me gustaría informarme sobre el curso teórico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de octubre en el centro Escuela C/ Santalo', 'USER_CONTACT_67', '2013-09-03 14:45:33', '2013-09-03 14:45:33', 0),
(68, 'Hector Escriche', NULL, 'hector@webscoming.com', '615296074', 'Prova formulari de contacte.', 'USER_CONTACT_68', '2013-09-03 16:31:43', '2013-09-03 16:31:43', 0),
(69, 'ALEJANDRO CAVALIERE', NULL, 'ALEXCAVALIERE@LIVE.COM', '618734117', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_69', '2013-09-03 17:08:42', '2013-09-03 17:08:42', 0),
(70, 'victor gil martinez', NULL, 'gilgpsi@prodigy.net.mx', '55-53 60 67 33', 'Hola Aurora,buenas tardes\r\nHoy recibi tu correo con los datos del curso,lamentablemente como se casa mi hija en octubre no me seria posible tomarlo en esta ocacion,pero tengo mucho interes en obtener la certificacion pertinente,y lo que realmente me interesa es tener los conocimientos necesarios para poder salir al mar con la mayor seguridad posible.\r\nindependientemente de ello,tengo varias dudas.\r\n1.-no hay limite de edad? (tengo 65 años)\r\n2.-tengo un velero RG de 20 pies y otro laguna de 26 pies con el que quiero llevar al mar,actualmente lo tengo en un lago (valle de bravo en el esado de mexico)\r\n3.-tengo que tomar el curso de embaraciones de motor nescesariamente?\r\n4.-cuanto tiempo dura el curso para poder obtener la certificacion?\r\n5.-si me podrian orientar de cuanto seria el costo total del curso y cuanto seria aprox. el costo de habitacion y comida durante el tiempo que dure la capacitacion y certificacion.\r\ngracias de antemano por tus atenciones\r\nvictor gil', 'USER_CONTACT_70', '2013-09-05 03:06:00', '2013-09-05 03:06:00', 0),
(71, 'Jordi Farre Regue', NULL, 'jordi.regue@gmail.com', '629875071', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 18 de Noviembre en su escuela', 'USER_CONTACT_71', '2013-09-05 12:41:45', '2013-09-05 12:41:45', 0),
(72, 'Sonsoles', NULL, 'sonsuns@hotmail.com', NULL, 'Hola,\r\nQuiero informacion del Per, para sacarme el titulo en diciembre, vela y motor.\r\nMe interesa saber el precio, y saber dónde realizais las clases teóricas y prácticas.\r\nMuchaa gracias', 'USER_CONTACT_72', '2013-09-06 15:14:20', '2013-09-06 15:14:20', 0),
(73, 'Andrea Michaelsson', NULL, 'btoyglitch@yahoo.es', '644591935', 'me interesaría sobre el curso del pnb\r\ninscripción, fechas y precio\r\ngracias\r\na', 'USER_CONTACT_73', '2013-09-08 15:51:56', '2013-09-08 15:51:56', 0),
(74, 'Mélody Brechet', NULL, 'melodybrechet@hotmail.com', '609086321', 'Buenos días,\r\nQuería saber si proponen cursos de PN,  por la mañana, en las próximas semanas?\r\nDónde tienen lugar las clases teóricas? Cuántas clases habría en total?\r\nCuál es el precio y que incluye?\r\nGracias de antemano por su respuesta.\r\nUn saludo,\r\nMelody', 'USER_CONTACT_74', '2013-09-10 15:00:59', '2013-09-10 15:00:59', 0),
(75, 'Ivan Ballard', NULL, 'ivanballard.55@gmail.com', '0120120120', 'We can increase rankings of your website in search engines. Please reply back for more details.', 'USER_CONTACT_75', '2013-09-11 08:00:01', '2013-09-11 08:00:01', 0),
(76, 'Jose Alarcon', NULL, 'jfag3@msn.com', NULL, 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_76', '2013-09-12 20:48:24', '2013-09-12 20:48:24', 0),
(77, 'Raquel Espinosa', NULL, 'raquel.espinosa@punxes.es', '618688524', 'Estoy interesada en el curso de PER.\r\n\r\nGracias', 'USER_CONTACT_77', '2013-09-13 16:25:42', '2013-09-13 16:25:42', 0),
(78, 'Andreu Viure Sanchez', NULL, 'aviure@gmail.com', '609060155', 'Hola\r\nQuisiera saber si dais el curso para charter,\r\nGracias por vuestra atención\r\nAndreu', 'USER_CONTACT_78', '2013-09-14 21:06:00', '2013-09-14 21:06:00', 0),
(79, 'Alfonso Cuesta', NULL, 'alf961@msn.com', '607330375', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Octubre en el centro Escuela', 'USER_CONTACT_79', '2013-09-15 18:04:38', '2013-09-15 18:04:38', 0),
(80, 'roberto', NULL, 'robertosanchezcid@hotmail.com', '636540557', 'Me gustaria informarme sobre el curso teorico de Patrón de Yate (PY) que inicia el dia 17 de Octubre en el centro Escuela', 'USER_CONTACT_80', '2013-09-16 00:25:40', '2013-09-16 00:25:40', 0),
(81, 'jonatan Collado', NULL, 'jonatan.collado@grupoams.es', '638744523', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Noviembre en el centro Escuela', 'USER_CONTACT_81', '2013-09-16 16:30:11', '2013-09-16 16:30:11', 0),
(82, 'RUTH HUETE', NULL, 'ruthuete@yahoo.es', '933366481', 'Buenos días,\r\n\r\nLes agradecería me pudieran informar sobre el precio de la matricula para el curso de PER en su escuela, ya que me interesaría poder regalarle a mi hermana la inscripción al curso para su cumpleaños.\r\n\r\nMuchas gracias!!', 'USER_CONTACT_82', '2013-09-18 12:41:08', '2013-09-18 12:41:08', 0),
(83, 'Ricardo', NULL, 'g_richi00@hotmail.com', '651132626', 'Me gustaria informarme sobre el curso teorico de Patrón de Navegación Básica (PNB) que inicia el dia 23 de Septiembre en el centro Escuela', 'USER_CONTACT_83', '2013-09-18 12:41:56', '2013-09-18 12:41:56', 0),
(84, 'Xavi', NULL, 'xbosch@dissinfo.com', '637771802', 'Prueba', 'USER_CONTACT_84', '2013-09-19 13:48:59', '2013-09-19 13:48:59', 0),
(85, 'PERE LLIBRE', NULL, 'pere@llibre.org', '617732310', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 22 de Noviembre en el centro Escuela', 'USER_CONTACT_85', '2013-09-19 16:56:21', '2013-09-19 16:56:21', 0),
(86, 'anna maria sala andres', NULL, 'telefono 629594756', 'asala@cortes-abogados.com', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 22 de Noviembre en el centro Escuela', 'USER_CONTACT_86', '2013-09-20 11:23:58', '2013-09-20 11:23:58', 0),
(87, 'pedro moll', NULL, 'asisp2013@hotmail.com', '600388343', 'Deseamos contrato colaboración con usted para que nuestros asociados en España  que tengan nuestra tarjeta de  descuentos tengan descuento en su empresa ,tendrían publicidad gratuita en nuestros blog y redes sociales,como en la revista sin coste para ustedes ,\r\ngracias\r\npedro moll\r\nasociacion independiente sector profesional 2013\r\nasisp2013@hotmail.com\r\ntelf 600388343', 'USER_CONTACT_87', '2013-09-25 13:01:42', '2013-09-25 13:01:42', 0),
(88, 'JULIAN FRANCISCO PLASENCIA CABELLO', NULL, 'jplasenciacabello@gmail.com', '661814234', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Diciembre en el centro Puerto', 'USER_CONTACT_88', '2013-10-03 12:19:00', '2013-10-03 12:19:00', 0),
(89, 'Gabriel Costa', NULL, 'gcgcpl1991@gmail.com', '665019893', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Noviembre en el centro Escuela.\r\n\r\nEstoy interesado en hacer el pack de vela y motor.\r\n\r\nGracias por su atención.', 'USER_CONTACT_89', '2013-10-03 12:23:32', '2013-10-03 12:23:32', 0),
(90, 'PASCUAL VIDAL FERNANDEZ', NULL, 'pvidal@intervencionlegal.com', '609855555', 'Soy Patrón de Embarcaciones Deportivas de Motor de 2ª clase.\r\nTengo el título desde 1991, pero he perdido el carnet.\r\nEse título sigue existiendo o hay que convalidarlo con el PER?. De ser así, les ruego me indiquen que es lo que hay que hacer\r\n\r\nAtte.', 'USER_CONTACT_90', '2013-10-03 18:35:51', '2013-10-03 18:35:51', 0),
(91, 'Daniel Mató', NULL, 'dmato10@hotmail.com', NULL, 'Hola. Quería saber si hay flexibilidad de horarios para realizar las prácticas del PER (motor y vela), ya que tengo una programación laboral bastante complicada. Gracias. Saludos.', 'USER_CONTACT_91', '2013-10-04 19:35:40', '2013-10-04 19:35:40', 0),
(92, 'David López', NULL, 'davidlm0073@hotmail.com', '671222838', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Noviembre en el centro Escuela  Náutica Santaló .', 'USER_CONTACT_92', '2013-10-06 13:33:08', '2013-10-06 13:33:08', 0),
(93, 'daniel', NULL, 'daniel.lanuza@gmail.com', '646650250', 'Hola\r\n\r\nMe interesa el PER para poder manejar un velero.\r\nQuisiera saber cuanto cuesta, todo incluido.\r\nPodrían indicarme también como se organizan las clases y las practicas?\r\nGracias\r\nDaniel.', 'USER_CONTACT_93', '2013-10-06 17:18:47', '2013-10-06 17:18:47', 0),
(94, 'Gisel·la', NULL, 'gisella@alicia.cat', '680607182', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 5 de Noviembre en el centro Escuela', 'USER_CONTACT_94', '2013-10-07 15:22:10', '2013-10-07 15:22:10', 0),
(95, 'Forlidar Macias', NULL, 'forlidar@forlidar.com', '652456593', 'Buenas tardes,\r\nEstoy buscando información sobre cursos para obtener un permiso de navegación. \r\nEstoy buscando apuntar a mi padre, que lleva tiempo queriendo sacarse un permiso, pero no lo ha hecho aún. \r\nQuería hacerlo como regalo de Navidad. \r\nObservo que no tienen fechas de los próximos cursos de PNB. Agradecería también me informarais sobre posibles ofertas o descuentos.\r\n\r\nSolicito si me podíais proporcionar información más detalladas y qué formas de pago disponeis.\r\n\r\nGracias,\r\n\r\nForlidar Macias', 'USER_CONTACT_95', '2013-10-07 15:35:07', '2013-10-07 15:35:07', 0),
(96, 'Jordi Munner', NULL, 'jordimunner@gmail.com', '607.378.359', 'Hola,\r\nPodriem enviar-me el pressupost i el programa per realitzar el PER a Barcelona.\r\nAtentament, \r\nJordi', 'USER_CONTACT_96', '2013-10-08 20:53:20', '2013-10-08 20:53:20', 0),
(97, 'Ana Estévez Vega', NULL, 'anaestevezvega@gmail.com', '630504979', 'Me gustaría informarme sobre el curso teórico del PER que empieza el 16 de Septiembre. Los horarios que mejor me encajan son:\r\n\r\n- Lunes y Miércoles (11h-13h)\r\n- Lunes y Miércoles (19:30h-22h)\r\n\r\nGracias,\r\nAna', 'USER_CONTACT_97', '2013-10-10 13:14:19', '2013-10-10 13:14:19', 0),
(98, 'Manuel Reyes', NULL, 'reyes22274@gmail.com', NULL, 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Noviembre en el centro Escuela', 'USER_CONTACT_98', '2013-10-13 14:01:05', '2013-10-13 14:01:05', 0),
(99, 'Gloria Molins', NULL, 'gmolins7@gmail.com', '626796005', 'Hola!\r\n\r\nMe gustaría tener información sobre el PER:\r\n\r\nPrecios del curso de fin de semana e información\r\nDel curso online\r\nY precios del examen \r\n\r\nGracias!\r\n\r\nG.', 'USER_CONTACT_99', '2013-10-15 09:39:28', '2013-10-15 09:39:28', 0),
(100, 'Núria', NULL, 'Sala', 'salanuria@hotmail.com', 'Bona tarda,\r\n\r\nM''agradaria tenir informació sobre el PER. La durada del curs i preu.\r\nJo podria començar les classes a partir del novembre si és que hi ha disponibilitat i tindria disponibles els dilluns, dimarts i dimecres a la tarda a partir de les 18:30h. Si us plau em podeu enviar més informació per email? \r\nsalanuria@hotmail.com\r\nMoltes gràcies.\r\nNúria', 'USER_CONTACT_100', '2013-10-16 16:08:31', '2013-10-16 16:08:31', 0),
(101, 'Núria', NULL, 'Sala', 'salanuria@hotmail.com', 'Bona tarda,\r\n\r\nM''agradaria tenir informació sobre el PER. La durada del curs i preu.\r\nJo podria començar les classes a partir del novembre si és que hi ha disponibilitat i tindria disponibles els dilluns, dimarts i dimecres a la tarda a partir de les 18:30h. Si us plau em podeu enviar més informació per email? \r\nsalanuria@hotmail.com\r\nMoltes gràcies.\r\nNúria', 'USER_CONTACT_101', '2013-10-16 16:08:31', '2013-10-16 16:08:31', 0),
(102, 'Núria', NULL, 'Sala', 'salanuria@hotmail.com', 'Bona tarda,\r\n\r\nM''agradaria tenir informació sobre el PER. La durada del curs i preu.\r\nJo podria començar les classes a partir del novembre si és que hi ha disponibilitat i tindria disponibles els dilluns, dimarts i dimecres a la tarda a partir de les 18:30h. Si us plau em podeu enviar més informació per email? \r\nsalanuria@hotmail.com\r\nMoltes gràcies.\r\nNúria', 'USER_CONTACT_102', '2013-10-16 16:08:32', '2013-10-16 16:08:32', 0),
(103, 'Núria', NULL, 'Sala', 'salanuria@hotmail.com', 'Bona tarda,\r\n\r\nM''agradaria tenir informació sobre el PER. La durada del curs i preu.\r\nJo podria començar les classes a partir del novembre si és que hi ha disponibilitat i tindria disponibles els dilluns, dimarts i dimecres a la tarda a partir de les 18:30h. Si us plau em podeu enviar més informació per email? \r\nsalanuria@hotmail.com\r\nMoltes gràcies.', 'USER_CONTACT_103', '2013-10-16 16:09:08', '2013-10-16 16:09:08', 0),
(104, 'Núria', NULL, 'Sala', 'salanuria@hotmail.com', 'Bona tarda,\r\n\r\nM''agradaria tenir informació sobre el PER. La durada del curs i preu.\r\nJo podria començar les classes a partir del novembre si és que hi ha disponibilitat i tindria disponibles els dilluns, dimarts i dimecres a la tarda a partir de les 18:30h. Si us plau em podeu enviar més informació per email? \r\nsalanuria@hotmail.com\r\nMoltes gràcies.', 'USER_CONTACT_104', '2013-10-16 16:09:08', '2013-10-16 16:09:08', 0),
(105, 'Núria', NULL, 'Sala', 'salanuria@hotmail.com', 'Bona tarda,\r\n\r\nM''agradaria tenir informació sobre el PER. La durada del curs i preu.\r\nJo podria començar les classes a partir del novembre si és que hi ha disponibilitat i tindria disponibles els dilluns, dimarts i dimecres a la tarda a partir de les 18:30h. Si us plau em podeu enviar més informació per email? \r\nsalanuria@hotmail.com\r\nMoltes gràcies.', 'USER_CONTACT_105', '2013-10-16 16:09:09', '2013-10-16 16:09:09', 0),
(106, 'carles Bandres Perez', NULL, 'carlesbandres@hotmail.com', '670606439', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 18 de Diciembre en el centro Escuela', 'USER_CONTACT_106', '2013-10-18 23:22:08', '2013-10-18 23:22:08', 0),
(107, 'Antonio Rigol', NULL, 'antrigol@yahoo.es', '649242331', 'Desearía informació de precios y fechas para realizar las prácticas de motor y radio para patrón de yate. Gracias.', 'USER_CONTACT_107', '2013-10-20 11:00:07', '2013-10-20 11:00:07', 0),
(108, 'Raul Escalona Perea', NULL, 'ra.ep@hotmail.es', '658495329', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 9 de Diciembre en el centro Escuela', 'USER_CONTACT_108', '2013-10-21 21:06:01', '2013-10-21 21:06:01', 0),
(109, 'Alex Roqué', NULL, 'alexx.roque@gmail.com', '666055984', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 18 de Diciembre en el centro Escuela', 'USER_CONTACT_109', '2013-10-23 00:43:44', '2013-10-23 00:43:44', 0),
(110, 'Cesar Castel', NULL, 'cesar.castel@adecco.com', '607215125', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 5 de Noviembre en el centro Escuela', 'USER_CONTACT_110', '2013-10-23 10:34:14', '2013-10-23 10:34:14', 0),
(111, 'Sara Fuertes Vila', NULL, 'sfv29@hotmail.com', '650146379', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 9 de Noviembre en el centro Escuela', 'USER_CONTACT_111', '2013-10-23 12:10:28', '2013-10-23 12:10:28', 0),
(112, 'Alba Verges Peña', NULL, 'alba.vergesp@gmail.com', '658433016', 'Buenas tardes, estoy interesada en obtener el PER y solicito información sobre precio, horarios e inicio del próximo curso. \r\n\r\nMuchas gracias, un saludo', 'USER_CONTACT_112', '2013-10-28 17:26:46', '2013-10-28 17:26:46', 0),
(113, 'Luis casanovas', NULL, 'lcasanovasr@hotmail.com', '690693390', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 18 de Noviembre en el centro Escuela', 'USER_CONTACT_113', '2013-10-28 21:42:33', '2013-10-28 21:42:33', 0),
(114, 'Pau Font', NULL, 'pfont@mariabarcelona.com', '607414054', 'Hola,\r\nVoldria saber quan iniciaran un curs de PER en horari de 14:00 a 16:00 hores i quin preu té (teoria+examen+pràctiques). Moltes gràcies', 'USER_CONTACT_114', '2013-10-29 12:36:52', '2013-10-29 12:36:52', 0),
(115, 'DAVID COLPRIM GALCERAN', NULL, 'hyper9sup@terra.com', '639557228', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 9 de Noviembre en el centro Escuela', 'USER_CONTACT_115', '2013-10-29 15:52:37', '2013-10-29 15:52:37', 0),
(116, 'florencia martinez', NULL, 'flormartinezrojas@gmail.com', '692126627', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 9 de Noviembre en el centro Escuela', 'USER_CONTACT_116', '2013-10-31 09:52:57', '2013-10-31 09:52:57', 0),
(117, 'Guillem', NULL, 'santiveripuig@gmail.com', '652220137', 'me gustaría saber el precio aproximado del curso para la obtención del titulo PER, gracias', 'USER_CONTACT_117', '2013-11-06 11:53:52', '2013-11-06 11:53:52', 0),
(118, 'Sergi Aldea', NULL, 'sg.aldea@gmail.com', '686440662', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 18 de Noviembre en el centro Escuela.\r\nMe gustaría disponer del horario y días del curso, el precio, y el posible horario de las prácticas.\r\n\r\nGracias', 'USER_CONTACT_118', '2013-11-06 12:24:57', '2013-11-06 12:24:57', 0),
(119, 'Lola bou', NULL, 'lolabou@me.com', NULL, 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 18 de Noviembre en el centro Escuela', 'USER_CONTACT_119', '2013-11-09 09:32:05', '2013-11-09 09:32:05', 0),
(120, 'Greta Brostrom', NULL, 'smulangret@gmail.com', '603817366', 'Hola buenas noches! Les escribo para preguntarles cual es la formacion básica para embarcar como marinera en un velero. Y si dais estos cursos cual es el precio. Muchas gracias!', 'USER_CONTACT_120', '2013-11-13 00:15:48', '2013-11-13 00:15:48', 0),
(121, 'arturo llopis', NULL, 'arturo.llopis@gmail.com', '934872336', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Noviembre en el centro Escuela. Quiero saber coste del pack completo (estoy intersado motor y vela, teoría y prácticas de radio y navegación) y dias de duración del teórico (imagino que es intensivo). Contesten por email, lo prefiero. gracias', 'USER_CONTACT_121', '2013-11-21 12:18:34', '2013-11-21 12:18:34', 0),
(122, 'Julián Fernández', NULL, 'juli_ferlo_90@hotmail.com', '648155063', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 13 de Enero en el centro Escuela', 'USER_CONTACT_122', '2013-12-10 21:55:20', '2013-12-10 21:55:20', 0),
(123, 'Mary', NULL, 'mary@test.com', '123456789', 'a', 'USER_CONTACT_123', '2013-12-11 23:16:56', '2013-12-11 23:16:56', 0),
(124, 'German Arnal', NULL, 'man@302studio.com', '659752853', 'Hola, tramitáis renovaciónes del PER?\r\nGracias.', 'USER_CONTACT_124', '2013-12-15 21:35:04', '2013-12-15 21:35:04', 0),
(125, 'Mary2', NULL, 'mary@test.com', '93744 11 11', 'test', 'USER_CONTACT_125', '2013-12-19 19:04:47', '2013-12-19 19:04:47', 0),
(126, 'jose carlos caracuel', NULL, 'giusi22@gmail.com', '650062830', 'quisiera información para un regalo de navidad', 'USER_CONTACT_126', '2013-12-20 09:49:26', '2013-12-20 09:49:26', 0),
(127, 'Guillermo Coll', NULL, 'guillermocoll84@gmail.com', '629756886', 'Buenos dias.\r\n\r\nEstoy interesado en realizar las practicas de PER (radiocomunicaciones, motor y vela)\r\n\r\nTenéis alguna oferta para las 3??\r\n\r\nSolicito presupuesto por favor.\r\n\r\nGracias.', 'USER_CONTACT_127', '2013-12-20 13:29:08', '2013-12-20 13:29:08', 0),
(128, 'Elena Privalova', NULL, 'ofrakin@mail.ru', '+34602416643', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 13 de Enero en el centro Escuela', 'USER_CONTACT_128', '2013-12-20 21:28:51', '2013-12-20 21:28:51', 0),
(129, 'Javier Chordá', NULL, 'xchorda@gmail.com', '626499208', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_129', '2013-12-23 11:12:05', '2013-12-23 11:12:05', 0),
(130, 'Jordi Albert Ros', NULL, 'jordi.albert.ros@gmail.com', '607975180', 'Me gustaría informarme sobre el curso teórico de Patrón de Embarcaciones de Recreo (PER) que inicia el día 13 de Enero en el centro Escuela. En concreto tengo las siguientes dudas:\r\n¿Cuántas horas de teórica presencial se imparten? y qué días?\r\n¿Cuántas horas de práctica de motor incluye el curso?\r\n¿Cuántas horas de practica de vela incluye el curso?\r\n¿Cuántas horas de práctica de radio incluye el curso? \r\n¿en el precio está todo incluido (Expedición titulo, convocatoria examen, IVA, ...)? o ¿Hay algún gasto extra?\r\nMuchas gracias.', 'USER_CONTACT_130', '2013-12-25 19:44:56', '2013-12-25 19:44:56', 0),
(131, 'Gustavo Adolfo Coppié', NULL, 'gacoppie@gmail.com', '655885077', 'Buenas tardes,\r\nYo hice el curso del PER en vuestra escuela en enero de 2011, pero no aprobé cuando me presenté al examen.\r\nComo dejé las prácticas pagadas pero nunca llegué  a hacerlas quería saber si es posible que las haga ahora sin tener que volver a pagar.\r\n\r\nSaludos,', 'USER_CONTACT_131', '2013-12-27 17:26:04', '2013-12-27 17:26:04', 0),
(132, 'Orson van der Linden', NULL, 'Ontie@hotmail.com', '627842942', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 13 de Enero en el centro Escuela', 'USER_CONTACT_132', '2013-12-29 19:06:38', '2013-12-29 19:06:38', 0),
(133, 'Javier León', NULL, 'dr.j.leon@hotmail.com', NULL, 'Deseo saber el precio de las prácticas de motor y radio para patron de yate', 'USER_CONTACT_133', '2013-12-30 02:19:11', '2013-12-30 02:19:11', 0),
(134, 'xavier torra cots', NULL, 'xaviertorra36@gmail.com', '618257262', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 13 de Enero en el centro Escuela', 'USER_CONTACT_134', '2014-01-03 18:01:28', '2014-01-03 18:01:28', 0),
(135, 'Marga Fabra', NULL, 'marga.fabra@bucker.org', NULL, 'Hola m interessa l oferta pel PER.\r\nPrego contactin amb mi per horari propers cursos.\r\nGracies.\r\nSalutacions, MF', 'USER_CONTACT_135', '2014-01-04 01:09:22', '2014-01-04 01:09:22', 0),
(136, 'Malena Sabaté', NULL, 'malenasabate@hotmail.com', '618816033', 'Hola, \r\nMe faltan las pràcticas de radio para poder tener el título PER. Queria preguntar por el precio de la simulación, y he visto que ofreceis el servicio todas las tardes... tengo que pedir hora o puedo ir directamente?\r\n\r\nGracias!', 'USER_CONTACT_136', '2014-01-05 12:02:35', '2014-01-05 12:02:35', 0),
(137, 'Luis Castaneda', NULL, 'grupocastaneda@yahoo.com', '934343475', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 13 de Enero en el centro Escuela', 'USER_CONTACT_137', '2014-01-08 12:43:08', '2014-01-08 12:43:08', 0),
(138, 'LUIS CASANOVAS', NULL, 'LCASANOVASR@HOTMAIL.COM', NULL, 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 14 de Abril en el centro Escuela', 'USER_CONTACT_138', '2014-01-08 13:43:49', '2014-01-08 13:43:49', 0),
(139, 'Patricia Claret', NULL, 'patriciaclaretgodo@yahoo.com', '696451030', 'Buenos días :\r\nMe gustaría saber el horario de clases (principalmente con Beva ) para sacarme el PER  y las posibles fechas de examen.\r\nMuchas gracias,\r\nPatricia Claret', 'USER_CONTACT_139', '2014-01-10 09:21:20', '2014-01-10 09:21:20', 0),
(140, 'CharlesSkar', NULL, 'hettie.gallagher1@aol.com', '123456', '<img>http://i.imgur.com/rD8koPj.jpg</img> <a href=http://ordercheapestviagranow.com/#wsnrw>viagra online</a> - <a href=http://ordercheapestviagranow.com/#ehbdf >cheap viagra 50 mg</a> , http://ordercheapestviagranow.com/#aafmk viagra alternative', 'USER_CONTACT_140', '2014-01-11 02:40:51', '2014-01-11 02:40:51', 0),
(141, 'Natalia Muncunill', NULL, 'nataliamuncunill@hotmail.com', '617160408', 'Buenas tardes, \r\n\r\nEl pasado 21 de diciembre me presenté al PER por libré y lo he aprobado. \r\nEstoy buscando un centro para poder hacer las prácticas obligatorias y me gustaría conocer vuestros precios, tanto de motor como de vela y el horario de los siguientes cursillos prácticos.\r\n\r\nMuchas gracias, \r\n\r\nNatalia Muncunill', 'USER_CONTACT_141', '2014-01-11 13:52:35', '2014-01-11 13:52:35', 0),
(142, 'sergi', NULL, 'mivaser@hotmail.com', '685160107', 'Estaría interesado en realizar el curso PER, me gustaría que me dieran información detallada de todo el curso. Gracias', 'USER_CONTACT_142', '2014-01-14 22:47:12', '2014-01-14 22:47:12', 0),
(143, 'Felipe Vergés', NULL, 'felipverges@gmail.com', '657768333', 'Tengo intención de apuntarme al curso de capitán de yate este año. \r\n\r\nMe gustaría saber los precios que tenis en la actualidad y si puedo apuntarme, tengo la asignatura de Meteorología aprobada.\r\n\r\nMuchas gracias.', 'USER_CONTACT_143', '2014-01-17 10:03:14', '2014-01-17 10:03:14', 0),
(144, 'Juñ', NULL, 'iborraj@yahoo.es', NULL, 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 15 de Febrero en el centro Escuela', 'USER_CONTACT_144', '2014-01-19 15:35:42', '2014-01-19 15:35:42', 0),
(145, 'Juli Iborra', NULL, 'iborraj@yahoo.es', '680526942', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 15 de Febrero en el centro Escuela precios', 'USER_CONTACT_145', '2014-01-19 15:38:46', '2014-01-19 15:38:46', 0),
(146, 'ALEJANDRO PUIGGRÓS CORRONS', NULL, 'apuiggros.fibanc@gmail.com', '696694565', 'Ruego me den información para obtener el título PER. Requeriría duración del curso (horas y días necesarios) y precio.\r\n\r\nRuego me informen también si hay alguna oferta o algún descuento por la inscripción de más de una persona al mismo tiempo.\r\n\r\nGracias por su atención y un cordial saludo,', 'USER_CONTACT_146', '2014-01-22 00:15:50', '2014-01-22 00:15:50', 0),
(147, 'Víctor Sánchez Bonilla', NULL, 'svictor23@hotmail.com', '605323074', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 17 de Febrero en el centro Escuela. Y información referente a las practicas y todo lo necesario para adquirir el titulo y sus precios. Un saludo!', 'USER_CONTACT_147', '2014-01-22 12:48:29', '2014-01-22 12:48:29', 0),
(148, 'Marc Gordi', NULL, 'marcgm90@gmail.com', '639877421', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 29 de Enero en el centro Escuela', 'USER_CONTACT_148', '2014-01-22 13:19:38', '2014-01-22 13:19:38', 0),
(149, 'miquel novella', NULL, 'novella@icab.cat', '934883520', 'Me gustaria informarme sobre el curso teorico de Patrón de Yate (PY) que inicia el dia 9 de Enero en el centro Escuela\r\n\r\nMe falta solo navegación y las prácticas.', 'USER_CONTACT_149', '2014-01-24 13:04:29', '2014-01-24 13:04:29', 0),
(150, 'victor martinez', NULL, 'vittione@hotmail.es', '633271799', 'Me gustaria informarme sobre el curso teorico de Patrón de Navegación Básica (PNB) que inicia el dia 25 de Febrero en el centro Escuela', 'USER_CONTACT_150', '2014-01-28 20:04:55', '2014-01-28 20:04:55', 0),
(151, 'Lidia Tobar', NULL, 'lidiatobar@hotmail.com', '675342553', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 15 de Febrero en el centro Escuela', 'USER_CONTACT_151', '2014-01-30 14:20:48', '2014-01-30 14:20:48', 0),
(152, 'JOSE JESUS  AISA LAMBAN', NULL, 'jjaisa@hotmail.es', '649997244', 'Buenos dias:\r\nLes agracederia me informasen sobre las asignaturas de metoreologia,inglés y teoria del buque, que posibilidad habria\r\nde hacerlas por internet, aunque podria desplazarme alguna clase ya que  resido en Zaragoza, \r\nGracias y un cordial saludo.', 'USER_CONTACT_152', '2014-02-01 11:19:41', '2014-02-01 11:19:41', 0),
(153, 'Maria Jose Fernandez', NULL, 'mfersaba@gmail.com', '649844911', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 15 de Febrero en el centro Escuela', 'USER_CONTACT_153', '2014-02-02 11:28:14', '2014-02-02 11:28:14', 0),
(154, 'Andrea Sánchez', NULL, 'andrea3147@hotmail.com', '669062264', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 15 de Febrero en el centro Escuela', 'USER_CONTACT_154', '2014-02-03 10:55:56', '2014-02-03 10:55:56', 0),
(155, 'Clara Garí Ruiz de Villa', NULL, 'claragarirv@gmail.com', '680583053', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 29 de Enero en el centro Escuela', 'USER_CONTACT_155', '2014-02-03 11:07:13', '2014-02-03 11:07:13', 0),
(156, 'Victor Bergadà de Quadras', NULL, 'victorbergada@yahoo.es', '934068250', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 18 de Marzo en el centro Escuela', 'USER_CONTACT_156', '2014-02-03 19:05:53', '2014-02-03 19:05:53', 0),
(157, 'Ana Gregorio Arnau', NULL, 'anna.sacore@gmail.com', '679777121', 'Buenos días,\r\n\r\nMe gustaría que me informen por e-mail de los precios para el curso PER.\r\n\r\nEstoy pensando en regalarlo y me gustaría saber el coste\r\n\r\nGracias,\r\n\r\nAna', 'USER_CONTACT_157', '2014-02-05 09:24:36', '2014-02-05 09:24:36', 0),
(158, 'carles ripoll', NULL, 'ripi135@hotmail.com', '690087040', 'Buenos días, solicito información sobre el precio del PER y también saber si hay opción de hacerlo a distancia, por lo menos la teoria, ya que resido en la provincia de Lleida. Gracias', 'USER_CONTACT_158', '2014-02-09 03:45:52', '2014-02-09 03:45:52', 0),
(159, 'JOSE JESUS  AISA LAMBAN', NULL, 'jjaisa@otmail.es', '649997244', 'Buenos dias\r\nHe estado de viaje toda la semana y observo que no hemos tenido contacto, les agradeceria  me informasen sobre las asignaturas pendientes como les decia en mi anterior correo, para tomar una determinación.\r\nSaludos.', 'USER_CONTACT_159', '2014-02-10 12:34:18', '2014-02-10 12:34:18', 0),
(160, 'juan pablo martínez sánchez', NULL, 'jpmsarquitecto@gmail.com', '676414670', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 3 de Marzo en el centro Escuela', 'USER_CONTACT_160', '2014-02-11 10:18:31', '2014-02-11 10:18:31', 0),
(161, 'jose luis', NULL, 'joseluisalfonsocascante@gmail.com', '654784838', 'Estaría interesado en recibir información para obtener el PER, en horarios de tarde o fin de semana intensivo. Pueden contactar conmigo por mail, gracias y saludos,', 'USER_CONTACT_161', '2014-02-11 16:26:27', '2014-02-11 16:26:27', 0),
(162, 'paulo miranda', NULL, 'paulotercitanp@gmail.com', '973351834', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 15 de Febrero en el centro Escuela\r\n\r\nprecios ( con teorica, praticas motor,radio y examen con todas las tasas), forma de pago y horarios... a ser posible en fines de semana,\r\n\r\ngracias', 'USER_CONTACT_162', '2014-02-12 20:05:15', '2014-02-12 20:05:15', 0),
(163, 'John Wilson', NULL, 'johnw0178@gmail.com', '013-013-0130', 'Want more clients and customers? We will help them find you by putting you on the 1st page of Google. Email us back to get a full proposal.', 'USER_CONTACT_163', '2014-02-13 06:28:05', '2014-02-13 06:28:05', 0),
(164, 'ORLANDO LUIS FRANCESCONI', NULL, 'ideasmkt10@gmail.com', '+376 332227', 'Buen día,\r\nPara acceder al CY, es necesario hacer anteriormente los dos cursos anteriores, el PER Y EL PY?\r\nEn cualquiera de los casos, y si fuere intensivo, de que tiempo y presupuesto hablamos?\r\n\r\nDesde ya muchas gracias.\r\n\r\nUn saludo.', 'USER_CONTACT_164', '2014-02-13 16:17:15', '2014-02-13 16:17:15', 0),
(165, 'Virginia Egea Villalba', NULL, 'juvey_83@hotmail.com', '617046888', 'Buenas tardes, estaría interesada en poder obtener el título para poder manejar un barco. Además, y lo más importante saber, cuanto es la totalidad de todo el procedimiento hasta obtener el permiso. Y saber, si la prueba, es un examen o no. En qué consiste. \r\n\r\nMuchas gracias.', 'USER_CONTACT_165', '2014-02-14 18:55:21', '2014-02-14 18:55:21', 0),
(166, 'Carmen Suárez-Llanos', NULL, 'csuarezgo@gmail.com', '661104644', 'Me gustaría informarme sobre el curso teórico de Patrón de Embarcaciones de Recreo (PER) que inicia el día 24 de Mayo en el centro Escuela.', 'USER_CONTACT_166', '2014-02-17 11:15:35', '2014-02-17 11:15:35', 0),
(167, 'Miquel', NULL, 'sastremonfar@gmail.com', '660512994', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 3 de Marzo en el centro Escuela', 'USER_CONTACT_167', '2014-02-18 19:12:07', '2014-02-18 19:12:07', 0),
(168, 'Silvia Guinovart', NULL, 'silviaguinovart@gmail.com', '661443328', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 17 de Marzo en el centro Escuela', 'USER_CONTACT_168', '2014-02-18 20:07:52', '2014-02-18 20:07:52', 0),
(169, 'Jessica Bosch', NULL, 'jess_9710@hotmail.com', '---', 'Me gustaria informarme sobre el curso teorico de Patrón de Navegación Básica (PNB) que inicia el dia 17 de Marzo en el centro Escuela', 'USER_CONTACT_169', '2014-02-19 10:58:09', '2014-02-19 10:58:09', 0),
(170, 'JOSÉ LUIS SÁNCHEZ VARGAS', NULL, 'jlsvargas@terra.com', '696805173', 'Desearía información, horarios y precios para la obtención del PER.', 'USER_CONTACT_170', '2014-02-20 15:55:06', '2014-02-20 15:55:06', 0),
(171, 'XAVI BELDA VENTURA', NULL, 'xev84@hotmail.com', 'PNB', 'Hola\r\n\r\nquería saber el precio de las prácticas de navegación y de radio del pnb ?', 'USER_CONTACT_171', '2014-02-22 10:22:21', '2014-02-22 10:22:21', 0),
(172, 'Lluis M Xicola Llorens', NULL, 'luismxicola@hotmail.com', '609709538', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 17 de Marzo en el centro Escuela. duración y precio. Sólo me interesa el PER de Motor, no de vela.Gracias', 'USER_CONTACT_172', '2014-02-25 16:10:07', '2014-02-25 16:10:07', 0),
(173, 'Borja Latorre', NULL, 'laetus81@hotmail.com', '626152710', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 3 de Marzo en el centro Escuela', 'USER_CONTACT_173', '2014-02-27 16:02:31', '2014-02-27 16:02:31', 0),
(174, 'Donna Gabriel', NULL, 'donnagabriel52@gmail.com', NULL, 'Do you want to grow your business? Do you have serious, defined sales goals? Reply back to get a full proposal.', 'USER_CONTACT_174', '2014-02-28 11:27:23', '2014-02-28 11:27:23', 0),
(175, 'Reyes Pont Córdoba', NULL, 'reyes.pont.cordoba@gmail.com', '647449788', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 17 de Marzo en el centro Escuela', 'USER_CONTACT_175', '2014-03-04 18:39:54', '2014-03-04 18:39:54', 0),
(176, 'Reyes Pont Córdoba', NULL, 'reyes.pont.cordoba@gmail.com', '647449788', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 18 de Marzo en el centro Escuela', 'USER_CONTACT_176', '2014-03-04 18:41:21', '2014-03-04 18:41:21', 0),
(177, 'Raquel Caballero Nistal', NULL, 'raquel_caballero@yahoo.es', '650078549', 'Me gustaría informarme sobre el curso teórico de Patrón de Embarcaciones de Recreo (PER) que inicia el día 1 de Julio en el centro Escuela.', 'USER_CONTACT_177', '2014-03-07 23:59:07', '2014-03-07 23:59:07', 0),
(178, 'laura lorenz baro', NULL, 'laurabaro21@hotmail.com', '667015632', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 26 de Abril en el centro Escuela', 'USER_CONTACT_178', '2014-03-09 10:52:40', '2014-03-09 10:52:40', 0),
(179, 'aurora', NULL, 'auroramateo123@gmail.com', '615296148', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 17 de Marzo en el centro Escuela', 'USER_CONTACT_179', '2014-03-13 14:09:40', '2014-03-13 14:09:40', 0),
(180, 'Eli Susan', NULL, 'eli.susan@hotmail.es', '676030760', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 14 de Abril en el centro Escuela.', 'USER_CONTACT_180', '2014-03-15 16:05:09', '2014-03-15 16:05:09', 0);
INSERT INTO `contact` (`id`, `name`, `subject`, `email`, `phone`, `body`, `TEXT_CODE`, `created`, `updated`, `isNew`) VALUES
(181, 'Elena Viaplana Cases', NULL, 'elenavica16@gmail.com', '637757432', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 24 de Mayo en el centro Escuela', 'USER_CONTACT_181', '2014-03-17 10:19:10', '2014-03-17 10:19:10', 0),
(182, 'Eloy Diez', NULL, 'eloydiez@gmail.com', '+4917652441308', 'Hola, estoy interesado en realizar las practicas de patron de yate en abril, teneis unas programadas para abril? si es asi, teneis plazas libres? hay suficientes alumnos para esos dias?\r\n\r\nNecesitaria saber con seguridad si las practicas se haran y en que dias ya que actualmente vivo en alemania y tendria que comprar billetes de avion y todo eso con bastante antelacion (en los proximos dias)\r\n\r\nQue precio tendrian? solo las de navegacion y seguridad. Daria tiempo en un fin de semana a hacer todas las horas?\r\n\r\nGracias por su atencion, espero su respuesta.\r\n\r\nReciban un cordial saludo', 'USER_CONTACT_182', '2014-03-18 16:18:39', '2014-03-18 16:18:39', 0),
(183, 'David hernandez', NULL, 'malote.dh@gmail.com', '690915597', 'Soy un chico de 37 años de barcelona busco barco superior a 10 gt para hacer practicas de marinero de puente tengo todos los titulos marinero basico y marinero de puente cartilla maritima y pasaporte y certificado medico para embarque.me urge hacer practicas', 'USER_CONTACT_183', '2014-03-18 16:31:13', '2014-03-18 16:31:13', 0),
(184, 'María Torres Sánchez', NULL, 'mariatorressanchez@hotmail.com', '620139524', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 26 de Abril en el centro Escuela', 'USER_CONTACT_184', '2014-03-19 10:55:45', '2014-03-19 10:55:45', 0),
(185, 'ALEIX GARCIA', NULL, 'DJSMERIT@GMAIL.COM', '636013523', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 26 de Abril en el centro Escuela', 'USER_CONTACT_185', '2014-03-19 21:07:19', '2014-03-19 21:07:19', 0),
(186, 'Javier', NULL, 'xaviercodl@gmail.com', '625672111', 'Buenos dias \r\n\r\nEstoy interesado en la obtencion del per agradeceria que me faciliten informacion .\r\n\r\nGracias', 'USER_CONTACT_186', '2014-03-21 15:06:39', '2014-03-21 15:06:39', 0),
(187, 'MAK ELI', NULL, 'maxirancor@gmail.com', '625364188', 'solicito información sobre el curso de PER, tengo 46 años, sobre todo el coste, el horario y la presencia y la duración.\r\nmuchas gracias \r\nMak Eli', 'USER_CONTACT_187', '2014-03-21 17:56:42', '2014-03-21 17:56:42', 0),
(188, 'Enric Blesa Herrero', NULL, 'enric.blesa@akzonobel.com', '669816076', 'Hola, \r\nestoy interesado en recibir información sobre el PER.\r\nTan sólo puedo realizar clases y/o prácticas en sábado.\r\nQuisiera saber si es posible hacerlo de esta manera y el precio.\r\n\r\nmuchas gracias\r\nEnric', 'USER_CONTACT_188', '2014-03-21 22:44:41', '2014-03-21 22:44:41', 0),
(189, 'Elisenda seriol', NULL, 'seriol.elisenda@gmail.com', '669185771', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 10 de Mayo en el centro Escuela', 'USER_CONTACT_189', '2014-03-23 20:50:41', '2014-03-23 20:50:41', 0),
(190, 'JesusMartinez', NULL, 'jesus_m_m@hotmail.com', '606431847', 'informacion PER', 'USER_CONTACT_190', '2014-03-24 14:33:31', '2014-03-24 14:33:31', 0),
(191, 'JesusMartinez', NULL, 'jesus_m_m@hotmail.com', '606431847', 'Me gustaria informarme sobre el curso teorico de Capitán de Yate (CY) que inicia el dia 21 de Abril en el centro Escuela', 'USER_CONTACT_191', '2014-03-24 14:42:52', '2014-03-24 14:42:52', 0),
(192, 'Cristian Infante Moreno', NULL, 'info@becospain.com', '617038600', 'Buenos días, queria consulta precio total para sacarser el titulo PER y mas o menos el plazo para obtener el titulo.\r\nSe que depende mucho de lo que se dedique, pero mi intención es dedicarle un poco mas de lo normal.\r\n\r\nEspero una respuesta vía email ya que suelo estar vastante ocupado en el trabajo y no puedo coger el telefono.\r\n\r\nMuchas gracias de antemano.', 'USER_CONTACT_192', '2014-03-26 10:12:56', '2014-03-26 10:12:56', 0),
(193, 'LUIS LOPEZ HIGUERAS', NULL, 'luislopezhigueras@gmail.com', '630821652', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 14 de Abril en el centro Escuela', 'USER_CONTACT_193', '2014-03-27 22:16:24', '2014-03-27 22:16:24', 0),
(194, 'Andres Lopez', NULL, 'alopez005@hotmail.com', '607463604', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 14 de Abril en el centro Escuela', 'USER_CONTACT_194', '2014-03-31 23:44:02', '2014-03-31 23:44:02', 0),
(195, 'Andres Lopez', NULL, 'alopez005@hotmail.com', '607463604', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 22 de Abril en el centro Escuela', 'USER_CONTACT_195', '2014-03-31 23:44:55', '2014-03-31 23:44:55', 0),
(196, 'Irene Castañé Valls', NULL, 'irenemaxi@hotmail.com', '664783734', 'Me gustaria informarme sobre el curso teorico de Patrón de Navegación Básica (PNB) que inicia el dia 22 de Abril en el centro Escuela.\r\nSobretodo el precio total del curso.\r\n\r\nGracias.', 'USER_CONTACT_196', '2014-04-03 09:55:26', '2014-04-03 09:55:26', 0),
(197, 'Daniel Ximenez', NULL, 'daniximenez@hotmail.com', '637746966', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 7 de Mayo en el centro Escuela', 'USER_CONTACT_197', '2014-04-05 12:43:38', '2014-04-05 12:43:38', 0),
(198, 'Alberto Vilanova', NULL, 'alberto.vilanovamf@gmail.com', '609813337', 'Agradeceré me manden precios para la obtencion del PER y PY\r\nMuchas Gracias', 'USER_CONTACT_198', '2014-04-06 11:45:10', '2014-04-06 11:45:10', 0),
(199, 'Alex Trincado', NULL, 'atrincadof@movistar.es', '639731044', 'Me gustaria informarme sobre el curso teorico de Patrón de Yate (PY) que inicia el dia 22 de Abril en el centro Escuela.', 'USER_CONTACT_199', '2014-04-06 22:20:34', '2014-04-06 22:20:34', 0),
(200, 'Lidia', NULL, 'lidia-cr@hotmail.es', NULL, 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Junio en el centro Escuela. Me interesan precios de todo en general. Es para regalar.\r\n\r\nGracias', 'USER_CONTACT_200', '2014-04-07 15:43:22', '2014-04-07 15:43:22', 0),
(201, 'Jordi Rampone', NULL, 'rampoj@gmail.com', '660031834', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 14 de Abril en el centro Escuela', 'USER_CONTACT_201', '2014-04-07 16:30:37', '2014-04-07 16:30:37', 0),
(202, 'Borja Arenas Fradera', NULL, 'borja.arenas.fradera@gmail.com', '618006390', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 22 de Abril en el centro Escuela', 'USER_CONTACT_202', '2014-04-09 18:28:00', '2014-04-09 18:28:00', 0),
(203, 'CRISTINA AYZA', NULL, 'crisalf82@hotmail.com', NULL, 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 7 de Mayo en el centro Escuela', 'USER_CONTACT_203', '2014-04-10 12:29:58', '2014-04-10 12:29:58', 0),
(204, 'Sílvia Cabestany', NULL, 'silviadelacruz@hotmail.com', '666006464', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 14 de Abril en el centro Escuela', 'USER_CONTACT_204', '2014-04-10 17:13:17', '2014-04-10 17:13:17', 0),
(205, 'David CR', NULL, 'pdcr2008@gmail.com', '686270977', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 23 de Abril en el centro Escuela', 'USER_CONTACT_205', '2014-04-10 19:37:33', '2014-04-10 19:37:33', 0),
(206, 'Donna Gabriel', NULL, 'donnagabriel53@gmail.com', 'Online Marketing of your business', 'We can increase rankings of your website in search engines. Please reply back for more details.', 'USER_CONTACT_206', '2014-04-11 11:50:04', '2014-04-11 11:50:04', 0),
(207, 'Edgar Berengena', NULL, 'eberengena@gmail.com', '696470652', 'Bona tarda,\r\nvoldria conèixer quines són les despeses del curs de PER i de si hi ha la opció de fer la part teòrica via web.\r\n\r\nMoltes gràcies,\r\nEdgar BM', 'USER_CONTACT_207', '2014-04-11 15:46:08', '2014-04-11 15:46:08', 0),
(208, 'Víctor Sabatell', NULL, 'victor.sabatell@gmail.com', '667534911', 'Me gustaria informarme sobre el curso teorico de Patrón de Navegación Básica (PNB) que inicia el dia 24 de Abril en el centro Escuela', 'USER_CONTACT_208', '2014-04-14 11:12:11', '2014-04-14 11:12:11', 0),
(209, 'Guillem Falgueras', NULL, 'gfalgueras@gmail.com', '629739497', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_209', '2014-04-14 13:02:20', '2014-04-14 13:02:20', 0),
(210, 'dolors puig', NULL, 'dolorspuig1610@hotmail.com', '616138462', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 26 de Mayo en el centro Escuela.\r\n\r\ngracias', 'USER_CONTACT_210', '2014-04-15 11:04:25', '2014-04-15 11:04:25', 0),
(211, 'marian martínez torres', NULL, 'marian_siete@msn.com', '627944203', 'Hola quería información para el curso del per , precio final con todo incluido y si teneis algún intensivo en fines de semana', 'USER_CONTACT_211', '2014-04-16 09:54:29', '2014-04-16 09:54:29', 0),
(212, 'Manuel Fernandez Campos', NULL, 'manuel1.fernandez@seat.es', '665780834', 'Solicito informació de disponibilidad de fechas y horarios, duración de los cursos, asi como tarifas o precios.\r\n\r\nGracias', 'USER_CONTACT_212', '2014-04-16 15:11:11', '2014-04-16 15:11:11', 0),
(213, 'benoit barthes', NULL, 'bbarthes75@gmail.com', '656 88 59 81', 'Buenos dias, \r\n\r\nme gustaria conoscer los precios para la licencia de capitan de yate. \r\n\r\nmuchas gracias por tu contestacion\r\n\r\nBenoit Barthes', 'USER_CONTACT_213', '2014-04-17 15:26:40', '2014-04-17 15:26:40', 0),
(214, 'Marta Hoya', NULL, 'mm.hoya@gmail.com', '629070703', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Junio en el centro Escuela', 'USER_CONTACT_214', '2014-04-19 11:28:53', '2014-04-19 11:28:53', 0),
(215, 'Cecilia Caruncho', NULL, 'cecilia_caruncho@yahoo.es', '000000000', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela.\r\nMe gustaría también saber en qué consisten las prácticas opcionales de vela.\r\nPor ultimo me gustaría saber si  el curso del PER es intensivo.\r\n\r\nGracias\r\n\r\nCecilia', 'USER_CONTACT_215', '2014-04-20 00:21:40', '2014-04-20 00:21:40', 0),
(216, 'Enric', NULL, 'enric1992@yahoo.es', NULL, 'Hola,\r\nCual es el precio todo incluido para sacarme el PER?\r\nY tambien saber si teneis algun tipo de promocion?\r\nMuchas gracias', 'USER_CONTACT_216', '2014-04-20 13:05:21', '2014-04-20 13:05:21', 0),
(217, 'MARC', NULL, 'ASENSIBCN@GMAIL.COM', '619136787', 'QUIERO SABER EL PRECIO DEL CARNET ENTERO CON VELA INCLUIDA', 'USER_CONTACT_217', '2014-04-20 14:50:37', '2014-04-20 14:50:37', 0),
(218, 'raul gonzalez', NULL, 'raul_gonzalez_salgado@hotmail.com', '655745464', 'Hola, junto a un compañero estamos buscando escuelas nauticas donde nos puedan hacer las practicas del PER en pocos dias, queremos hacer motor y vela y al ser de Tarragona nos interesaría hacer un intensivo. Es posible en su escuela?', 'USER_CONTACT_218', '2014-04-21 12:22:43', '2014-04-21 12:22:43', 0),
(219, 'Romà Olive', NULL, 'rolive@frutadelpacifico.com', '649944909', 'Buenos Días,\r\nMe gustaría saber si aun estoy a tiempo para matricularme en el PY que empieza hoy?\r\n\r\ngracias y saludos!\r\n\r\nRomà', 'USER_CONTACT_219', '2014-04-22 10:01:07', '2014-04-22 10:01:07', 0),
(220, 'María farrea Ripoll', NULL, 'mariafarres93@hotmail.com', '680171603', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 26 de Mayo en el centro Escuela', 'USER_CONTACT_220', '2014-04-22 11:12:43', '2014-04-22 11:12:43', 0),
(221, 'Luis', NULL, 'luisatlantis@gmail', '600000000', 'Hola quria saber cual es el precio para el curso PER a motor y a vela.\r\n\r\nGracias.', 'USER_CONTACT_221', '2014-04-24 13:31:40', '2014-04-24 13:31:40', 0),
(222, 'Carles Amatller Xampeny', NULL, 'skemainst@gmail.com', '637516999', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 7 de Mayo en el centro Escuela', 'USER_CONTACT_222', '2014-04-24 23:25:51', '2014-04-24 23:25:51', 0),
(223, 'Laura Sabater', NULL, 'laurism@hotmail.com', '659891636', 'Voldria saber preus del curs del PER', 'USER_CONTACT_223', '2014-04-25 22:29:07', '2014-04-25 22:29:07', 0),
(224, 'Nicolas', NULL, 'nvitale@eada.net', '610482327', 'Hola, \r\n\r\nEstoy interesado en realizar el curso para obtener el PER. \r\nMe podeis facilitar más información por favor.\r\n\r\nGracias, Nicolas', 'USER_CONTACT_224', '2014-04-27 19:20:32', '2014-04-27 19:20:32', 0),
(225, 'Ruoran Su', NULL, 'suruoran308@hotmail.com', '642623206', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 7 de Mayo en el centro Escuela.', 'USER_CONTACT_225', '2014-04-28 09:30:13', '2014-04-28 09:30:13', 0),
(226, 'Alberto Cabestany', NULL, 'albertocabestany@hotmail.com', '629569064', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 7 de Mayo en el centro Escuela', 'USER_CONTACT_226', '2014-04-28 10:29:22', '2014-04-28 10:29:22', 0),
(227, 'Donna Gabriel', NULL, 'gabrieldonna36@gmail.com', 'Want more customers?', 'Do you want to grow your business? Do you have serious, defined sales goals? Reply back to get a full proposal.', 'USER_CONTACT_227', '2014-05-01 12:11:05', '2014-05-01 12:11:05', 0),
(228, 'joan carles gomez alborch', NULL, 'mllalborch@hotmail.es', '686952403', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 26 de Mayo en el centro Escuela', 'USER_CONTACT_228', '2014-05-01 15:22:40', '2014-05-01 15:22:40', 0),
(229, 'Janaina', NULL, 'play@costa-del-tennis.com', '679085051', 'Hola, \r\n\r\nMe llamo Janaina y tengo una empresa de viajes de tenis con base en EEUU. Ofrecemos cursos de tenis para jugadores con experiencia en Barcelona, Mallorca y Gran Canaria y vamos a empezar a hacer lo mismo con la vela. Queremos trabajar con una única organización por ciudad y nos gustaría saber si estarían interesados en colaborar con nuestra empresa. (www.costa-del-tennis.com). Muchas gracias. \r\n\r\nSaludos, \r\n\r\nJanaina', 'USER_CONTACT_229', '2014-05-03 11:29:38', '2014-05-03 11:29:38', 0),
(230, 'Anaïs', NULL, 'anais.torruella.gallart@gmail.com', '679200923', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Junio en el centro Escuela', 'USER_CONTACT_230', '2014-05-05 10:34:40', '2014-05-05 10:34:40', 0),
(231, 'Astrid', NULL, 'astrid.altadill@gmail.com', '605943778', 'Hola!\r\n\r\nEstaría interesada en sacarme el título del PER, me podrían informar mejor sobre las condiciones de precio, prácticas, etc?\r\n\r\nGracias', 'USER_CONTACT_231', '2014-05-05 22:35:53', '2014-05-05 22:35:53', 0),
(232, 'Marc Martin Raya', NULL, 'napamal28@gmail.com', '711789751', 'bon dia, me gustaria recibir informacion sobre vuestro curso.\r\nen concreto para empezar el 17 de Junio ya que mi horario seria compatible con las clases de Martes y Jueves de 14:00 a 16;00\r\nespero respuesta,muchas gracias. salud!\r\nMARC', 'USER_CONTACT_232', '2014-05-06 12:55:49', '2014-05-06 12:55:49', 0),
(233, 'David', NULL, 'david@apartmentbarcelona.com', '610729453', 'Me pueden infiera cuando empieza el próximo curso para el PER, días y precios.\r\n\r\nGracias', 'USER_CONTACT_233', '2014-05-07 08:32:44', '2014-05-07 08:32:44', 0),
(234, 'Enrique Berraquero', NULL, 'tekisodan@hotmail.com', '661344341', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Junio en el centro Escuela', 'USER_CONTACT_234', '2014-05-07 15:47:16', '2014-05-07 15:47:16', 0),
(235, 'Dara', NULL, 'daratae@hotmail.com', '649926326', 'Hola estoy interesada en el título de patrón básico navegación, que podrían informar precios y disponibilidad del primer curso que tengáis?? Gracias', 'USER_CONTACT_235', '2014-05-08 08:47:22', '2014-05-08 08:47:22', 0),
(236, 'Jordi Trilla', NULL, 'jorditrilla@gmail.com', '670617740', 'Me gustaria informarme sobre el curso teorico de  (PER) que inicia el dia 26 de Mayo en el centro', 'USER_CONTACT_236', '2014-05-08 10:45:17', '2014-05-08 10:45:17', 0),
(237, 'Georgina García', NULL, 'gina.andrevi@gmail.com', '603101155', 'Buenos días quisiera precio para sacarme el per(motor y vela) en horario de mañanas y quisiera saber que esta incluido y que no esta incluido en el precio porfavor y también saber si se suspende una primera si se debe volver a pagar todo para poder repetir el examen.\r\nGracias.\r\nSaludos!', 'USER_CONTACT_237', '2014-05-09 14:17:35', '2014-05-09 14:17:35', 0),
(238, 'Josep Alsina', NULL, 'joalsi2000@yahoo.es', '630647234', 'Hola, voldria demanar informacio de cursets de PNB i PEE, horaris, preus, etc, gracies', 'USER_CONTACT_238', '2014-05-10 13:45:07', '2014-05-10 13:45:07', 0),
(239, 'CARLOS DIAZ', NULL, 'carlosdiazmba@gmail.com', '664324003', 'Buenas, \r\n\r\nDispongo del título de navegación de embarcaciones de recreo francés, pues fui residente en Francia, pero ahora he vuelto a España ¿Es necesario convalidarlo para navegar con una embarcación matriculada en España? o puedo navegar con la licencia Francesa?\r\n\r\n¿Cuáles serían los trámites necesarios para convalidarla?\r\n\r\nMuy agradecido por vuestra ayuda.\r\n\r\nReciban un cordial saludo.\r\n\r\nCarlos,', 'USER_CONTACT_239', '2014-05-13 00:38:56', '2014-05-13 00:38:56', 0),
(240, 'Pau Arroyo', NULL, 'pauarroyom@gmail.com', NULL, 'M''agradaria tenir info de preus', 'USER_CONTACT_240', '2014-05-13 11:15:13', '2014-05-13 11:15:13', 0),
(241, 'Josep M Guardiola', NULL, 'jguardiola@santpau.es', '679963436', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 17 de Junio en el centro Escuela', 'USER_CONTACT_241', '2014-05-13 18:39:11', '2014-05-13 18:39:11', 0),
(242, 'Marta roig', NULL, 'marta_rm24@homail.com', '616071446', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 17 de Junio en el centro Escuela, y saber cuantas horas son , y a parte decser martes y jueves ,  hasta que dia.\r\nUn saludo', 'USER_CONTACT_242', '2014-05-14 01:19:48', '2014-05-14 01:19:48', 0),
(243, 'Alexis Gutierrez', NULL, 'ventas@emerge.cl', '562162824', 'Estimados\r\n\r\nTengo la intención de tomar un curso de verano si es factible para aprender a navegar un velero menos a 3 pies.\r\n\r\nPor favor indicar disponibilidad de horario y tarifas si le parece pertinente.\r\n\r\nGracias', 'USER_CONTACT_243', '2014-05-15 23:17:46', '2014-05-15 23:17:46', 0),
(244, 'Alexis Gutierrez', NULL, 'ventas@emerge.cl', '562162824', 'Estimados\r\n\r\nTengo la intención de tomar un curso de verano si es factible para aprender a navegar un velero menor a 30 pies.\r\n\r\nPor favor indicar disponibilidad de horario y tarifas si le parece pertinente.\r\n\r\nGracias', 'USER_CONTACT_244', '2014-05-15 23:18:12', '2014-05-15 23:18:12', 0),
(245, 'José Luis Pinar', NULL, 'joseluis@climagua.com', '678707929', 'Desearía recibir información y precios para poder realizar las practicas de radio del per lo antes posible\r\nGracias', 'USER_CONTACT_245', '2014-05-16 21:24:18', '2014-05-16 21:24:18', 0),
(246, 'JUAN PEDRO MUÑOZ GARCIA', NULL, 'ocioturalcossebre@hotmail.es', '647419044', 'Buenos días.\r\nLes agradecería si me pudieran ayudar.\r\nMe ofrecen una barca rígida de 4,5 m de eslora con documentación  y bandera belga.\r\nMe han dicho que haciendo un contrato de compra-venta y sacando el seguro ya podría navegar sin ningún problema.\r\n¿Quisiera saber si es cierto o hay que tramitar alguna cosa mas?. ¿y que inconvenientes hay y que ventajas?\r\nMuchas gracias de antemano\r\n\r\nUn saludo\r\n\r\nJuan Pedro Muñoz.', 'USER_CONTACT_246', '2014-05-17 08:44:15', '2014-05-17 08:44:15', 0),
(247, 'juan jose ramon campodonico', NULL, 'ramjjc@hotmail.com', '670540227', 'Quisiera saber el coste del curso.\r\nGracias.', 'USER_CONTACT_247', '2014-05-18 01:45:29', '2014-05-18 01:45:29', 0),
(248, 'Alberto Riva Rodríguez', NULL, 'albertorivarodriguez@gmail.com', '678207904', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Junio en el centro Escuela.\r\n\r\nGracias!', 'USER_CONTACT_248', '2014-05-19 00:03:06', '2014-05-19 00:03:06', 0),
(249, 'Guillem Bel', NULL, 'gbel.ho@icloud.com', '690803635', 'Tinc l''examen aprobat des de septembre 2013 i m''agradaria fer les practicas.\r\n\r\nDisponibilitat i preu\r\n\r\nRadio+motor+vela \r\n\r\nCaps de setmana o tardes', 'USER_CONTACT_249', '2014-05-20 00:30:31', '2014-05-20 00:30:31', 0),
(250, 'GUILLERMO MARQUEZ HEREDIA', NULL, 'guillem@deantonioyatchs.com', '659011643', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_250', '2014-05-22 21:26:41', '2014-05-22 21:26:41', 0),
(251, 'Donna Gabriel', NULL, 'donnagabriel97@gmail.com', 'Want more customers?', 'Want more clients and customers? We will help them find you by putting you on the 1st page of Google. Email us back to get a full proposal.', 'USER_CONTACT_251', '2014-05-23 07:51:52', '2014-05-23 07:51:52', 0),
(252, 'Toni Conesa', NULL, 'toni25840@gmail.com', '931881462', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Junio en el centro Escuela.', 'USER_CONTACT_252', '2014-05-23 20:32:49', '2014-05-23 20:32:49', 0),
(253, 'Tommaso Foschi', NULL, 'tommaso_foschi@hotmail.es', '625818049', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Junio en el centro Escuela', 'USER_CONTACT_253', '2014-05-25 21:06:14', '2014-05-25 21:06:14', 0),
(254, 'RICARDO PÉREZ-CARRAL GARCÍA', NULL, 'rpcarral@gmail.com', NULL, 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Junio en el centro Escuela.', 'USER_CONTACT_254', '2014-05-26 10:48:27', '2014-05-26 10:48:27', 0),
(255, 'Carlos javier Dominguez Alonso', NULL, 'cjdominguezalonso@hotmail.com', '600005756', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 17 de Junio en el centro Escuela', 'USER_CONTACT_255', '2014-05-27 17:36:29', '2014-05-27 17:36:29', 0),
(256, 'Ricard Castell', NULL, 'Ricardcastell75@gmail.com', '617736983', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Junio en el centro Escuela', 'USER_CONTACT_256', '2014-05-28 10:23:48', '2014-05-28 10:23:48', 0),
(257, 'santiago', NULL, 'santyman007@hotmail.com', '659407691', 'hola dispongo de la titulacion PNB y queria informacion de los cursos horarios y precios de PER. muchas gracias.', 'USER_CONTACT_257', '2014-05-29 01:14:51', '2014-05-29 01:14:51', 0),
(258, 'Rafa Beaus', NULL, 'rafabeaus@hotmail.com', '669738197', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 19 de Junio en el centro Escuela', 'USER_CONTACT_258', '2014-06-03 14:45:38', '2014-06-03 14:45:38', 0),
(259, 'juan Miguel', NULL, 'jan_miquel@hotmail.com', '672385558', 'Buenos, días,\r\n\r\nAcabo de comprar un cupon en oferton por el PER, me gustaría saber como canjear y las fechas que puedo asistir, gracias!!', 'USER_CONTACT_259', '2014-06-04 11:35:09', '2014-06-04 11:35:09', 0),
(260, 'Neus Saiz Haro', NULL, 'neus.sh10@gmail.com', '649708206', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Junio en el centro Escuela', 'USER_CONTACT_260', '2014-06-05 11:07:55', '2014-06-05 11:07:55', 0),
(261, 'Pablo Rodriguez Benassi', NULL, 'pablo.afuegolento@gmail.com', '622298909', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Junio en el centro Escuela', 'USER_CONTACT_261', '2014-06-05 16:43:27', '2014-06-05 16:43:27', 0),
(262, 'Asier García', NULL, 'asiergb@gmail.com', '670827520', 'Hola,\r\nMe gustaría presentarme al examen del día 19 de julio y tener para la fecha de resultados de las notas (30 de julio) las prácticas hechas para que en caso de aprobar, tener el título el 31 de julio.\r\n\r\nNavego desde hace muchos años sin titulación (por dejadez) y necesito formalizarlo ya que dependo de gente titulada para salir a nevegar.\r\n\r\nQue plan de curso puedo coger teniendo en cuenta que mi horario es de trabajo?\r\n\r\nGracias de antemano.\r\nUn saludo,\r\nAsier', 'USER_CONTACT_262', '2014-06-06 11:52:58', '2014-06-06 11:52:58', 0),
(263, 'Daniel Osacar Andreu', NULL, 'daniel.osacar@gmail.com', '606654892', 'Me gustaria informarme sobre el curso teorico de  (PER) que inicia el dia 17 de Junio en el centro', 'USER_CONTACT_263', '2014-06-06 20:22:30', '2014-06-06 20:22:30', 0),
(264, 'merce buyse', NULL, 'mercebuyse@gmail.com', NULL, 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela.\r\n\r\nel precio de la parte teórica, lo que valen la tasas de los exámenes y cuanto cuestan las practicas.', 'USER_CONTACT_264', '2014-06-06 22:33:44', '2014-06-06 22:33:44', 0),
(265, 'Ivan Gonzalez', NULL, 'troilus83@gmail.com', '665816028', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_265', '2014-06-07 12:24:08', '2014-06-07 12:24:08', 0),
(266, 'Alba Ferrer', NULL, 'aferrerfabregas@gmail.com', '650076326', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_266', '2014-06-07 17:21:41', '2014-06-07 17:21:41', 0),
(267, 'Sandro del Val', NULL, 'sandro2225@hotmail.com', '609716722', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Junio en el centro Escuela', 'USER_CONTACT_267', '2014-06-08 13:38:34', '2014-06-08 13:38:34', 0),
(268, 'jordi bellver', NULL, 'armadajb@gmail.com', '660898587', 'Hola: volia saber el preu per fer les practiques de motor i radio, i les de vela, i quines dates ho podria realitzar (cuan abans millor). El meu telefon es el 660898587. Moltes gràcies. ATT', 'USER_CONTACT_268', '2014-06-09 14:19:59', '2014-06-09 14:19:59', 0),
(269, 'Héctor Tato Martínez', NULL, 'hector.belinda@hotmail.com', '667491679', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Junio en el centro Escuela', 'USER_CONTACT_269', '2014-06-09 18:10:20', '2014-06-09 18:10:20', 0),
(270, 'Héctor Tato Martínez', NULL, 'hector.belinda@hotmail.com', '667491679', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Junio en el centro Escuela', 'USER_CONTACT_270', '2014-06-09 18:10:41', '2014-06-09 18:10:41', 0),
(271, 'Héctor Tato Martínez', NULL, 'hector.belinda@hotmail.com', '667491679', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Junio en el centro Escuela', 'USER_CONTACT_271', '2014-06-09 18:11:45', '2014-06-09 18:11:45', 0),
(272, 'CARLES ROJAS BLANC', NULL, 'c_rojasblanc@yahoo.es', '615262935', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_272', '2014-06-10 05:16:56', '2014-06-10 05:16:56', 0),
(273, 'Alejandro Ferrer', NULL, 'alejandro.ferrer@cmontserrat.net', '690 009 609', 'Me gustaria saber que horarios hay para sacarse el torico de Pert este mes', 'USER_CONTACT_273', '2014-06-10 10:33:16', '2014-06-10 10:33:16', 0),
(274, 'Daniel Martinez Vera', NULL, 'dmartinezvera.79@gmail.com', '661867056', 'Hola, necesito obtener el PER a la mayor brevedad. Me gustaria saber el precio total y horario para la obtencion completa, asi como la fecha de la proxima convocatoria. Muchas gracias de antemano.', 'USER_CONTACT_274', '2014-06-10 18:08:57', '2014-06-10 18:08:57', 0),
(275, 'jordi serrano', NULL, 'jserranos62@gmail.com', '633708984', 'Practicas de vela', 'USER_CONTACT_275', '2014-06-13 09:53:36', '2014-06-13 09:53:36', 0),
(276, 'Daniel Osacar', NULL, 'daniel.osacar@gmail.com', '606654892', 'Me gustaria informarme sobre el curso teorico de  (PER) que inicia el dia 17 de Junio en el centro', 'USER_CONTACT_276', '2014-06-13 20:31:21', '2014-06-13 20:31:21', 0),
(277, 'Daniel Osacar', NULL, 'daniel.osacar@gmail.com', '606654892', 'Me gustaria informarme sobre el curso teorico de  (PER) que inicia el dia 17 de Junio en el centro', 'USER_CONTACT_277', '2014-06-13 20:31:23', '2014-06-13 20:31:23', 0),
(278, 'Alberto Jiménez', NULL, 'alberto30007@yahoo.es', '670709901', 'Parar información  titulación (per) para mi y mi pareja. Se puede sacar directamente la titulación Per sin antes disponer de otra? Espero su respuesta. Gracias', 'USER_CONTACT_278', '2014-06-14 15:02:36', '2014-06-14 15:02:36', 0),
(279, 'Teresa', NULL, 'teresa.montero.sferragut@gmail.com', '622407124', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_279', '2014-06-14 20:13:35', '2014-06-14 20:13:35', 0),
(280, 'Agusti Gomez', NULL, 'Agomez@lossantosibericos.com', '630718716', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 16 de Junio en el centro Escuela', 'USER_CONTACT_280', '2014-06-15 09:59:32', '2014-06-15 09:59:32', 0),
(281, 'julio isidro santamaria biedma', NULL, 'jsantamaria@yahoo.com', '696893683', 'Me interesaria realizar de forma presencial es curspo del PER.\r\n\r\nGracias', 'USER_CONTACT_281', '2014-06-16 07:58:14', '2014-06-16 07:58:14', 0),
(282, 'Ignacio Nogués', NULL, 'guesio_21@hotmail.com', '618042254', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Junio en el centro Escuela', 'USER_CONTACT_282', '2014-06-16 15:29:13', '2014-06-16 15:29:13', 0),
(283, 'Miquel Planiol', NULL, 'mplaniol@gmail.com', '617475761', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Junio en el centro Escuela', 'USER_CONTACT_283', '2014-06-17 08:12:42', '2014-06-17 08:12:42', 0),
(285, 'Ricardo', NULL, 'threechard@hotmail.com', '(+45)50396920', 'Buenos dias,\r\n\r\nLes escribo para pedirles informacion sobre el titulo PER.\r\n\r\nActualmente me encuentro viviendo en Dinamarca lo que me imposibilita poder desplazarme para los cursos. Lo que me gustaria que me informaran es de las posibilidades que existen de sacarme la parte teorica a distancia.\r\n\r\nHe visto que hay una convocatoria antes de Agosto y me gustaria poder presentarme a ella.\r\n\r\nYo soy de Santander pero tengo familia muy cerca de su escuela. He navegado de pequeno en embarcaciones deportivas y ya de mayor he vuelto a navegar en yate de vela.\r\n\r\nEspero su respuesta. Recivan un cordial saludo,\r\n\r\nRicardo Paternina.', 'USER_CONTACT_285', '2014-06-17 13:17:38', '2014-06-17 13:17:38', 0),
(286, 'Ricardo', NULL, 'threechard@hotmail.com', '(+45)50396920', 'Buenos dias,\r\n\r\nLes escribo para pedirles informacion sobre el titulo PER.\r\n\r\nActualmente me encuentro viviendo en Dinamarca lo que me imposibilita poder desplazarme para los cursos. Lo que me gustaria que me informaran es de las posibilidades que existen de sacarme la parte teorica a distancia.\r\n\r\nHe visto que hay una convocatoria antes de Agosto y me gustaria poder presentarme a ella.\r\n\r\nYo soy de Santander pero tengo familia muy cerca de su escuela. He navegado de pequeno en embarcaciones deportivas y ya de mayor he vuelto a navegar en yate de vela.\r\n\r\nEspero su respuesta. Recivan un cordial saludo,\r\n\r\nRicardo Paternina.', 'USER_CONTACT_286', '2014-06-17 13:17:40', '2014-06-17 13:17:40', 0),
(287, 'Joel Blazquez Sargatal', NULL, 'scarbez@gmail.com', '626 140 712', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 21 de Junio en el centro Escuela', 'USER_CONTACT_287', '2014-06-18 20:12:09', '2014-06-18 20:12:09', 0),
(288, 'Marianne Lebègue-Pierre', NULL, 'mlebegue@gmail.com', '654696949', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_288', '2014-06-19 13:29:40', '2014-06-19 13:29:40', 0),
(289, 'Rubén García Padilla', NULL, 'ruben.gap@gmail.com', '699718617', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela. \r\n\r\nExactamente me gustaría saber si tenéis algún tipo de horario por la tarde o noche para este tipo de curso.\r\n\r\nEl caso es que trabajo hasta las 15.00h y debería hacer las clases después.\r\n\r\nGracias y un saludo,\r\n\r\nRubén', 'USER_CONTACT_289', '2014-06-20 07:00:54', '2014-06-20 07:00:54', 0),
(290, 'sergi artigas', NULL, 'sergicloner@gmail.com', 'portselva2', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_290', '2014-06-20 12:19:54', '2014-06-20 12:19:54', 0),
(291, 'sergi artigas', NULL, 'sergicloner@gmail.com', '646297266', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_291', '2014-06-20 12:20:21', '2014-06-20 12:20:21', 0),
(292, 'aurora', NULL, 'auroramateo123@gmail.com', '615296148', 'Me gustaria informarme sobre el curso teorico de Patrón de Navegación Básica (PNB) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_292', '2014-06-20 13:18:58', '2014-06-20 13:18:58', 0),
(293, 'ignacio', NULL, 'igna_rodri_44@hotmail.com', '647798555', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_293', '2014-06-21 17:56:37', '2014-06-21 17:56:37', 0),
(294, 'Josep Favà Cid', NULL, 'josepfava@gmail.com', '662286732', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 28 de Junio en el centro Escuela\r\nLa disponibilidad en días laborables es difcil, pero en fines de semana hay disponibilidad\r\n\r\nGracias', 'USER_CONTACT_294', '2014-06-21 18:28:26', '2014-06-21 18:28:26', 0),
(295, 'Joan Bonillo García', NULL, 'gt-turbo-10@hotmail.com', '622107106', 'Te llame el domingo para informarme ,,, saludos', 'USER_CONTACT_295', '2014-06-22 14:17:26', '2014-06-22 14:17:26', 0),
(296, 'Arcay Nicobara Gelabert', NULL, 'ar_cay_12@hotmail.com', '636726604', 'Buenas trades,\r\nMi nombre es Arcay, soy un estudiante de Menorca y voy a vivir desde el mes de Octubre en Barcelona for estudios. Me gustaria saber si tambien we realizan cursos náuticos a partir de esas fechas.!?\r\nMuchas gracias,\r\n\r\nAtt: Arcay', 'USER_CONTACT_296', '2014-06-22 20:17:17', '2014-06-22 20:17:17', 0),
(297, 'Xavier de Pedro', NULL, 'xavier__24hotmail.com', '622640024', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 28 de Junio en el centro Escuela, número de clases i practicas.\r\n\r\nGracias', 'USER_CONTACT_297', '2014-06-22 20:51:37', '2014-06-22 20:51:37', 0),
(298, 'Xavier de Pedro', NULL, 'xavier__24@hotmail.com', '622640024', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 28 de Junio en el centro Escuela, número de clases i practicas.\r\n\r\nGracias', 'USER_CONTACT_298', '2014-06-22 20:51:51', '2014-06-22 20:51:51', 0),
(299, 'Marcos Pantaleón Sánchez', NULL, 'marcospantaleon@hotmail.com', '686483264', 'Hola, me gustaría saber si es posible realizar las prácticas de vela para P.E.R durante las dos primeras semanas de julio de 2014(desde el 30 de Junio hasta el 13 de Julio) además del precio, horarios...etc. Una plaza. Gracias y un saludo.', 'USER_CONTACT_299', '2014-06-22 21:04:35', '2014-06-22 21:04:35', 0),
(300, 'Manel López', NULL, 'manel.lopez@sisconcnc.net', '609540369', 'Benvolguts,\r\n\r\nEstic interessat en treure''m el títol PER.\r\nPer temes de feina, la teòrica hauria de ser a distància i les prèctiques els caps de setmana.\r\nPodrien donar-me informació al respecte?\r\n\r\nSalutacions,\r\nManel López', 'USER_CONTACT_300', '2014-06-23 01:00:47', '2014-06-23 01:00:47', 0),
(301, 'aurora mateo', NULL, 'auroramateo123@gmail.com', '615296148', 'ggg', 'USER_CONTACT_301', '2014-06-23 12:09:36', '2014-06-23 12:09:36', 0),
(302, 'Josep Muncunill Farreny', NULL, 'jepadejep@hotmail.com', NULL, 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_302', '2014-06-23 13:03:12', '2014-06-23 13:03:12', 0),
(303, 'manuel cano', NULL, 'm.cano22@hotmail.com', NULL, 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_303', '2014-06-24 16:41:46', '2014-06-24 16:41:46', 0),
(304, 'manuel cano', NULL, 'm.cano22@hotmail.com', '630123232', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_304', '2014-06-24 16:42:07', '2014-06-24 16:42:07', 0),
(305, 'Daniel Morales Prats', NULL, 'dmoralesprats@yahoo.es', '630281132', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela.\r\n\r\nAdemás quería saber si hay prácticas a vela.\r\n\r\nMuchas gracias.\r\n\r\nSaludos.', 'USER_CONTACT_305', '2014-06-25 13:16:59', '2014-06-25 13:16:59', 0),
(306, 'clara quintana', NULL, 'clara@altrescoses.cat', '669943350', 'Me gustaria informarme sobre el curso teorico de Patrón de navegacion basica. Muchas gracias! Clara', 'USER_CONTACT_306', '2014-06-25 13:54:42', '2014-06-25 13:54:42', 0),
(307, 'Guillermo Navarro Rodríguez', NULL, 'guinaro6@hotmail.com', '691332108', 'Estoy interesado en recibir información de cómo puedo sacar algún título para este verano gracias', 'USER_CONTACT_307', '2014-06-25 14:53:08', '2014-06-25 14:53:08', 0),
(308, 'Enric Mollón', NULL, 'emollon@gmail.com', '687783412', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_308', '2014-06-26 15:37:55', '2014-06-26 15:37:55', 0),
(309, 'Georgina Harster', NULL, 'ginaharster27@gmail.com', '626669817', 'Me gustaría informarme sobre el curso teórico de Patrón de Navegación Básica (PNB) que inicia el día 1 de Julio en el centro Escuela en horario de mañanas.\r\n\r\nEl comprobante médico se tiene que traer ya el mismo día de la inscripción, o puede traerse más tarde?\r\n\r\nMuchas gracias', 'USER_CONTACT_309', '2014-06-26 18:21:34', '2014-06-26 18:21:34', 0),
(310, 'Marc Colonques García-Planas', NULL, 'marc_colonques@hotmail.com', '667182452', 'Me gustaria informarme sobre el curso teorico de Patrón de Navegación Básica (PNB) que inicia el dia 1 de Julio en el centro Escuela.', 'USER_CONTACT_310', '2014-06-26 19:59:31', '2014-06-26 19:59:31', 0),
(311, 'Marc Brossa Gonzàlez', NULL, 'marcbrossa@hotmail.com', '626838333', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_311', '2014-06-27 18:46:29', '2014-06-27 18:46:29', 0),
(312, 'ada', NULL, 'adiquins88@hotmail.com', '678139402', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_312', '2014-06-28 00:18:16', '2014-06-28 00:18:16', 0),
(313, 'David Pamies', NULL, 'dpm1878@hotmail.com', '659081451', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_313', '2014-06-29 18:10:09', '2014-06-29 18:10:09', 0),
(314, 'Juan Carlos Pueyo', NULL, 'juancarlospueyo@gmail.com', '676099749', 'Buenos dias,resido en provincia Huesca y quisiera sacarme el PER,de forma comoda a ser posible,evitando al minimo los desplazamientos a Barcelona.\r\nQue opcion podria ser? Muchas gracias\r\nJuan Carlos', 'USER_CONTACT_314', '2014-06-30 11:55:26', '2014-06-30 11:55:26', 0),
(315, 'xavier font', NULL, 'xavi_font_sala@hotmail.com', '667214317', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela. Las practicas van incluidas?', 'USER_CONTACT_315', '2014-06-30 12:55:25', '2014-06-30 12:55:25', 0),
(316, 'Eduard Torrent', NULL, 'eduardtorrentm@gmail.com', '606105193', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_316', '2014-06-30 19:41:33', '2014-06-30 19:41:33', 0),
(317, 'Jordi Jiménez', NULL, 'jordijire@hotmail.com', '931790195', 'Desearía tener información más completa sobre la obtención del PER, horarios, tiempo estimado necesario para la preparación del examen, etc\r\nGracias', 'USER_CONTACT_317', '2014-07-01 08:42:06', '2014-07-01 08:42:06', 0),
(318, 'Tim Carreras', NULL, 'timcar82@hotmail.com', '680667194', 'Buenas,\r\n\r\nme gustaría saber la fecha para siguiente convocatoria del PER (no la de julio, la siguiente). Gracias!\r\n\r\nSaludos', 'USER_CONTACT_318', '2014-07-01 08:50:19', '2014-07-01 08:50:19', 0),
(319, 'Lisa Osterbrink', NULL, 'lisaosterbrink@hotmail.com', '0034671150202', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela. \r\nHabrán otras clases mas tarde también?', 'USER_CONTACT_319', '2014-07-02 11:39:40', '2014-07-02 11:39:40', 0),
(320, 'MARIA PAR BERTRAN', NULL, 'mparbertran@gmail.com', '0034647021998', 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela\r\n\r\nEl problema es que el proximo 7,8,9 de Julio estoy fuera por trabajo\r\n\r\nGracias,', 'USER_CONTACT_320', '2014-07-02 13:05:30', '2014-07-02 13:05:30', 0),
(321, 'Jordi Asensio Porti', NULL, 'jordi-asensio@hotmail.com', '658909004', 'Hola,\r\nMe interesa el curso de PER y me gustaria sacármelo ahora en Julio pero no sé si como el curso ya está empezado puedo inscribirme de todos modos y recuperar las clases perdidas.\r\nMuchas gracias', 'USER_CONTACT_321', '2014-07-03 11:50:38', '2014-07-03 11:50:38', 0),
(322, 'Iñaki Guinea', NULL, 'iguinea@gmail.com', '635312522', 'Me gustaria informarme sobre los próximos cursos teoricos de Patrón de Embarcaciones de Recreo (PER)', 'USER_CONTACT_322', '2014-07-04 00:08:10', '2014-07-04 00:08:10', 0),
(323, 'Juan Giner', NULL, 'juanginer90@gmail.com', '620352010', 'Buenos días\r\nMe gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela. \r\nLa verdad es que yo trabajao hasta las 8 y no llegaría a las clases, por lo que me gustaría saber si hay algunas clases intensivas el fin de semana o algo por el estilo.\r\n\r\nUn saludo', 'USER_CONTACT_323', '2014-07-05 14:00:06', '2014-07-05 14:00:06', 0),
(324, 'alex art', NULL, 'navegalex@hotmail.com', '677887228', 'Hola, queria saber cuanto vale el curso py y si es completamente presencial', 'USER_CONTACT_324', '2014-07-09 19:12:41', '2014-07-09 19:12:41', 0),
(325, 'Alex Mir', NULL, 'mir_92mir@hotmail.com', '616431810', 'Buenas tardes,\r\n\r\nEstoy interesado en obtener el PER, pueden darme información de las fechas de los cursos y precios? El curso tendría que ser a partir de las 18 horas de la tarde por motivos de trabajo.\r\n\r\nMuchas gracias,\r\n\r\nAlex', 'USER_CONTACT_325', '2014-07-11 14:43:45', '2014-07-11 14:43:45', 0),
(326, 'Morty', NULL, 'support@superbsocial.net', '877-410-4002', 'Hello, my name is Morty Goldman; I just stumbled upon your site - www.escuelanauticasantalo.com - I''m sorry to write in such an odd manner, I thought to call you but I didn''t want to take up your time. What I have to say may be of great interest to you. Did you know that an overwhelming majority of businesses, organizations and celebrities buy likes and followers? What, you thought your competitor''s likes and followers are organic and naturally gained? Ha ha. Just recently Gangman Style ( http://www.youtube.com/watch?v=9bZkp7q19f0 ) reached a record 2 billion views. Now imagine the scale of Gangnam Style''s popularity being applied to your business! This is exactly how I deliver results to my clients - and I assure you that you''ll be overwhelmingly pleased with the outcome. \r\n \r\nGive us a call: +1 (877) 410-4002 \r\nor visit us at http://www.SuperbSocial.net', 'USER_CONTACT_326', '2014-07-13 21:28:34', '2014-07-13 21:28:34', 0),
(327, 'VICENT GROBA', NULL, 'vgroba@outlook.es', '687355866', 'Hola,\r\n\r\nMe gustaria sacar el PER\r\n\r\nInformación\r\n\r\nPrecios\r\n\r\nGracias', 'USER_CONTACT_327', '2014-07-14 18:03:49', '2014-07-14 18:03:49', 0),
(328, 'John Wilson', NULL, 'johnw2342@gmail.com', '0130130130', 'We will optimize your site to increase the number of visitors to your website through our white-hat SEO services at a very affordable price.Email us back to get a full proposal.', 'USER_CONTACT_328', '2014-07-17 05:40:45', '2014-07-17 05:40:45', 0),
(329, 'Manu fernandez', NULL, 'fjoseman@gmail.com', '692217331', 'Buenas, \r\nEstoy interesado en sacar el PER, me interesaria hacer algo intensivo y rapido, que precio tendria y cuando podeia empezar, mi telefono es el 692217331. Gracias', 'USER_CONTACT_329', '2014-07-17 09:54:42', '2014-07-17 09:54:42', 0),
(330, 'Manuel Cruz DiaZ', NULL, 'lolocd_@hotmail.com', '652943975', 'Quisiera saber más o menos la duración de los cursos y si tenéis alguno próximamente.  Gracias', 'USER_CONTACT_330', '2014-07-21 17:58:09', '2014-07-21 17:58:09', 0),
(331, 'maria rosa martinez morte', NULL, 'mrmartinezmorte@gmail.com', NULL, 'Me gustaria informarme sobre el curso teorico de Patrón de Embarcaciones de Recreo (PER) que inicia el dia 1 de Julio en el centro Escuela', 'USER_CONTACT_331', '2014-07-21 19:33:19', '2014-07-21 19:33:19', 0),
(332, 'ORIOL GALLART ANTON', NULL, 'o.gallart@gmail.com', '686874701', 'Bon dia....\r\n\r\nfeta la convocatoria d''examen d capità de iot del mes de Juliol, i que hem queda Angles que anire a Desembre...voldria començar el tema de les practiques de motor, vela i radio. voldria saber preus, si hi ha facilitat de pagament, horaris.\r\n\r\nAte.\r\nuna salutació cordial mariners....\r\n\r\nOriol', 'USER_CONTACT_332', '2014-07-22 09:12:53', '2014-07-22 09:12:53', 0),
(333, 'Daniel Guerrero', NULL, 'dani_dgv@hotmail.com', '646576594', 'Hola,\r\n\r\nMe gustaría saber si vuestra escuela hace cursos online para obtener el PER.\r\n\r\nGracias.', 'USER_CONTACT_333', '2014-07-22 18:39:44', '2014-07-22 18:39:44', 0),
(334, 'David Rodriguez Valverde', NULL, 'drodval@gmail.com', '673885722', 'Buenas tardes,\r\nestoy interesado en sacarme el título PER para este verano, aunque voy un poco tarde, quisiera saber que plazos aproximados se necesitarian para poder disfrutar este verano de una embarcación mediana, tan solo para movernos de cala en cala por la costa por un dia.\r\n\r\nMuchas gracias por su atención.', 'USER_CONTACT_334', '2014-07-23 14:50:26', '2014-07-23 14:50:26', 0),
(335, 'Daniel Guerrero', NULL, 'dani_dgv@hotmail.com', '646576594', 'Hola,\r\n\r\nMe gustaría sacarme el título del PER de forma online ya que soy de Lleida. Me gustaría saber si hacéis esta modalidad así como el precio total al que ascendería (contando prácticas de motor, de radio y de vela).\r\n\r\nSaludos.', 'USER_CONTACT_335', '2014-07-24 17:45:27', '2014-07-24 17:45:27', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `convocation`
--

CREATE TABLE `convocation` (
  `id` int(11) NOT NULL,
  `product_id` int(11) DEFAULT NULL,
  `center_id` int(11) DEFAULT NULL,
  `start` date NOT NULL,
  `days` longtext COLLATE utf8_unicode_ci COMMENT '(DC2Type:array)',
  `schedule` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `exam` date NOT NULL,
  `created` datetime NOT NULL,
  `updated` datetime NOT NULL,
  `enabled` tinyint(1) NOT NULL,
  `type` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `convocation`
--

INSERT INTO `convocation` (`id`, `product_id`, `center_id`, `start`, `days`, `schedule`, `exam`, `created`, `updated`, `enabled`, `type`) VALUES
(73, 1, 2, '2014-05-23', 'Sábado', '10:00-14:30', '2014-06-19', '2014-06-20 13:11:28', '2014-06-23 12:06:23', 1, 'Teórico'),
(84, 2, 2, '2014-05-23', 'Sábado', '10:00-14:00', '2014-06-19', '2014-05-04 13:11:28', '2014-05-04 12:06:23', 0, 'Teórico'),
(114, 1, 2, '2014-05-26', 'Martes, Jueves', '14:00-16:30', '2014-06-19', '2014-06-20 13:11:28', '2014-06-23 12:06:23', 1, 'Teórico'),
(115, 1, 2, '2015-05-26', 'Martes, Jueves', '19:30-21:30', '2015-06-19', '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1, 'Teórico'),
(116, 1, 2, '2015-05-27', 'Lunes. Miercoles', '19:30-21:30', '2015-06-19', '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1, 'Teórico'),
(117, 1, 2, '2015-06-20', 'Sábado', '10:00-14:30', '2015-07-17', '2015-05-04 00:00:00', '2015-05-04 00:00:00', 1, 'Teórico'),
(118, 1, 2, '2015-06-22', 'Lunes, Miercoles', '14:00-16:00', '2015-07-17', '2015-05-04 00:00:00', '2015-05-04 00:00:00', 1, 'Teórico'),
(119, 1, 2, '2015-06-22', 'Lunes, Miercoles', '19:30-21:30', '2015-07-17', '2015-05-04 00:00:00', '2015-05-04 00:00:00', 1, 'Teórico'),
(120, 1, 2, '2015-06-23', 'Jueves, Martes', '10:00-12:00', '2015-07-17', '2015-05-04 00:00:00', '2015-05-04 00:00:00', 1, 'Teórico'),
(121, 1, 2, '2015-06-23', 'Martes, Jueves', '19:30-21:30', '2015-07-17', '2015-05-04 00:00:00', '2015-05-04 00:00:00', 1, 'Teórico'),
(123, 2, 2, '2014-05-26', 'Martes, Jueves', '10:00-12:00', '2014-06-19', '2014-05-04 13:11:28', '2014-05-04 12:06:23', 1, 'Teórico'),
(124, 2, 2, '2015-05-26', 'Martes, Jueves', '19:30-21:30', '2015-06-19', '2015-05-04 00:00:00', '2015-05-04 00:00:00', 1, 'Teórico'),
(125, 2, 2, '2015-05-25', 'Lunes, Miercoles', '14:00-16:00', '2015-06-19', '2015-05-04 00:00:00', '2015-05-04 00:00:00', 1, 'Teórico'),
(126, 2, 2, '2015-05-25', 'Lunes, Miercoles', '19:30-21:30', '2015-06-19', '2015-05-04 00:00:00', '2015-05-04 00:00:00', 1, ' Teórico'),
(127, 2, 2, '2015-06-19', 'Viernes', '17:00-21:30', '2015-07-17', '2015-05-04 00:00:00', '2015-05-04 00:00:00', 1, 'Teórico'),
(128, 2, 2, '2015-06-20', 'Sábado', '10:00-14:30', '2015-07-17', '2015-05-04 00:00:00', '2015-05-04 00:00:00', 1, 'Teórico'),
(129, 2, 2, '2015-06-22', 'Lunes, Miercoles', '10:00-12:00', '2015-07-17', '2015-05-04 00:00:00', '2015-05-04 00:00:00', 1, 'Teórico'),
(130, 2, 2, '2015-06-22', 'Lunes, Miercoles', '19:30-21:30', '2015-07-17', '2015-05-04 00:00:00', '2015-05-04 00:00:00', 1, 'Teórico'),
(131, 2, 2, '2015-06-23', 'Martes, Jueves', '14:00-16:00', '2015-07-17', '2015-05-04 00:00:00', '2015-05-04 00:00:00', 1, 'Teórico'),
(132, 2, 2, '2015-07-01', 'De Lunes a Viernes', '10:00-12:00', '2015-07-17', '2015-05-04 00:00:00', '2015-05-04 00:00:00', 1, 'Teórico'),
(133, 2, 2, '2015-07-01', 'De Lunes a Viernes', '19:30-21:30', '2015-07-17', '2015-05-04 00:00:00', '2015-05-04 00:00:00', 1, 'Teórico');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `featured`
--

CREATE TABLE `featured` (
  `id` int(11) NOT NULL,
  `precio` decimal(10,2) DEFAULT NULL,
  `título` varchar(150) COLLATE latin1_spanish_ci DEFAULT NULL,
  `texto` varchar(500) COLLATE latin1_spanish_ci DEFAULT NULL,
  `link` varchar(300) COLLATE latin1_spanish_ci DEFAULT NULL,
  `fecha_inicio` datetime DEFAULT NULL,
  `fecha_fin` datetime DEFAULT NULL,
  `active` bit(1) DEFAULT NULL,
  `image_url` longtext COLLATE latin1_spanish_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

--
-- Volcado de datos para la tabla `featured`
--

INSERT INTO `featured` (`id`, `precio`, `título`, `texto`, `link`, `fecha_inicio`, `fecha_fin`, `active`, `image_url`) VALUES
(25, '99.00', 'FEATURED_TITLE_25', 'FEATURED_TITLE_25', 'Featured/PromoPER XXX', '2015-06-09 00:00:00', '2015-06-15 00:00:00', b'1', '~/UploadedContent/Featured/writing-test-items.png');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `literales`
--

CREATE TABLE `literales` (
  `ID` int(11) NOT NULL,
  `TEXT_CODE` varchar(100) COLLATE latin1_spanish_ci NOT NULL,
  `DESCRIPTION` varchar(200) COLLATE latin1_spanish_ci NOT NULL,
  `LANGUAGE_CODE` varchar(10) COLLATE latin1_spanish_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

--
-- Volcado de datos para la tabla `literales`
--

INSERT INTO `literales` (`ID`, `TEXT_CODE`, `DESCRIPTION`, `LANGUAGE_CODE`) VALUES
(71, 'PRODUCT_DESCRIPTION_1', 'Motos acuáticas. Veleros hasta 8 metros.', 'es'),
(162, 'CENTER_INFOWINDOW_4', '', 'en'),
(15, 'CENTER_NAME_1', 'Port', 'ca'),
(17, 'CENTER_INFOWINDOW_1', 'Pantalan número 7. <br />Amarre 4722', 'es'),
(14, 'CENTER_NAME_1', 'Port', 'en'),
(8, 'FEATURED_TEXT_25', 'Curso preparación PER XXXX', 'es'),
(9, 'FEATURED_TEXT_25', 'Curs de preparació PER zzz', 'ca'),
(10, 'FEATURED_TEXT_25', 'Preparation course PER zzzz', 'en'),
(11, 'FEATURED_TITLE_25', 'Curso preparación PER XXXX', 'es'),
(12, 'FEATURED_TITLE_25', 'Curs de preparació PER zzz', 'ca'),
(13, 'FEATURED_TITLE_25', 'Preparation course PER zzzz', 'en'),
(16, 'CENTER_NAME_1', 'Puerto', 'es'),
(18, 'CENTER_INFOWINDOW_1', 'Pantalan número 7. <br />Amarratge 4722', 'ca'),
(19, 'CENTER_INFOWINDOW_1', 'Pantalan number 7 4722 <br /> moorage', 'en'),
(20, 'CENTER_NAME_2', 'Escuela', 'es'),
(21, 'CENTER_NAME_2', 'Escola', 'ca'),
(22, 'CENTER_NAME_2', 'School', 'en'),
(23, 'CENTER_NAME_3', 'Puerto Tarragona', 'es'),
(24, 'CENTER_NAME_3', 'Port Tarragona', 'ca'),
(25, 'CENTER_NAME_3', 'Tarragona Port', 'en'),
(70, 'PRODUCT_NAME_1', 'Basic Navigation Patterns', 'en'),
(69, 'PRODUCT_NAME_1', 'Patró de Navegació Bàsica', 'ca'),
(68, 'PRODUCT_NAME_1', 'Patrón de Navegación Básica', 'es'),
(72, 'PRODUCT_DESCRIPTION_1', 'Motos aquàtiques. Velers fins a 8 metres.', 'ca'),
(73, 'PRODUCT_DESCRIPTION_1', 'Jetski. Sailboats up to 8 meters.', 'en'),
(74, 'PRODUCT_DISTANCE_1', '5 millas', 'es'),
(75, 'PRODUCT_DISTANCE_1', '5 milles', 'ca'),
(76, 'PRODUCT_DISTANCE_1', '5 miles', 'en'),
(77, 'PRODUCT_TEXT_1', '', 'es'),
(78, 'PRODUCT_TEXT_1', '', 'ca'),
(79, 'PRODUCT_TEXT_1', '', 'en'),
(80, 'PRODUCT_NAME_2', 'Patrón de Embarcaciones de Recreo', 'es'),
(81, 'PRODUCT_NAME_2', 'Patró d´Embarcacions d´Esbarjo', 'ca'),
(82, 'PRODUCT_NAME_2', 'Master of Yachts', 'en'),
(83, 'PRODUCT_DESCRIPTION_2', 'Patrón de Embarcaciones de Recreo', 'es'),
(84, 'PRODUCT_DESCRIPTION_2', 'Patró d´Embarcacions d´Esbarjo', 'ca'),
(85, 'PRODUCT_DESCRIPTION_2', 'Master of Yachts', 'en'),
(86, 'PRODUCT_DISTANCE_2', '12 millas interinsulares.', 'es'),
(87, 'PRODUCT_DISTANCE_2', '12 milles interinsulars.', 'ca'),
(88, 'PRODUCT_DISTANCE_2', '12 miles interisland.', 'en'),
(89, 'PRODUCT_TEXT_2', ' ', 'es'),
(90, 'PRODUCT_TEXT_2', ' ', 'ca'),
(91, 'PRODUCT_TEXT_2', ' ', 'en'),
(93, 'PRODUCT_NAME_3', 'Patró de Iot', 'ca'),
(94, 'PRODUCT_NAME_3', 'Yacht Master', 'en'),
(95, 'PRODUCT_DESCRIPTION_3', 'Vela, motor y motos acuáticas. Hasta 20 metros de eslora', 'es'),
(96, 'PRODUCT_DESCRIPTION_3', 'Vela, motor i motos aquàtiques. Fins a 20 metres d´eslora.', 'ca'),
(97, 'PRODUCT_DESCRIPTION_3', 'Sailing, motor bikes and water sports. Up to 20 meters in length.', 'en'),
(98, 'PRODUCT_DISTANCE_3', '60 millas.', 'es'),
(99, 'PRODUCT_DISTANCE_3', '60 milles.', 'ca'),
(100, 'PRODUCT_DISTANCE_3', '60 miles.', 'en'),
(101, 'PRODUCT_TEXT_3', ' ', 'es'),
(102, 'PRODUCT_TEXT_3', ' ', 'ca'),
(103, 'PRODUCT_TEXT_3', ' ', 'en'),
(92, 'PRODUCT_NAME_3', 'Patrón de Yate', 'es'),
(116, 'PRODUCT_NAME_4', 'Capitán de Yate', 'es'),
(117, 'PRODUCT_NAME_4', 'Capità de Iot', 'ca'),
(118, 'PRODUCT_NAME_4', 'Yacht Captain', 'en'),
(119, 'PRODUCT_DESCRIPTION_4\n', 'Vela, motor y motos acuáticas. Sin límite.', 'es'),
(120, 'PRODUCT_DESCRIPTION_4\n', 'Vela, motor i motos aquàtiques. Sense límit.', 'ca'),
(121, 'PRODUCT_DESCRIPTION_4\n', 'Sailing, motor and watercraft. No limit.', 'en'),
(122, 'PRODUCT_DISTANCE_4', 'Sin límite de millas.', 'es'),
(123, 'PRODUCT_DISTANCE_4', 'Sense límit de milles.', 'ca'),
(124, 'PRODUCT_DISTANCE_4', 'Unlimited miles.', 'en'),
(125, 'PRODUCT_TEXT_4', 'oooo', 'es'),
(126, 'PRODUCT_TEXT_4', 'ooooo', 'ca'),
(127, 'PRODUCT_TEXT_4', 'oooo', 'en'),
(128, 'PRODUCT_DESCRIPTION_5', '...', 'es'),
(129, 'PRODUCT_NAME_5', 'Licencia de Navegación', 'es'),
(132, 'PRODUCT_TEXT_5', '', 'es'),
(154, 'CENTER_NAME_4', 'CASA - ', 'es'),
(134, 'PRODUCT_DISTANCE_5', '', 'es'),
(155, 'CENTER_NAME_4', '', 'ca'),
(156, 'CENTER_NAME_4', '', 'en'),
(157, 'CENTER_DESCRIPCION_4', 'CASA - ', 'es'),
(158, 'CENTER_DESCRIPCION_4', '', 'ca'),
(159, 'CENTER_DESCRIPCION_4', '', 'en'),
(160, 'CENTER_INFOWINDOW_4', '', 'es'),
(161, 'CENTER_INFOWINDOW_4', '', 'ca');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `log`
--

CREATE TABLE `log` (
  `ID` int(11) NOT NULL,
  `TYPE` varchar(100) COLLATE latin1_spanish_ci NOT NULL,
  `Operation` varchar(100) COLLATE latin1_spanish_ci NOT NULL,
  `Page` longtext COLLATE latin1_spanish_ci NOT NULL,
  `Entity` varchar(150) COLLATE latin1_spanish_ci NOT NULL,
  `Method` varchar(200) COLLATE latin1_spanish_ci NOT NULL,
  `Message` longtext COLLATE latin1_spanish_ci NOT NULL,
  `Date` datetime NOT NULL,
  `User` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

--
-- Volcado de datos para la tabla `log`
--

INSERT INTO `log` (`ID`, `TYPE`, `Operation`, `Page`, `Entity`, `Method`, `Message`, `Date`, `User`) VALUES
(1, 'ERROR', 'Loading Page', 'EditCenter.aspx', 'Center', 'FillCenter()', 'Unable to convert MySQL date/time value to System.DateTime', '0000-00-00 00:00:00', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pregunta`
--

CREATE TABLE `pregunta` (
  `ID` int(11) NOT NULL,
  `PREGUNTA_ID` int(11) DEFAULT NULL,
  `TIPO` varchar(50) COLLATE latin1_spanish_ci NOT NULL DEFAULT 'Test',
  `TEST_ID` int(11) DEFAULT NULL,
  `APARTADO` text COLLATE latin1_spanish_ci,
  `TEXTO` text COLLATE latin1_spanish_ci,
  `IMAGEN_URL` text COLLATE latin1_spanish_ci
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

--
-- Volcado de datos para la tabla `pregunta`
--

INSERT INTO `pregunta` (`ID`, `PREGUNTA_ID`, `TIPO`, `TEST_ID`, `APARTADO`, `TEXTO`, `IMAGEN_URL`) VALUES
(4, 3, 'Test', 1, 'Balizamiento', 'Pregunta 3', '~/Images/NoImage.jpg'),
(2, 2, 'Test', 1, 'Tecnologia naval', 'Texto pregunta 2', '~/Images/NoImage.jpg'),
(1, 1, 'Test', 1, 'Tecnologia naval', 'Texto pregunta 1', '~/Images/NoImage.jpg');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `product`
--

CREATE TABLE `product` (
  `id` int(11) NOT NULL,
  `category_id` int(11) DEFAULT NULL,
  `name_code` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `slug` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `description_code` longtext COLLATE utf8_unicode_ci,
  `created` datetime NOT NULL,
  `updated` datetime NOT NULL,
  `weight` int(11) NOT NULL,
  `price1` decimal(10,2) NOT NULL,
  `path` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `code` varchar(50) COLLATE utf8_unicode_ci NOT NULL,
  `distance_code` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `price2` decimal(10,2) NOT NULL,
  `price3` decimal(10,2) NOT NULL,
  `textdescrip_code` longtext COLLATE utf8_unicode_ci,
  `show_price` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Volcado de datos para la tabla `product`
--

INSERT INTO `product` (`id`, `category_id`, `name_code`, `slug`, `description_code`, `created`, `updated`, `weight`, `price1`, `path`, `code`, `distance_code`, `price2`, `price3`, `textdescrip_code`, `show_price`) VALUES
(1, 1, 'PRODUCT_NAME_1', 'patron-de-navegacion-basica', 'PRODUCT_DESCRIPTION_1', '2013-05-02 12:42:04', '2014-06-23 12:06:23', 10, '425.00', NULL, 'PNB', 'PRODUCT_DISTANCE_1', '0.00', '0.00', 'PRODUCT_TEXT_1', 0),
(2, 1, 'PRODUCT_NAME_2', 'patron-de-embarcaciones-de-recreo', 'PRODUCT_DESCRIPTION_2', '2013-05-02 12:44:00', '0000-00-00 00:00:00', 10, '420.00', NULL, 'PER', 'PRODUCT_DISTANCE_2', '0.00', '0.00', 'PRODUCT_TEXT_2', 0),
(3, 1, 'PRODUCT_NAME_3', 'patron-de-yate', 'PRODUCT_DESCRIPTION_3', '2013-05-02 12:45:19', '2014-06-23 12:07:57', 10, '950.00', NULL, 'PY', 'PRODUCT_DISTANCE_3', '540.00', '390.00', 'PRODUCT_TEXT_3', 0),
(4, 1, 'PRODUCT_NAME_4', 'capitan-de-yate', 'PRODUCT_DESCRIPTION_4\n', '2013-05-02 12:46:34', '0000-00-00 00:00:00', 10, '1700.00', NULL, 'CY', 'PRODUCT_DISTANCE_4', '600.00', '580.00', 'PRODUCT_TEXT_4', 0),
(5, 1, 'PRODUCT_NAME_5', 'licencia-de-navegación', 'PRODUCT_DESCRIPTION_5', '2015-04-27 00:00:00', '0000-00-00 00:00:00', 10, '0.00', NULL, 'LNA', 'PRODUCT_DISTANCE_5', '0.00', '0.00', 'PRODUCT_TEXT_5', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `respuesta`
--

CREATE TABLE `respuesta` (
  `ID` int(11) NOT NULL,
  `PREGUNTA_ID` int(11) DEFAULT NULL,
  `RESPUESTA_ID` int(11) DEFAULT NULL,
  `TEXTO` text COLLATE latin1_spanish_ci,
  `SOLUCION_CORRECTA` int(1) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

--
-- Volcado de datos para la tabla `respuesta`
--

INSERT INTO `respuesta` (`ID`, `PREGUNTA_ID`, `RESPUESTA_ID`, `TEXTO`, `SOLUCION_CORRECTA`) VALUES
(5, 2, 1, 'Respuesta 1', 0),
(1, 1, 1, 'Propulsor', 0),
(2, 1, 2, 'Ancla', 0),
(3, 1, 3, 'Hélice', 0),
(4, 1, 4, 'Timón', 1),
(6, 2, 2, 'Respuesta 2', 0),
(7, 2, 3, 'Respuesta 3', 1),
(8, 2, 4, 'Respuesta 4', 0),
(9, 3, 1, 'r1', 0),
(10, 3, 2, 'r2', 0),
(11, 3, 3, 'r3', 0),
(12, 3, 4, 'r4', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `test`
--

CREATE TABLE `test` (
  `ID` int(11) NOT NULL,
  `NOMBRE` text COLLATE latin1_spanish_ci,
  `CODIGO` text COLLATE latin1_spanish_ci,
  `TITULO` text COLLATE latin1_spanish_ci,
  `DESCRIPCION` text COLLATE latin1_spanish_ci,
  `CLAVE` text COLLATE latin1_spanish_ci,
  `ORIGEN` text COLLATE latin1_spanish_ci,
  `FIRMA` text COLLATE latin1_spanish_ci,
  `FECHA` date DEFAULT NULL,
  `NOTA_INSTRUCCIONES1` text COLLATE latin1_spanish_ci,
  `NOTA_INSTRUCCIONES2` text COLLATE latin1_spanish_ci,
  `NOTA_CABECERA` text COLLATE latin1_spanish_ci,
  `NOTA_PIE` text COLLATE latin1_spanish_ci,
  `PRODUCT_ID` int(11) DEFAULT NULL,
  `ACTIVE` bit(1) DEFAULT NULL,
  `CREATED` datetime DEFAULT NULL,
  `UPDATED` datetime DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

--
-- Volcado de datos para la tabla `test`
--

INSERT INTO `test` (`ID`, `NOMBRE`, `CODIGO`, `TITULO`, `DESCRIPCION`, `CLAVE`, `ORIGEN`, `FIRMA`, `FECHA`, `NOTA_INSTRUCCIONES1`, `NOTA_INSTRUCCIONES2`, `NOTA_CABECERA`, `NOTA_PIE`, `PRODUCT_ID`, `ACTIVE`, `CREATED`, `UPDATED`) VALUES
(1, 'EXAMEN TEORIC DE PATRO/ONA D`EMBARCACIONS D`ESBARJO REALITZAT EL DIA 19 DE JULIOL DE 2014', 'EX001', 'TITULO DEL xxxxxxxxxx', 'DESCRIPCIÓN DEL xxxxxxx', 'B0714PEE-1', 'Direccio General de Pesca i Afers Maritims', 'FIRMA', '2014-07-19', ' ', ' ', ' ', ' ', 1, b'1', '2014-11-05 01:54:00', '2018-04-22 00:56:57'),
(2, 'XXX', 'EX002', 'XXX', '  ', 'XXX', 'Direccio General de Pesca i Afers Maritims', ' ', '2014-07-19', ' ', ' ', ' ', ' ', 4, b'1', '2014-11-05 01:54:00', NULL),
(3, 'XXX', 'EX003', 'XXX', ' ', 'XXX', 'Direccio General de Pesca i Afers Maritims', ' ', '2014-07-19', ' ', ' ', ' ', ' ', 2, b'1', '2014-11-05 01:54:00', NULL),
(5, 'XXX', 'EX005', 'XXX', 'xxx', 'XXX', 'Direccio General de Pesca i Afers Maritims', 'Casa', '2014-07-19', ' ', ' ', ' ', ' ', 3, b'1', '2015-06-12 22:28:00', NULL),
(6, 'XXX', 'EX006', 'XXX', ' ', ' ', ' ', ' ', '2015-06-19', ' ', ' ', ' ', ' ', 3, b'1', '2015-06-12 22:31:03', NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `user_alumno`
--

CREATE TABLE `user_alumno` (
  `id` int(11) NOT NULL,
  `name` varchar(150) COLLATE latin1_spanish_ci DEFAULT NULL,
  `surname` varchar(150) COLLATE latin1_spanish_ci DEFAULT NULL,
  `birth_date` date DEFAULT NULL,
  `mail` varchar(50) COLLATE latin1_spanish_ci NOT NULL,
  `user_name` varchar(50) COLLATE latin1_spanish_ci NOT NULL,
  `password` varchar(50) COLLATE latin1_spanish_ci NOT NULL,
  `entered` int(11) DEFAULT NULL,
  `active` int(11) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  `updated` datetime DEFAULT NULL,
  `phone` int(11) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

--
-- Volcado de datos para la tabla `user_alumno`
--

INSERT INTO `user_alumno` (`id`, `name`, `surname`, `birth_date`, `mail`, `user_name`, `password`, `entered`, `active`, `created`, `updated`, `phone`) VALUES
(1, 'Alumno 1', ' ', '1987-07-15', 'mail@mail.com', 'David', '123', 0, 1, '2014-11-27 02:28:11', '2014-11-27 02:28:13', 635198891),
(3, 'Alumno 2', ' ', '1987-07-15', 'mail@mail.com', 'pepitopa', '123', 0, 1, '2015-06-13 23:09:37', '2015-06-14 00:33:58', 111);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario_gestor`
--

CREATE TABLE `usuario_gestor` (
  `ID` int(11) NOT NULL,
  `Login` varchar(50) COLLATE latin1_spanish_ci NOT NULL,
  `Password` varchar(150) COLLATE latin1_spanish_ci NOT NULL,
  `Nombre` varchar(150) COLLATE latin1_spanish_ci NOT NULL,
  `Apellidos` varchar(150) COLLATE latin1_spanish_ci NOT NULL,
  `email` varchar(150) COLLATE latin1_spanish_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COLLATE=latin1_spanish_ci;

--
-- Volcado de datos para la tabla `usuario_gestor`
--

INSERT INTO `usuario_gestor` (`ID`, `Login`, `Password`, `Nombre`, `Apellidos`, `email`) VALUES
(1, 'dgomezma@gmail.com', '123', 'David', 'S', 'dgomezma@gmail.com'),
(2, 'marta.s0511@gmail.com ', '123', 'Marta', '', 'marta.s0511@gmail.com ');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `UNIQ_64C19C1989D9B62` (`slug`);

--
-- Indices de la tabla `center`
--
ALTER TABLE `center`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `UNIQ_40F0EB24989D9B62` (`slug`);

--
-- Indices de la tabla `contact`
--
ALTER TABLE `contact`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `convocation`
--
ALTER TABLE `convocation`
  ADD PRIMARY KEY (`id`),
  ADD KEY `IDX_C03B3F5F4584665A` (`product_id`),
  ADD KEY `IDX_C03B3F5F5932F377` (`center_id`);

--
-- Indices de la tabla `featured`
--
ALTER TABLE `featured`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `literales`
--
ALTER TABLE `literales`
  ADD PRIMARY KEY (`ID`);

--
-- Indices de la tabla `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`ID`);

--
-- Indices de la tabla `pregunta`
--
ALTER TABLE `pregunta`
  ADD PRIMARY KEY (`ID`);

--
-- Indices de la tabla `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `UNIQ_D34A04AD989D9B62` (`slug`),
  ADD KEY `IDX_D34A04AD12469DE2` (`category_id`);

--
-- Indices de la tabla `respuesta`
--
ALTER TABLE `respuesta`
  ADD PRIMARY KEY (`ID`);

--
-- Indices de la tabla `test`
--
ALTER TABLE `test`
  ADD PRIMARY KEY (`ID`);

--
-- Indices de la tabla `user_alumno`
--
ALTER TABLE `user_alumno`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `usuario_gestor`
--
ALTER TABLE `usuario_gestor`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `category`
--
ALTER TABLE `category`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT de la tabla `center`
--
ALTER TABLE `center`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT de la tabla `contact`
--
ALTER TABLE `contact`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=336;
--
-- AUTO_INCREMENT de la tabla `convocation`
--
ALTER TABLE `convocation`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=134;
--
-- AUTO_INCREMENT de la tabla `featured`
--
ALTER TABLE `featured`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;
--
-- AUTO_INCREMENT de la tabla `literales`
--
ALTER TABLE `literales`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=163;
--
-- AUTO_INCREMENT de la tabla `log`
--
ALTER TABLE `log`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT de la tabla `product`
--
ALTER TABLE `product`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `convocation`
--
ALTER TABLE `convocation`
  ADD CONSTRAINT `FK_C03B3F5F4584665A` FOREIGN KEY (`product_id`) REFERENCES `product` (`id`),
  ADD CONSTRAINT `FK_C03B3F5F5932F377` FOREIGN KEY (`center_id`) REFERENCES `center` (`id`);

--
-- Filtros para la tabla `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `FK_D34A04AD12469DE2` FOREIGN KEY (`category_id`) REFERENCES `category` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
