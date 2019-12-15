CREATE TABLE `ContentCategories` (
  `RowID` varchar(32) NOT NULL,
  `RowCreationDateUTC` datetime NOT NULL,
  `IDContent` int(11) NOT NULL,
  `IDCategory` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

ALTER TABLE `ContentCategories`
  ADD PRIMARY KEY (`RowID`);