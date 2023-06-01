/****** Object:  Table [dbo].[Customer]    Script Date: 6/1/2023 2:10:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[customerId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[address] [varchar](80) NULL,
PRIMARY KEY CLUSTERED 
(
	[customerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO Customer VALUES ('anna', 'Jackie street'), 
('Anna', 'Blufberry road'), ('Keeley', 'Beech grove'), ('Jake', 'Second avenue'), ('Layla', 'Frustrique rue')


/******SQL Injective command used when prompting names
1.In band injection:*/
SELECT * FROM Customer WHERE name = 'anna' OR 1=1 --'

/*2.Union injection*/
SELECT * FROM Customer WHERE name = 'anna' UNION SELECT * FROM Customer --'



