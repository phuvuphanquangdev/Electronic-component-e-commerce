
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/31/2019 22:04:00
-- Generated from EDMX file: C:\Users\CopLun\Downloads\Website ban linh kien dien tu\MvcBanHang\MvcBanHang\Models\DB_BanHang.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BanHang];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_ctdonhang_donhang]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[chitiet_donhang] DROP CONSTRAINT [fk_ctdonhang_donhang];
GO
IF OBJECT_ID(N'[dbo].[fk_ctdonhang_sanpham]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[chitiet_donhang] DROP CONSTRAINT [fk_ctdonhang_sanpham];
GO
IF OBJECT_ID(N'[dbo].[fk_cthoadon_hoadon]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[chitiet_hoadon] DROP CONSTRAINT [fk_cthoadon_hoadon];
GO
IF OBJECT_ID(N'[dbo].[fk_cthoadon_sanpham]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[chitiet_hoadon] DROP CONSTRAINT [fk_cthoadon_sanpham];
GO
IF OBJECT_ID(N'[dbo].[fk_hoadon_khachhang]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[hoadon] DROP CONSTRAINT [fk_hoadon_khachhang];
GO
IF OBJECT_ID(N'[dbo].[fk_hoadon_nhanvien]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[hoadon] DROP CONSTRAINT [fk_hoadon_nhanvien];
GO
IF OBJECT_ID(N'[dbo].[fk_sanpham_macn]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sanpham] DROP CONSTRAINT [fk_sanpham_macn];
GO
IF OBJECT_ID(N'[dbo].[fk_sanpham_madl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sanpham] DROP CONSTRAINT [fk_sanpham_madl];
GO
IF OBJECT_ID(N'[dbo].[fk_sanpham_mahsx]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sanpham] DROP CONSTRAINT [fk_sanpham_mahsx];
GO
IF OBJECT_ID(N'[dbo].[fk_sanpham_maloai]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sanpham] DROP CONSTRAINT [fk_sanpham_maloai];
GO
IF OBJECT_ID(N'[dbo].[fk_sanpham_mancc]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sanpham] DROP CONSTRAINT [fk_sanpham_mancc];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[congnghe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[congnghe];
GO
IF OBJECT_ID(N'[dbo].[chitiet_donhang]', 'U') IS NOT NULL
    DROP TABLE [dbo].[chitiet_donhang];
GO
IF OBJECT_ID(N'[dbo].[chitiet_hoadon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[chitiet_hoadon];
GO
IF OBJECT_ID(N'[dbo].[donhang]', 'U') IS NOT NULL
    DROP TABLE [dbo].[donhang];
GO
IF OBJECT_ID(N'[dbo].[dungluong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[dungluong];
GO
IF OBJECT_ID(N'[dbo].[hangsanxuat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[hangsanxuat];
GO
IF OBJECT_ID(N'[dbo].[hoadon]', 'U') IS NOT NULL
    DROP TABLE [dbo].[hoadon];
GO
IF OBJECT_ID(N'[dbo].[khachhang]', 'U') IS NOT NULL
    DROP TABLE [dbo].[khachhang];
GO
IF OBJECT_ID(N'[dbo].[loai]', 'U') IS NOT NULL
    DROP TABLE [dbo].[loai];
GO
IF OBJECT_ID(N'[dbo].[nhacungcap]', 'U') IS NOT NULL
    DROP TABLE [dbo].[nhacungcap];
GO
IF OBJECT_ID(N'[dbo].[nhanvien]', 'U') IS NOT NULL
    DROP TABLE [dbo].[nhanvien];
GO
IF OBJECT_ID(N'[dbo].[quangcao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[quangcao];
GO
IF OBJECT_ID(N'[dbo].[sanpham]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sanpham];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'congnghe'
CREATE TABLE [dbo].[congnghe] (
    [macn] int IDENTITY(1,1) NOT NULL,
    [loaicn] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'chitiet_donhang'
CREATE TABLE [dbo].[chitiet_donhang] (
    [madh] int  NOT NULL,
    [masp] int  NOT NULL,
    [soluong] int  NULL,
    [thanhtien] decimal(19,4)  NULL
);
GO

-- Creating table 'chitiet_hoadon'
CREATE TABLE [dbo].[chitiet_hoadon] (
    [mahd] int  NOT NULL,
    [masp] int  NOT NULL,
    [soluong] int  NULL,
    [dongia] decimal(19,4)  NULL,
    [thanhtien] decimal(19,4)  NULL
);
GO

-- Creating table 'donhang'
CREATE TABLE [dbo].[donhang] (
    [madh] int IDENTITY(1,1) NOT NULL,
    [tennguoinhan] nvarchar(30)  NULL,
    [diachinhan] nvarchar(50)  NULL,
    [dienthoainhan] char(11)  NULL,
    [dagiao] bit  NULL
);
GO

-- Creating table 'dungluong'
CREATE TABLE [dbo].[dungluong] (
    [madl] int IDENTITY(1,1) NOT NULL,
    [loaidl] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'hangsanxuat'
CREATE TABLE [dbo].[hangsanxuat] (
    [mahsx] int IDENTITY(1,1) NOT NULL,
    [tenhsx] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'hoadon'
CREATE TABLE [dbo].[hoadon] (
    [mahd] int IDENTITY(1,1) NOT NULL,
    [makh] int  NOT NULL,
    [ngaydathang] datetime  NULL,
    [ngaygiaohang] datetime  NULL,
    [tennguoinhan] nvarchar(30)  NULL,
    [diachinhan] nvarchar(50)  NULL,
    [dienthoainhan] char(11)  NULL,
    [httt] bit  NULL,
    [htgh] bit  NULL,
    [manv] int  NOT NULL
);
GO

-- Creating table 'khachhang'
CREATE TABLE [dbo].[khachhang] (
    [makh] int IDENTITY(1,1) NOT NULL,
    [tenkh] nvarchar(30)  NOT NULL,
    [phai] nvarchar(3)  NOT NULL,
    [diachi] nvarchar(50)  NOT NULL,
    [email] char(50)  NULL,
    [dienthoai] char(11)  NOT NULL,
    [tenDN] nvarchar(max)  NOT NULL,
    [matkhau] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'loai'
CREATE TABLE [dbo].[loai] (
    [maloai] int IDENTITY(1,1) NOT NULL,
    [tenloai] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'nhacungcap'
CREATE TABLE [dbo].[nhacungcap] (
    [mancc] int IDENTITY(1,1) NOT NULL,
    [tenncc] nvarchar(30)  NULL,
    [diachi] nvarchar(max)  NULL,
    [dienthoai] char(11)  NULL
);
GO

-- Creating table 'nhanvien'
CREATE TABLE [dbo].[nhanvien] (
    [manv] int IDENTITY(1,1) NOT NULL,
    [tennv] nvarchar(30)  NOT NULL,
    [phai] nvarchar(3)  NOT NULL,
    [diachi] nvarchar(50)  NOT NULL,
    [cmnd] char(11)  NOT NULL,
    [dienthoai] char(11)  NOT NULL,
    [email] char(50)  NULL,
    [tenDN] nvarchar(max)  NULL,
    [matkhau] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'quangcao'
CREATE TABLE [dbo].[quangcao] (
    [stt] int IDENTITY(1,1) NOT NULL,
    [tencty] nvarchar(200)  NOT NULL,
    [hinhminhhoa] varchar(20)  NULL,
    [href] varchar(100)  NULL,
    [ngaybatdau] datetime  NULL,
    [ngayhethan] datetime  NULL
);
GO

-- Creating table 'sanpham'
CREATE TABLE [dbo].[sanpham] (
    [masp] int IDENTITY(1,1) NOT NULL,
    [tensp] nvarchar(50)  NULL,
    [hinhsp] char(50)  NULL,
    [mota] nvarchar(max)  NULL,
    [kichco] char(5)  NULL,
    [donvitinh] nvarchar(5)  NULL,
    [dongia] decimal(18,0)  NULL,
    [maloai] int  NOT NULL,
    [macn] int  NULL,
    [madl] int  NULL,
    [mancc] int  NOT NULL,
    [mahsx] int  NOT NULL,
    [ngaycapnhat] datetime  NULL,
    [soluong] int  NULL,
    [solanxem] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [macn] in table 'congnghe'
ALTER TABLE [dbo].[congnghe]
ADD CONSTRAINT [PK_congnghe]
    PRIMARY KEY CLUSTERED ([macn] ASC);
GO

-- Creating primary key on [madh], [masp] in table 'chitiet_donhang'
ALTER TABLE [dbo].[chitiet_donhang]
ADD CONSTRAINT [PK_chitiet_donhang]
    PRIMARY KEY CLUSTERED ([madh], [masp] ASC);
GO

-- Creating primary key on [mahd], [masp] in table 'chitiet_hoadon'
ALTER TABLE [dbo].[chitiet_hoadon]
ADD CONSTRAINT [PK_chitiet_hoadon]
    PRIMARY KEY CLUSTERED ([mahd], [masp] ASC);
GO

-- Creating primary key on [madh] in table 'donhang'
ALTER TABLE [dbo].[donhang]
ADD CONSTRAINT [PK_donhang]
    PRIMARY KEY CLUSTERED ([madh] ASC);
GO

-- Creating primary key on [madl] in table 'dungluong'
ALTER TABLE [dbo].[dungluong]
ADD CONSTRAINT [PK_dungluong]
    PRIMARY KEY CLUSTERED ([madl] ASC);
GO

-- Creating primary key on [mahsx] in table 'hangsanxuat'
ALTER TABLE [dbo].[hangsanxuat]
ADD CONSTRAINT [PK_hangsanxuat]
    PRIMARY KEY CLUSTERED ([mahsx] ASC);
GO

-- Creating primary key on [mahd] in table 'hoadon'
ALTER TABLE [dbo].[hoadon]
ADD CONSTRAINT [PK_hoadon]
    PRIMARY KEY CLUSTERED ([mahd] ASC);
GO

-- Creating primary key on [makh] in table 'khachhang'
ALTER TABLE [dbo].[khachhang]
ADD CONSTRAINT [PK_khachhang]
    PRIMARY KEY CLUSTERED ([makh] ASC);
GO

-- Creating primary key on [maloai] in table 'loai'
ALTER TABLE [dbo].[loai]
ADD CONSTRAINT [PK_loai]
    PRIMARY KEY CLUSTERED ([maloai] ASC);
GO

-- Creating primary key on [mancc] in table 'nhacungcap'
ALTER TABLE [dbo].[nhacungcap]
ADD CONSTRAINT [PK_nhacungcap]
    PRIMARY KEY CLUSTERED ([mancc] ASC);
GO

-- Creating primary key on [manv] in table 'nhanvien'
ALTER TABLE [dbo].[nhanvien]
ADD CONSTRAINT [PK_nhanvien]
    PRIMARY KEY CLUSTERED ([manv] ASC);
GO

-- Creating primary key on [stt] in table 'quangcao'
ALTER TABLE [dbo].[quangcao]
ADD CONSTRAINT [PK_quangcao]
    PRIMARY KEY CLUSTERED ([stt] ASC);
GO

-- Creating primary key on [masp] in table 'sanpham'
ALTER TABLE [dbo].[sanpham]
ADD CONSTRAINT [PK_sanpham]
    PRIMARY KEY CLUSTERED ([masp] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [macn] in table 'sanpham'
ALTER TABLE [dbo].[sanpham]
ADD CONSTRAINT [fk_sanpham_macn]
    FOREIGN KEY ([macn])
    REFERENCES [dbo].[congnghe]
        ([macn])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_sanpham_macn'
CREATE INDEX [IX_fk_sanpham_macn]
ON [dbo].[sanpham]
    ([macn]);
GO

-- Creating foreign key on [madh] in table 'chitiet_donhang'
ALTER TABLE [dbo].[chitiet_donhang]
ADD CONSTRAINT [fk_ctdonhang_donhang]
    FOREIGN KEY ([madh])
    REFERENCES [dbo].[donhang]
        ([madh])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [masp] in table 'chitiet_donhang'
ALTER TABLE [dbo].[chitiet_donhang]
ADD CONSTRAINT [fk_ctdonhang_sanpham]
    FOREIGN KEY ([masp])
    REFERENCES [dbo].[sanpham]
        ([masp])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_ctdonhang_sanpham'
CREATE INDEX [IX_fk_ctdonhang_sanpham]
ON [dbo].[chitiet_donhang]
    ([masp]);
GO

-- Creating foreign key on [mahd] in table 'chitiet_hoadon'
ALTER TABLE [dbo].[chitiet_hoadon]
ADD CONSTRAINT [fk_cthoadon_hoadon]
    FOREIGN KEY ([mahd])
    REFERENCES [dbo].[hoadon]
        ([mahd])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [masp] in table 'chitiet_hoadon'
ALTER TABLE [dbo].[chitiet_hoadon]
ADD CONSTRAINT [fk_cthoadon_sanpham]
    FOREIGN KEY ([masp])
    REFERENCES [dbo].[sanpham]
        ([masp])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_cthoadon_sanpham'
CREATE INDEX [IX_fk_cthoadon_sanpham]
ON [dbo].[chitiet_hoadon]
    ([masp]);
GO

-- Creating foreign key on [madl] in table 'sanpham'
ALTER TABLE [dbo].[sanpham]
ADD CONSTRAINT [fk_sanpham_madl]
    FOREIGN KEY ([madl])
    REFERENCES [dbo].[dungluong]
        ([madl])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_sanpham_madl'
CREATE INDEX [IX_fk_sanpham_madl]
ON [dbo].[sanpham]
    ([madl]);
GO

-- Creating foreign key on [mahsx] in table 'sanpham'
ALTER TABLE [dbo].[sanpham]
ADD CONSTRAINT [fk_sanpham_mahsx]
    FOREIGN KEY ([mahsx])
    REFERENCES [dbo].[hangsanxuat]
        ([mahsx])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_sanpham_mahsx'
CREATE INDEX [IX_fk_sanpham_mahsx]
ON [dbo].[sanpham]
    ([mahsx]);
GO

-- Creating foreign key on [makh] in table 'hoadon'
ALTER TABLE [dbo].[hoadon]
ADD CONSTRAINT [fk_hoadon_khachhang]
    FOREIGN KEY ([makh])
    REFERENCES [dbo].[khachhang]
        ([makh])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_hoadon_khachhang'
CREATE INDEX [IX_fk_hoadon_khachhang]
ON [dbo].[hoadon]
    ([makh]);
GO

-- Creating foreign key on [manv] in table 'hoadon'
ALTER TABLE [dbo].[hoadon]
ADD CONSTRAINT [fk_hoadon_nhanvien]
    FOREIGN KEY ([manv])
    REFERENCES [dbo].[nhanvien]
        ([manv])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_hoadon_nhanvien'
CREATE INDEX [IX_fk_hoadon_nhanvien]
ON [dbo].[hoadon]
    ([manv]);
GO

-- Creating foreign key on [maloai] in table 'sanpham'
ALTER TABLE [dbo].[sanpham]
ADD CONSTRAINT [fk_sanpham_maloai]
    FOREIGN KEY ([maloai])
    REFERENCES [dbo].[loai]
        ([maloai])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_sanpham_maloai'
CREATE INDEX [IX_fk_sanpham_maloai]
ON [dbo].[sanpham]
    ([maloai]);
GO

-- Creating foreign key on [mancc] in table 'sanpham'
ALTER TABLE [dbo].[sanpham]
ADD CONSTRAINT [fk_sanpham_mancc]
    FOREIGN KEY ([mancc])
    REFERENCES [dbo].[nhacungcap]
        ([mancc])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_sanpham_mancc'
CREATE INDEX [IX_fk_sanpham_mancc]
ON [dbo].[sanpham]
    ([mancc]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------