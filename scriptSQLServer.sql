USE [dblistadesejos]
GO
/****** Object:  Table [dbo].[tbl_amigo]    Script Date: 28/03/2016 15:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_amigo](
	[id_amigo] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](max) NULL,
	[email] [varchar](max) NULL,
	[data_nascimento] [date] NULL,
 CONSTRAINT [PK_tbl_amigo] PRIMARY KEY CLUSTERED 
(
	[id_amigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_desejo]    Script Date: 28/03/2016 15:33:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_desejo](
	[id_desejo] [int] IDENTITY(1,1) NOT NULL,
	[id_amigo_solicitante] [int] NULL,
	[id_amigo_solicitado] [int] NULL,
	[data_desejo] [date] NULL,
	[valor] [money] NULL,
	[descricao_desejo] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_desejo] PRIMARY KEY CLUSTERED 
(
	[id_desejo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tbl_desejo]  WITH CHECK ADD  CONSTRAINT [FK_tbl_desejo_tbl_amigo_solicitado] FOREIGN KEY([id_amigo_solicitado])
REFERENCES [dbo].[tbl_amigo] ([id_amigo])
GO
ALTER TABLE [dbo].[tbl_desejo] CHECK CONSTRAINT [FK_tbl_desejo_tbl_amigo_solicitado]
GO
ALTER TABLE [dbo].[tbl_desejo]  WITH CHECK ADD  CONSTRAINT [FK_tbl_desejo_tbl_amigo_solicitante] FOREIGN KEY([id_amigo_solicitante])
REFERENCES [dbo].[tbl_amigo] ([id_amigo])
GO
ALTER TABLE [dbo].[tbl_desejo] CHECK CONSTRAINT [FK_tbl_desejo_tbl_amigo_solicitante]
GO
