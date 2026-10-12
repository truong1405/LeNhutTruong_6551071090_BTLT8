IF DB_ID(N'QuanCaPhe') IS NULL
BEGIN
    CREATE DATABASE QuanCaPhe;
END
GO

USE QuanCaPhe;
GO

-- Xóa bảng cũ nếu đã tồn tại (theo thứ tự khóa ngoại)
IF OBJECT_ID(N'dbo.ChiTietHoaDon', N'U') IS NOT NULL DROP TABLE dbo.ChiTietHoaDon;
IF OBJECT_ID(N'dbo.HoaDon',        N'U') IS NOT NULL DROP TABLE dbo.HoaDon;
IF OBJECT_ID(N'dbo.Mon',           N'U') IS NOT NULL DROP TABLE dbo.Mon;
GO

-- 1. Bảng Mon
CREATE TABLE dbo.Mon (
    MaMon    INT           NOT NULL CONSTRAINT PK_Mon PRIMARY KEY,
    TenMon   NVARCHAR(100) NOT NULL,
    NhomMon  NVARCHAR(30)  NOT NULL, -- Cà phê, Trà, Bánh, Nước đóng chai
    DonGia   DECIMAL(18,0) NOT NULL CONSTRAINT CK_Mon_DonGia CHECK (DonGia >= 0)
);
GO

-- 2. Bảng HoaDon
CREATE TABLE dbo.HoaDon (
    MaHD       INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_HoaDon PRIMARY KEY,
    NgayLap    DATETIME          NOT NULL,
    SoBan      INT               NOT NULL CONSTRAINT CK_HoaDon_SoBan CHECK (SoBan BETWEEN 1 AND 10),
    HinhThucTT NVARCHAR(20)      NOT NULL CONSTRAINT CK_HoaDon_HinhThucTT CHECK (HinhThucTT IN (N'Tiền mặt', N'Chuyển khoản')),
    GhiChu     NVARCHAR(200)     NULL
);
GO

-- 3. Bảng ChiTietHoaDon
CREATE TABLE dbo.ChiTietHoaDon (
    MaCT    INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY,
    MaHD    INT               NOT NULL CONSTRAINT FK_ChiTietHoaDon_HoaDon REFERENCES dbo.HoaDon(MaHD),
    MaMon   INT               NOT NULL CONSTRAINT FK_ChiTietHoaDon_Mon REFERENCES dbo.Mon(MaMon),
    SoLuong INT               NOT NULL CONSTRAINT CK_ChiTietHoaDon_SoLuong CHECK (SoLuong > 0),
    DonGia  DECIMAL(18,0)     NOT NULL CONSTRAINT CK_ChiTietHoaDon_DonGia CHECK (DonGia >= 0)
);
GO

/* =====================================================================
   DỮ LIỆU MẪU THEO ĐỀ BÀI
   ===================================================================== */

-- Bảng Mon (5 món)
INSERT INTO dbo.Mon (MaMon, TenMon, NhomMon, DonGia) VALUES
(1, N'Cà phê sữa đá',   N'Cà phê',          29000),
(2, N'Bạc xỉu',          N'Cà phê',          32000),
(3, N'Trà đào cam sả',   N'Trà',             45000),
(4, N'Bánh tiramisu',    N'Bánh',            39000),
(5, N'Nước suối',        N'Nước đóng chai',  12000);
GO

-- Bảng HoaDon (2 hóa đơn)
-- HD000001 (MaHD = 1): 09/10/2026 08:15, bàn 3, Tiền mặt
-- HD000002 (MaHD = 2): 09/10/2026 09:40, bàn 5, Chuyển khoản
SET IDENTITY_INSERT dbo.HoaDon ON;
INSERT INTO dbo.HoaDon (MaHD, NgayLap, SoBan, HinhThucTT, GhiChu) VALUES
(1, '2026-10-09 08:15:00', 3, N'Tiền mặt',       NULL),
(2, '2026-10-09 09:40:00', 5, N'Chuyển khoản',   NULL);
SET IDENTITY_INSERT dbo.HoaDon OFF;
GO

-- Bảng ChiTietHoaDon
-- HD000001: 2 Cà phê sữa đá, 1 Trà đào cam sả, 1 Bánh tiramisu
-- HD000002: 1 Bạc xỉu, 2 Nước suối
INSERT INTO dbo.ChiTietHoaDon (MaHD, MaMon, SoLuong, DonGia) VALUES
(1, 1, 2, 29000),
(1, 3, 1, 45000),
(1, 4, 1, 39000),
(2, 2, 1, 32000),
(2, 5, 2, 12000);
GO

-- Kiểm tra dữ liệu
SELECT * FROM dbo.Mon;
SELECT * FROM dbo.HoaDon;
SELECT ct.MaCT, ct.MaHD, m.TenMon, ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) AS ThanhTien
FROM dbo.ChiTietHoaDon ct
JOIN dbo.Mon m ON ct.MaMon = m.MaMon;
GO
