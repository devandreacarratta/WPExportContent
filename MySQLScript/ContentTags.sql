CREATE TABLE `ContentTags` (
  `RowID` varchar(32) NOT NULL,
  `RowCreationDateUTC` datetime NOT NULL,
  `IDContent` int(11) NOT NULL,
  `IDTag` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

ALTER TABLE `ContentTags`
  ADD PRIMARY KEY (`RowID`);