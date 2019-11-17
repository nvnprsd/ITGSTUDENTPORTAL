
CREATE TABLE [dbo].[CS2018Library](
	[Std_id] [varchar](50) NULL,
	[bookid] [varchar](50) NULL,
	[status] [varchar](50) NULL,
	[bookname] [varchar](50) NULL
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[issues](
	[msg] [varchar](300) NULL,
	[name] [varchar](50) NULL,
	[userid] [varchar](50) NULL,
	[target] [varchar](50) NULL,
	[date] [date] NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[ITGfaculty](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[prefix] [varchar](10) NULL,
	[Tech_id]  AS ([prefix]+right('000'+CONVERT([varchar](20),[id]),(20))) PERSISTED,
	[Name] [varchar](50) NULL,
	[dob] [date] NULL,
	[Fname] [varchar](50) NULL,
	[Mname] [varchar](50) NULL,
	[aadhar] [nchar](12) NULL,
	[mail] [varchar](50) NOT NULL,
	[mob] [nchar](10) NULL,
	[Dept] [varchar](20) NULL,
	[status] [varchar](20) NULL,
	[address] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[mail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ITGfaculty] ADD  DEFAULT ('Unverified') FOR [status]
GO



CREATE TABLE [dbo].[notice](
	[msg] [varchar](300) NULL,
	[sender] [varchar](50) NULL,
	[userid] [varchar](50) NULL,
	[target] [varchar](50) NULL,
	[date] [varchar](60) NULL,
	[expdate] [date] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[notice] ADD  DEFAULT (getdate()) FOR [date]
GO

CREATE TABLE [dbo].[CSgiveassignments](
	[sub_name] [varchar](50) NULL,
	[tchr_id] [varchar](50) NULL,
	[sem] [int] NULL,
	[duedate] [date] NULL,
	[as_path] [varchar](80) NULL
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[facultyLibrary](
	[Tech_id] [varchar](50) NULL,
	[bookid] [varchar](50) NULL,
	[status] [varchar](50) NULL,
	[bookname] [varchar](50) NULL
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[CSsubmittedassignments](
	[Std_id] [varchar](50) NULL,
	[sub_name] [varchar](50) NULL,
	[sem] [int] NULL,
	[submitdate] [date] NULL,
	[file_path] [varchar](80) NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[CSBooks](
	[bookid] [varchar](30) NULL,
	[bookname] [varchar](30) NULL,
	[Author_name] [varchar](50) NULL,
	[Copies] [tinyint] NULL,
	[Rem_Copies] [tinyint] NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[CS2018Att](
	[Std_id] [varchar](20) NULL,
	[Fname1] [varchar](50) NULL,
	[status1] [varchar](10) NULL,
	[Fname2] [varchar](50) NULL,
	[status2] [varchar](10) NULL,
	[Fname3] [varchar](50) NULL,
	[status3] [varchar](10) NULL,
	[Fname4] [varchar](50) NULL,
	[status4] [varchar](10) NULL,
	[Fname5] [varchar](50) NULL,
	[status5] [varchar](10) NULL,
	[Fname6] [varchar](50) NULL,
	[status6] [varchar](10) NULL,
	[Fname7] [varchar](50) NULL,
	[status7] [varchar](10) NULL,
	[Fname8] [varchar](50) NULL,
	[status8] [varchar](10) NULL,
	[date] [date] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CS2018Att] ADD  DEFAULT ('A') FOR [status1]
GO

ALTER TABLE [dbo].[CS2018Att] ADD  DEFAULT ('A') FOR [status2]
GO

ALTER TABLE [dbo].[CS2018Att] ADD  DEFAULT ('A') FOR [status3]
GO

ALTER TABLE [dbo].[CS2018Att] ADD  DEFAULT ('A') FOR [status4]
GO

ALTER TABLE [dbo].[CS2018Att] ADD  DEFAULT ('A') FOR [status5]
GO

ALTER TABLE [dbo].[CS2018Att] ADD  DEFAULT ('A') FOR [status6]
GO

ALTER TABLE [dbo].[CS2018Att] ADD  DEFAULT ('A') FOR [status7]
GO

ALTER TABLE [dbo].[CS2018Att] ADD  DEFAULT ('A') FOR [status8]
GO

ALTER TABLE [dbo].[CS2018Att] ADD  DEFAULT (CONVERT([date],getdate())) FOR [date]
GO


CREATE TABLE [dbo].[CS2018](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[prefix] [varchar](10) NULL,
	[Std_id]  AS ([prefix]+right('000'+CONVERT([varchar](20),[id]),(20))) PERSISTED,
	[Name] [varchar](50) NULL,
	[dob] [date] NULL,
	[Fname] [varchar](50) NULL,
	[Mname] [varchar](50) NULL,
	[aadhar] [nchar](12) NULL,
	[Address] [varchar](200) NULL,
	[mob] [numeric](10, 0) NOT NULL,
	[mail] [varchar](50) NOT NULL,
	[Interper] [varchar](10) NULL,
	[passedclg] [varchar](50) NULL,
	[passedyer] [nchar](4) NULL,
	[roll_no] [nchar](20) NULL,
	[status] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[mail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CS2018] ADD  DEFAULT ('CS2018') FOR [prefix]
GO

ALTER TABLE [dbo].[CS2018] ADD  DEFAULT ('Unverified') FOR [status]
GO




CREATE TABLE [dbo].[auth](
	[username] [varchar](50) NOT NULL,
	[mail] [varchar](30) NULL,
	[password] [varchar](50) NOT NULL,
	[utype] [varchar](50) NOT NULL,
	[name] [varchar](50) NULL,
	[dept] [varchar](50) NULL,
	[status] [varchar](20) NULL,
	[Cstatus] [varchar](20) NULL,
	[location] [varchar](20) NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[auth] ADD  DEFAULT ('Unverified') FOR [status]
GO

ALTER TABLE [dbo].[auth] ADD  DEFAULT ('Free') FOR [Cstatus]
GO



CREATE TABLE [dbo].[attcal](
	[name] [varchar](30) NULL,
	[std_id] [varchar](30) NULL,
	[fname1] [varchar](30) NULL,
	[TC1] [tinyint] NULL,
	[TP1] [tinyint] NULL,
	[fname2] [varchar](30) NULL,
	[TC2] [tinyint] NULL,
	[TP2] [tinyint] NULL,
	[fname3] [varchar](30) NULL,
	[TC3] [tinyint] NULL,
	[TP3] [tinyint] NULL,
	[fname4] [varchar](30) NULL,
	[TC4] [tinyint] NULL,
	[TP4] [tinyint] NULL,
	[fname5] [varchar](30) NULL,
	[TC5] [tinyint] NULL,
	[TP5] [tinyint] NULL,
	[fname6] [varchar](30) NULL,
	[TC6] [tinyint] NULL,
	[TP6] [tinyint] NULL
) ON [PRIMARY]

GO

