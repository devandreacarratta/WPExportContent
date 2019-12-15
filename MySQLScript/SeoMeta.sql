

CREATE TABLE `SeoMeta` (
  `RowID` varchar(32) NOT NULL,
  `RowCreationDateUTC` datetime NOT NULL,
  `PostID` int(11) NOT NULL,
  `FocusKW` varchar(256) NOT NULL,
  `MetaDescription` varchar(1024) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

ALTER TABLE `SeoMeta`
  ADD PRIMARY KEY (`RowID`);
