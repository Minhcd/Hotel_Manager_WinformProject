USE [QuanLyKS]
GO
/****** Object:  Table [dbo].[DichVuPhong]    Script Date: 6/10/2018 4:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVuPhong](
	[MaDV] [nvarchar](10) NOT NULL,
	[TenDV] [nvarchar](100) NOT NULL,
	[GiaDV] [float] NOT NULL,
	[DVT] [nvarchar](100) NOT NULL,
 CONSTRAINT [pk_DichVu] PRIMARY KEY CLUSTERED 
(
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/10/2018 4:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[CMND] [nvarchar](12) NOT NULL,
	[HoTen] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[GioiTinh] [nvarchar](100) NOT NULL,
	[SDT] [varchar](25) NULL,
	[ThanhToan] [nvarchar](200) NULL,
 CONSTRAINT [pk_KhachHang] PRIMARY KEY CLUSTERED 
(
	[CMND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhongKS]    Script Date: 6/10/2018 4:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongKS](
	[MaPhong] [nvarchar](10) NOT NULL,
	[TenPhong] [nvarchar](269) NOT NULL,
	[LoaiPhong] [nvarchar](25) NOT NULL,
	[GiaPhong] [float] NOT NULL,
	[TinhTrang] [nvarchar](25) NOT NULL,
 CONSTRAINT [pk_PhongKS] PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SDDVPhong]    Script Date: 6/10/2018 4:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SDDVPhong](
	[MaHoaDonDV] [int] IDENTITY(1,1) NOT NULL,
	[CMND] [nvarchar](12) NOT NULL,
	[MaDV] [nvarchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[NgaySD] [datetime] NULL,
	[MaPhong] [nvarchar](10) NOT NULL,
	[TenDV] [nvarchar](200) NULL,
	[TongTienDV] [float] NULL,
	[ThanhToan] [char](200) NULL,
 CONSTRAINT [pk_SDDV] PRIMARY KEY CLUSTERED 
(
	[MaHoaDonDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaiKhoanNV]    Script Date: 6/10/2018 4:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoanNV](
	[Account] [nvarchar](100) NOT NULL,
	[Pass] [nvarchar](100) NOT NULL,
	[TenND] [nvarchar](100) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[GioiTinh] [nvarchar](100) NOT NULL,
	[SDT] [varchar](25) NOT NULL,
	[NgaySinhNV] [date] NOT NULL,
	[ChucVu] [nvarchar](200) NULL,
 CONSTRAINT [pk_TaiKhoanNV] PRIMARY KEY CLUSTERED 
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThuePhong]    Script Date: 6/10/2018 4:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThuePhong](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[CMND] [nvarchar](12) NOT NULL,
	[MaPhong] [nvarchar](10) NOT NULL,
	[Ngayden] [datetime] NULL,
	[Ngaydi] [datetime] NULL,
	[TenNV] [nvarchar](100) NOT NULL,
	[ThanhToan] [varchar](200) NULL,
	[HotenKH] [nvarchar](200) NULL,
	[GiaPhong] [float] NULL,
 CONSTRAINT [pk_ThuePhong] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThuNhap]    Script Date: 6/10/2018 4:07:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuNhap](
	[MaTN] [int] IDENTITY(1,1) NOT NULL,
	[CMND] [nvarchar](200) NULL,
	[TenKH] [nvarchar](200) NULL,
	[Ngayden] [datetime] NULL,
	[Ngaydi] [datetime] NULL,
	[TienTT] [float] NULL,
 CONSTRAINT [pk_ThuNhap] PRIMARY KEY CLUSTERED 
(
	[MaTN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[DichVuPhong] ([MaDV], [TenDV], [GiaDV], [DVT]) VALUES (N'DV001', N'Nước lọc Lavi', 6000, N'chai')
INSERT [dbo].[DichVuPhong] ([MaDV], [TenDV], [GiaDV], [DVT]) VALUES (N'DV002', N'Coca Cola', 10000, N'lon')
INSERT [dbo].[DichVuPhong] ([MaDV], [TenDV], [GiaDV], [DVT]) VALUES (N'DV003', N'Trà ô long', 12000, N'chai')
INSERT [dbo].[DichVuPhong] ([MaDV], [TenDV], [GiaDV], [DVT]) VALUES (N'DV004', N'Bia 333', 12000, N'lon')
INSERT [dbo].[DichVuPhong] ([MaDV], [TenDV], [GiaDV], [DVT]) VALUES (N'DV005', N'Thuốc lá 3 số', 10000, N'10000')
INSERT [dbo].[DichVuPhong] ([MaDV], [TenDV], [GiaDV], [DVT]) VALUES (N'DV006', N'Bánh mì ốp la', 15000, N'15000')
INSERT [dbo].[KhachHang] ([CMND], [HoTen], [DiaChi], [GioiTinh], [SDT], [ThanhToan]) VALUES (N'012050033', N'Lê Công Vinh', N'03 Lý Chính Thắng', N'Nam', N'0122040506', N'Ðã thanh toán')
INSERT [dbo].[KhachHang] ([CMND], [HoTen], [DiaChi], [GioiTinh], [SDT], [ThanhToan]) VALUES (N'012754863', N'Quách Thạch Vũ', N'05 Sư Vạn Hành', N'Nam', N'0124056321', N'Chưa thanh toán')
INSERT [dbo].[KhachHang] ([CMND], [HoTen], [DiaChi], [GioiTinh], [SDT], [ThanhToan]) VALUES (N'021033056', N'Phan Tài Em', N'05 Lý Chính Thắng', N'Nam', N'0908123456', N'Chưa thanh toán')
INSERT [dbo].[KhachHang] ([CMND], [HoTen], [DiaChi], [GioiTinh], [SDT], [ThanhToan]) VALUES (N'025852369', N'Trần Nhân Trí', N'42/23 Nguyễn Chí Thanh', N'Nam', N'0123457863', N'Chưa thanh toán')
INSERT [dbo].[KhachHang] ([CMND], [HoTen], [DiaChi], [GioiTinh], [SDT], [ThanhToan]) VALUES (N'052042124', N'Lê Huỳnh Đức', N'03 Nguyễn Kiệm', N'Nam', N'0908147258', N'Chưa thanh toán')
INSERT [dbo].[KhachHang] ([CMND], [HoTen], [DiaChi], [GioiTinh], [SDT], [ThanhToan]) VALUES (N'123055789', N'Nguyễn Xuân Phúc', N'08 Phạm Ngũ Lão', N'Nam', N'0147258369', N'Chưa thanh toán')
INSERT [dbo].[KhachHang] ([CMND], [HoTen], [DiaChi], [GioiTinh], [SDT], [ThanhToan]) VALUES (N'231159368', N'Nguyễn Quang Hải', N'124 Nguyễn Huệ', N'Nam', N'0904325369', N'Chưa thanh toán')
INSERT [dbo].[PhongKS] ([MaPhong], [TenPhong], [LoaiPhong], [GiaPhong], [TinhTrang]) VALUES (N'T001', N'PT001', N'Thường đơn', 100000, N'Có khách')
INSERT [dbo].[PhongKS] ([MaPhong], [TenPhong], [LoaiPhong], [GiaPhong], [TinhTrang]) VALUES (N'T002', N'PT002', N'Thường đơn', 100000, N'Trống')
INSERT [dbo].[PhongKS] ([MaPhong], [TenPhong], [LoaiPhong], [GiaPhong], [TinhTrang]) VALUES (N'TD001', N'PTD001', N'Thường đôi', 150000, N'Có khách')
INSERT [dbo].[PhongKS] ([MaPhong], [TenPhong], [LoaiPhong], [GiaPhong], [TinhTrang]) VALUES (N'V001', N'PV001', N' Vip đơn', 300000, N'Có khách')
INSERT [dbo].[PhongKS] ([MaPhong], [TenPhong], [LoaiPhong], [GiaPhong], [TinhTrang]) VALUES (N'V002', N'PV002', N'Vip đơn', 300000, N'Trống')
INSERT [dbo].[PhongKS] ([MaPhong], [TenPhong], [LoaiPhong], [GiaPhong], [TinhTrang]) VALUES (N'VD001', N'PVD001', N'Vip đôi', 500000, N'Có khách')
INSERT [dbo].[PhongKS] ([MaPhong], [TenPhong], [LoaiPhong], [GiaPhong], [TinhTrang]) VALUES (N'VD002', N'PVD002', N'Vip đôi', 500000, N'Trống')
SET IDENTITY_INSERT [dbo].[SDDVPhong] ON 

INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (1, N'012344789', N'DV002', 2, CAST(0x0000A8DA00000000 AS DateTime), N'V001', N'Coca Cola', 20000, N'Ðã thanh toán                                                                                                                                                                                           ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (2, N'079113486', N'DV003', 5, CAST(0x0000A8D800000000 AS DateTime), N'T001', N'Trà ô long', 60000, N'Ðã thanh toán                                                                                                                                                                                           ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (5, N'012050033', N'DV002', 3, CAST(0x0000A8F2018B469D AS DateTime), N'TD001', N'Coca Cola', 30000, N'Ðã thanh toán                                                                                                                                                                                           ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (11, N'012033655', N'DV001', 3, CAST(0x0000A8F300C4010B AS DateTime), N'V002', N'Nước lọc Lavi', 18000, N'Ðã thanh toán                                                                                                                                                                                           ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (12, N'012033655', N'DV003', 3, CAST(0x0000A8F300E64296 AS DateTime), N'V002', N'Trà ô long', 36000, N'Chua thanh toán                                                                                                                                                                                         ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (13, N'012050033', N'DV001', 2, CAST(0x0000A8F300E64296 AS DateTime), N'TD001', N'Nước lọc Lavi', 12000, N'Chua thanh toán                                                                                                                                                                                         ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (14, N'023010055', N'DV004', 5, CAST(0x0000A8F40140DCD5 AS DateTime), N'VD001', N'Bia 333', 60000, N'Ðã thanh toán                                                                                                                                                                                           ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (15, N'052042124', N'DV004', 10, CAST(0x0000A8F80143D280 AS DateTime), N'V002', N'Bia 333', 120000, N'Ðã thanh toán                                                                                                                                                                                           ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (16, N'023010055', N'DV003', 10, CAST(0x0000A8F80143D280 AS DateTime), N'VD001', N'Trà ô long', 120000, N'Chua thanh toán                                                                                                                                                                                         ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (17, N'052042124', N'DV005', 3, CAST(0x0000A8F8016164C6 AS DateTime), N'V002', N'Thuốc lá 3 số', 30000, N'Chua thanh toán                                                                                                                                                                                         ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (18, N'012754863', N'DV006', 2, CAST(0x0000A8F80169D264 AS DateTime), N'V001', N'Bánh mì ốp la', 30000, N'Chua thanh toán                                                                                                                                                                                         ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (19, N'012754863', N'DV001', 2, CAST(0x0000A8F80169D264 AS DateTime), N'V001', N'Nước lọc Lavi', 12000, N'Chua thanh toán                                                                                                                                                                                         ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (20, N'012754863', N'DV005', 1, CAST(0x0000A8F80169D264 AS DateTime), N'V001', N'Thuốc lá 3 số', 10000, N'Chua thanh toán                                                                                                                                                                                         ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (21, N'123055789', N'DV003', 6, CAST(0x0000A8FA00A6CE8D AS DateTime), N'T002', N'Trà ô long', 72000, N'Ðã thanh toán                                                                                                                                                                                           ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (22, N'123055789', N'DV004', 2, CAST(0x0000A8FA00A6CE8D AS DateTime), N'T002', N'Bia 333', 24000, N'Chua thanh toán                                                                                                                                                                                         ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (23, N'021033056', N'DV001', 2, CAST(0x0000A8FB00D8B704 AS DateTime), N'T001', N'Nước lọc Lavi', 12000, N'Chua thanh toán                                                                                                                                                                                         ')
INSERT [dbo].[SDDVPhong] ([MaHoaDonDV], [CMND], [MaDV], [SoLuong], [NgaySD], [MaPhong], [TenDV], [TongTienDV], [ThanhToan]) VALUES (24, N'021033056', N'DV006', 1, CAST(0x0000A8FB00D8B704 AS DateTime), N'T001', N'Bánh mì ốp la', 15000, N'Chua thanh toán                                                                                                                                                                                         ')
SET IDENTITY_INSERT [dbo].[SDDVPhong] OFF
INSERT [dbo].[TaiKhoanNV] ([Account], [Pass], [TenND], [DiaChi], [GioiTinh], [SDT], [NgaySinhNV], [ChucVu]) VALUES (N'admin', N'minhcd', N'Cao Đức Minh', N'413/22 Phan Huy Ích', N'Nam', N'01229534794', CAST(0x7C220B00 AS Date), N'Quản lý')
INSERT [dbo].[TaiKhoanNV] ([Account], [Pass], [TenND], [DiaChi], [GioiTinh], [SDT], [NgaySinhNV], [ChucVu]) VALUES (N'nv001', N'001', N'Nguyễn Cát Tường', N'123 Thích Quãng Đức', N'Nam', N'04130879846', CAST(0xCA210B00 AS Date), N'Nhân viên')
INSERT [dbo].[TaiKhoanNV] ([Account], [Pass], [TenND], [DiaChi], [GioiTinh], [SDT], [NgaySinhNV], [ChucVu]) VALUES (N'nv002', N'002', N'Đàm Nhật Phong', N'4/2 Quang Trung', N'Nam', N'01269532326', CAST(0x3C200B00 AS Date), N'Nhân viên')
INSERT [dbo].[TaiKhoanNV] ([Account], [Pass], [TenND], [DiaChi], [GioiTinh], [SDT], [NgaySinhNV], [ChucVu]) VALUES (N'nv003', N'003', N'Minh Vương', N'03 Hai Bà Trưng', N'Nam', N'0649623081', CAST(0x9A220B00 AS Date), N'Nhân viên')
INSERT [dbo].[TaiKhoanNV] ([Account], [Pass], [TenND], [DiaChi], [GioiTinh], [SDT], [NgaySinhNV], [ChucVu]) VALUES (N'nv004', N'004', N'Điêu thuyền', N'02 Đồng Đen', N'Nữ', N'01276139417', CAST(0x90220B00 AS Date), N'Nhân viên')
SET IDENTITY_INSERT [dbo].[ThuePhong] ON 

INSERT [dbo].[ThuePhong] ([MaHoaDon], [CMND], [MaPhong], [Ngayden], [Ngaydi], [TenNV], [ThanhToan], [HotenKH], [GiaPhong]) VALUES (1, N'012344789', N'V001', CAST(0x0000A8D900000000 AS DateTime), CAST(0x0000A8F4013ED029 AS DateTime), N'Tường', N'Ðã thanh toán', N'Minh Cao', 300000)
INSERT [dbo].[ThuePhong] ([MaHoaDon], [CMND], [MaPhong], [Ngayden], [Ngaydi], [TenNV], [ThanhToan], [HotenKH], [GiaPhong]) VALUES (2, N'079113486', N'T001', CAST(0x0000A8D700000000 AS DateTime), CAST(0x0000A8F300F89BF0 AS DateTime), N'Tường', N'Ðã thanh toán', N'Cao Hà', 100000)
INSERT [dbo].[ThuePhong] ([MaHoaDon], [CMND], [MaPhong], [Ngayden], [Ngaydi], [TenNV], [ThanhToan], [HotenKH], [GiaPhong]) VALUES (6, N'012050033', N'TD001', CAST(0x0000A8F000000000 AS DateTime), CAST(0x0000A8F801428CEB AS DateTime), N'Cao Đức Minh', N'Ðã thanh toán', N'Lê Công Vinh', 150000)
INSERT [dbo].[ThuePhong] ([MaHoaDon], [CMND], [MaPhong], [Ngayden], [Ngaydi], [TenNV], [ThanhToan], [HotenKH], [GiaPhong]) VALUES (8, N'012033655', N'V002', CAST(0x0000A8F300C1F903 AS DateTime), CAST(0x0000A8F4013EE88D AS DateTime), N'Cao Đức Minh', N'Ðã thanh toán', N'Nguyễn Công Phượng', 300000)
INSERT [dbo].[ThuePhong] ([MaHoaDon], [CMND], [MaPhong], [Ngayden], [Ngaydi], [TenNV], [ThanhToan], [HotenKH], [GiaPhong]) VALUES (9, N'023010055', N'VD001', CAST(0x0000A8F4013F548E AS DateTime), CAST(0x0000A8F80144461E AS DateTime), N'Cao Đức Minh', N'Ðã thanh toán', N'Trần Đại Quang', 500000)
INSERT [dbo].[ThuePhong] ([MaHoaDon], [CMND], [MaPhong], [Ngayden], [Ngaydi], [TenNV], [ThanhToan], [HotenKH], [GiaPhong]) VALUES (10, N'123055789', N'T002', CAST(0x0000A8F401422CFF AS DateTime), CAST(0x0000A8FA00A77A7A AS DateTime), N'Đàm Nhật Phong', N'Ðã thanh toán', N'Nguyễn Xuân Phúc', 100000)
INSERT [dbo].[ThuePhong] ([MaHoaDon], [CMND], [MaPhong], [Ngayden], [Ngaydi], [TenNV], [ThanhToan], [HotenKH], [GiaPhong]) VALUES (11, N'052042124', N'V002', CAST(0x0000A8F8014223B2 AS DateTime), CAST(0x0000A8FB010346A5 AS DateTime), N'Cao Đức Minh', N'Ðã thanh toán', N'Lê Huỳnh Đức', 300000)
INSERT [dbo].[ThuePhong] ([MaHoaDon], [CMND], [MaPhong], [Ngayden], [Ngaydi], [TenNV], [ThanhToan], [HotenKH], [GiaPhong]) VALUES (12, N'012754863', N'V001', CAST(0x0000A8F801690210 AS DateTime), NULL, N'Cao Đức Minh', N'Chua thanh toán', N'Quách Thạch Vũ', 300000)
INSERT [dbo].[ThuePhong] ([MaHoaDon], [CMND], [MaPhong], [Ngayden], [Ngaydi], [TenNV], [ThanhToan], [HotenKH], [GiaPhong]) VALUES (13, N'231159368', N'TD001', CAST(0x0000A8F8016A5D5C AS DateTime), NULL, N'Cao Đức Minh', N'Chua thanh toán', N'Nguyễn Quang Hải', 150000)
INSERT [dbo].[ThuePhong] ([MaHoaDon], [CMND], [MaPhong], [Ngayden], [Ngaydi], [TenNV], [ThanhToan], [HotenKH], [GiaPhong]) VALUES (14, N'021033056', N'T001', CAST(0x0000A8FA00A610D4 AS DateTime), NULL, N'Đàm Nhật Phong', N'Chua thanh toán', N'Phan Tài Em', 100000)
INSERT [dbo].[ThuePhong] ([MaHoaDon], [CMND], [MaPhong], [Ngayden], [Ngaydi], [TenNV], [ThanhToan], [HotenKH], [GiaPhong]) VALUES (15, N'025852369', N'VD001', CAST(0x0000A8FB0102A4F3 AS DateTime), NULL, N'Nguyễn Cát Tường', N'Chua thanh toán', N'Trần Nhân Trí', 500000)
SET IDENTITY_INSERT [dbo].[ThuePhong] OFF
SET IDENTITY_INSERT [dbo].[ThuNhap] ON 

INSERT [dbo].[ThuNhap] ([MaTN], [CMND], [TenKH], [Ngayden], [Ngaydi], [TienTT]) VALUES (1, N'079113486', N'Cao Hà', CAST(0x0000A8D700000000 AS DateTime), CAST(0x0000A8F300F89BF5 AS DateTime), 3047500)
INSERT [dbo].[ThuNhap] ([MaTN], [CMND], [TenKH], [Ngayden], [Ngaydi], [TienTT]) VALUES (2, N'012344789', N'Minh Cao', CAST(0x0000A8D900000000 AS DateTime), CAST(0x0000A8F4013ED02C AS DateTime), 8832500)
INSERT [dbo].[ThuNhap] ([MaTN], [CMND], [TenKH], [Ngayden], [Ngaydi], [TienTT]) VALUES (3, N'012033655', N'Nguyễn Công Phượng', CAST(0x0000A8F300C1F7DC AS DateTime), CAST(0x0000A8F4013EE88D AS DateTime), 636500)
INSERT [dbo].[ThuNhap] ([MaTN], [CMND], [TenKH], [Ngayden], [Ngaydi], [TienTT]) VALUES (4, N'012050033', N'Lê Công Vinh', CAST(0x0000A8F000000000 AS DateTime), CAST(0x0000A8F801428CEB AS DateTime), 1598250)
INSERT [dbo].[ThuNhap] ([MaTN], [CMND], [TenKH], [Ngayden], [Ngaydi], [TienTT]) VALUES (5, N'023010055', N'Trần Đại Quang', CAST(0x0000A8F4013F53A8 AS DateTime), CAST(0x0000A8F801444621 AS DateTime), 2420000)
INSERT [dbo].[ThuNhap] ([MaTN], [CMND], [TenKH], [Ngayden], [Ngaydi], [TienTT]) VALUES (6, N'123055789', N'Nguyễn Xuân Phúc', CAST(0x0000A8F401422C90 AS DateTime), CAST(0x0000A8FA00A77A7A AS DateTime), 907000)
INSERT [dbo].[ThuNhap] ([MaTN], [CMND], [TenKH], [Ngayden], [Ngaydi], [TienTT]) VALUES (7, N'052042124', N'Lê Huỳnh Đức', CAST(0x0000A8F801422330 AS DateTime), CAST(0x0000A8FB010346A5 AS DateTime), 1796000)
SET IDENTITY_INSERT [dbo].[ThuNhap] OFF
ALTER TABLE [dbo].[SDDVPhong]  WITH CHECK ADD FOREIGN KEY([MaDV])
REFERENCES [dbo].[DichVuPhong] ([MaDV])
GO
