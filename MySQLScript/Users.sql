
CREATE TABLE `Users` (
  `RowID` varchar(32) NOT NULL,
  `RowCreationDateUTC` int(11) NOT NULL,
  `ID` int(11) NOT NULL,
  `UserName` varchar(1024) NOT NULL,
  `UserPassword` varchar(1024) NOT NULL,
  `UserNicename` varchar(1024) NOT NULL,
  `UserEmail` varchar(1024) NOT NULL,
  `UserUrl` varchar(1024) NOT NULL,
  `UserRegistered` datetime NOT NULL,
  `UserActivationKey` varchar(1024) NOT NULL,
  `UserStatus` varchar(1024) NOT NULL,
  `DisplayName` varchar(1024) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

ALTER TABLE `Users`
  ADD PRIMARY KEY (`RowID`);