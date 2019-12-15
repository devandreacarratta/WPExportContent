
CREATE TABLE `Tags` (
  `RowID` varchar(32) NOT NULL,
  `RowCreationDateUTC` datetime NOT NULL,
  `ID` int(11) NOT NULL,
  `Name` varchar(256) NOT NULL,
  `Slug` varchar(256) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

ALTER TABLE `Tags`
  ADD PRIMARY KEY (`RowID`);