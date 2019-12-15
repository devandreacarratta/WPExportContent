
CREATE TABLE `Products` (
  `RowID` varchar(32) NOT NULL,
  `RowCreationDateUTC` datetime NOT NULL,
  `ID` int(11) NOT NULL,
  `PostAuthor` int(11) NOT NULL,
  `PostDate` datetime NOT NULL,
  `PostDateGTM` datetime NOT NULL,
  `PostContent` longtext NOT NULL,
  `PostTitle` varchar(256) NOT NULL,
  `PostExcerpt` longtext NOT NULL,
  `PostStatus` varchar(256) NOT NULL,
  `CommentStatus` varchar(256) NOT NULL,
  `PingStatus` varchar(256) NOT NULL,
  `PostPassword` varchar(256) NOT NULL,
  `PostName` varchar(256) NOT NULL,
  `ToPing` varchar(256) NOT NULL,
  `Pinged` varchar(256) NOT NULL,
  `PostModified` datetime NOT NULL,
  `PostModifiedGTM` datetime NOT NULL,
  `PostContentFiltered` varchar(256) NOT NULL,
  `PostParent` int(11) NOT NULL,
  `guid` varchar(1024) NOT NULL,
  `MenuOrder` int(11) NOT NULL,
  `PostType` varchar(256) NOT NULL,
  `PostMimeType` varchar(256) NOT NULL,
  `CommentCount` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

ALTER TABLE `Products`
  ADD PRIMARY KEY (`RowID`);
