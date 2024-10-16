CREATE DATABASE BanDienThoai_New
GO
USE BanDienThoai_New
GO

CREATE TABLE TAIKHOAN_ADMIN
(
	ID_ADMIN INT IDENTITY(1,1),
	MA_ADMIN VARCHAR(20) PRIMARY KEY,
	EMAIL_ADMIN NVARCHAR(100),
	MATKHAU_ADMIN NVARCHAR(50)
)
GO

SELECT * FROM TAIKHOAN_ADMIN
WHERE EMAIL_ADMIN = 'admin@gmail.com' AND MATKHAU_ADMIN = '123'

INSERT INTO TAIKHOAN_ADMIN 
VALUES ('AD_0001', 'admin@gmail.com', '123')




CREATE TABLE TAIKHOAN_NGUOIDUNG
(
	ID_NGUOIDUNG INT IDENTITY(1,1),
	MA_NGUOIDUNG VARCHAR(20) PRIMARY KEY,
	EMAIL_NGUOIDUNG NVARCHAR(100),
	MATKHAU_NGUOIDUNG NVARCHAR(50)
)
GO
select * from TAIKHOAN_NGUOIDUNG
INSERT INTO TAIKHOAN_NGUOIDUNG
VALUES('ND_0001', 'nguoidung@gmail.com', '123')

select * from SANPHAM
order by MA_SANPHAM
CREATE TABLE SANPHAM
(
	ID_SANPHAM INT IDENTITY(1,1),
	MA_SANPHAM VARCHAR(20) PRIMARY KEY,
	TEN_SANPHAM NVARCHAR(100),
	HINH_SANPHAM NVARCHAR(100),
	SOLUONG_SANPHAM INT,
	GIA_SANPHAM FLOAT,
	TINHTRANG_SANPHAM NVARCHAR(50), --CÒN HÀNG, HẾT HÀNG
	MOTA_SANPHAM NVARCHAR(500),
	MA_ADMIN VARCHAR(20)
)
GO
DELETE FROM SANPHAM;

INSERT INTO SANPHAM
VALUES 
('SP_0001', N'Galaxy Z Flip6', '/LayoutElectronic/img/featured/featuredt-1.jpg', 20, 100, N'Còn hàng', N'Galaxy Z Flip 6 Chụp hình mọi góc cạnh không đẹp không lấy tiền', 'AD_0001'),
('SP_0002', N'Laptop Asus Vivobook', '/LayoutElectronic/img/featured/featuredt-2.jpg', 10, 500, N'Còn hàng', N'Laptop Asus Vivobook SSD: 512, RAM 8GB bao mạnh luôn nè ', 'AD_0001'),
('SP_0003', N'Apple Watch', '/LayoutElectronic/img/featured/featuredt-3.jpg', 20, 100, N'Còn hàng', N'Apple Watch nhiều tính năng thông minh kết nối với điện thoại', 'AD_0001'),
('SP_0004', N'Galaxy Tab S10 Ultra', '/LayoutElectronic/img/featured/featuredt-4.jpg', 50, 75, N'Còn hàng', N'Galaxy Tab S10 Ultra Chụp quay video góc rộng', 'AD_0001'),
('SP_0005', N'Tablet', '/LayoutElectronic/img/featured/featuredt-5.jpg', 3, 120, N'Còn hàng', N'Tablet coi Youtube, nghe nhac, chơi games đồ họa sắc nét', 'AD_0001'),
('SP_0006', N'Galaxy M15 5G', '/LayoutElectronic/img/featured/featuredt-6.jpg', 79, 110, N'Còn hàng', N'Galaxy M15 5G Chụp quay video góc rộng', 'AD_0001'),
('SP_0007', N'Oppo A3X', '/LayoutElectronic/img/featured/featuredt-7.jpg', 0, 50, N'Hết hàng', N'Oppo A3X Chụp hình cùng Sơn Tùng', 'AD_0001'),
('SP_0008', N'Chuột Logitech', '/LayoutElectronic/img/featured/featuredt-11.jpg', 100, 90, N'Còn hàng', N'Click đến khi tay không còn', 'AD_0001'),
('SP_0009', N'Laptop Acer', '/LayoutElectronic/img/featured/featuredt-8.jpg', 40, 900, N'Còn hàng', N'Laptop Acer Chơi games bao đã liên minh bao bay', 'AD_0001'),
('SP_0010', N'Iphone 13 Promax', '/LayoutElectronic/img/featured/featuredt-9.jpg', 10, 200, N'Còn hàng', N'Iphone 13 Promax Giá đắt lắm đừng mua tốn tiền', 'AD_0001'),
('SP_0011', N'Tablet TCP', '/LayoutElectronic/img/featured/featuredt-10.jpg', 7, 140, N'Còn hàng', N'Tablet TCP Chụp hình mọi góc cạnh không đẹp không lấy tiền', 'AD_0001'),
('SP_0012', N'Xiaomi 14', '/LayoutElectronic/img/featured/featuredt-11.jpg', 20, 90, N'Còn hàng', N'Xiaomi 14 Chụp hình mọi góc cạnh không đẹp không lấy tiền', 'AD_0001'),
('SP_0013', N'Vivo V30e', '/LayoutElectronic/img/featured/featuredt-12.jpg', 20, 90, N'Còn hàng', N'Vivo V30e Chụp hình mọi góc cạnh không đẹp không lấy tiền', 'AD_0001'),
('SP_0014', N'Reno 10 Pro+', '/LayoutElectronic/img/featured/featuredt-13.jpg', 20, 100, N'Còn hàng', N'Reno 10 Pro+ Chụp hình mọi góc cạnh không đẹp không lấy tiền', 'AD_0001'),
('SP_0015', N'Reno 12F', '/LayoutElectronic/img/featured/featuredt-14.jpg', 20, 100, N'Còn hàng', N'Reno 12F Chụp hình mọi góc cạnh không đẹp không lấy tiền', 'AD_0001'),
('SP_0016', N'Redmi note 11', '/LayoutElectronic/img/featured/featuredt-15.jpg', 0, 100, N'Hết hàng', N'Redmi note 11 Chụp hình mọi góc cạnh không đẹp không lấy tiền', 'AD_0001')

CREATE TABLE GIOHANG_SANPHAM
(
	ID_GIOHANG INT IDENTITY(1,1),
	MA_GIOHANG VARCHAR(20) PRIMARY KEY,
	MA_SANPHAM VARCHAR(20),
	TEN_SANPHAM NVARCHAR(100),
	HINH_SANPHAM NVARCHAR(100),
	MA_NGUOIDUNG VARCHAR(20), --để lưu tài khoản mua không show lên
	GIA_SANHAM FLOAT,
	SOLUONG_SANPHAM INT,
	TINHTRANG_GIOHANG NVARCHAR(50)
)
GO

-- Thêm khóa ngoại cho bảng SANPHAM
ALTER TABLE SANPHAM
ADD CONSTRAINT FK_SANPHAM_ADMIN FOREIGN KEY (MA_ADMIN) REFERENCES TAIKHOAN_ADMIN(MA_ADMIN)
GO

-- Thêm khóa ngoại cho bảng GIOHANG_SANPHAM (liên kết với SANPHAM và TAIKHOAN)
ALTER TABLE GIOHANG_SANPHAM
ADD CONSTRAINT FK_GIOHANG_SANPHAM FOREIGN KEY (MA_SANPHAM) REFERENCES SANPHAM(MA_SANPHAM)
GO

ALTER TABLE GIOHANG_SANPHAM
ADD CONSTRAINT FK_GIOHANG_NGUOIDUNG FOREIGN KEY (MA_NGUOIDUNG) REFERENCES TAIKHOAN_NGUOIDUNG(MA_NGUOIDUNG)
GO

--============================================================================--
--********************************ĐĂNG NHẬP*************************************
--============================================================================--

CREATE PROCEDURE SP_DangNhap_TAIKHOAN_ADMIN
    @EMAIL_ADMIN NVARCHAR(100),
    @MATKHAU_ADMIN NVARCHAR(50)
AS
BEGIN
    DECLARE @STATUS_ADMIN INT;

    IF EXISTS (SELECT 1 FROM dbo.TAIKHOAN_ADMIN WHERE EMAIL_ADMIN = @EMAIL_ADMIN AND MATKHAU_ADMIN = @MATKHAU_ADMIN)
        SET @STATUS_ADMIN = 1;
    ELSE 
        SET @STATUS_ADMIN = 0;

    SELECT @STATUS_ADMIN;
END
GO

CREATE PROCEDURE SP_DangNhap_TAIKHOAN_NGUOIDUNG
    @EMAIL_NGUOIDUNG NVARCHAR(100),
    @MATKHAU_NGUOIDUNG NVARCHAR(50)
AS
BEGIN
    DECLARE @STATUS_NGUOIDUNG INT;

    IF EXISTS (SELECT 1 FROM dbo.TAIKHOAN_NGUOIDUNG WHERE EMAIL_NGUOIDUNG = @EMAIL_NGUOIDUNG AND MATKHAU_NGUOIDUNG = @MATKHAU_NGUOIDUNG)
        SET @STATUS_NGUOIDUNG = 1;
    ELSE 
        SET @STATUS_NGUOIDUNG = 0;

    SELECT @STATUS_NGUOIDUNG;
END
GO


--============================================================================--
--******************************TÀI KHOẢN ADMIN********************************
--============================================================================--
--ĐỌC TÀI KHOẢN
CREATE PROCEDURE SP_HienTatCa_TAIKHOAN
AS
BEGIN
    SELECT * FROM TAIKHOAN_ADMIN, TAIKHOAN_NGUOIDUNG;
END
GO

-- THEM
CREATE PROCEDURE SP_Them_TAIKHOAN_ADMIN
    @EMAIL_ADMIN NVARCHAR(100),
    @MATKHAU_ADMIN NVARCHAR(50)
AS
BEGIN
    DECLARE @MA_ADMIN NVARCHAR(20);
    DECLARE @ID_ADMIN INT;

    -- Lấy ID admin mới nhất và tăng lên 1
    SELECT @ID_ADMIN = ISNULL(MAX(ID_ADMIN), 0) + 1 FROM TAIKHOAN_ADMIN;

    -- Tạo mã admin mới với định dạng 'AD_XXXX'
    SELECT @MA_ADMIN = 'AD_' + RIGHT('0000' + CAST(@ID_ADMIN AS NVARCHAR(4)), 4);

    -- Chèn dữ liệu vào bảng TAIKHOAN_ADMIN
    INSERT INTO TAIKHOAN_ADMIN (MA_ADMIN, EMAIL_ADMIN, MATKHAU_ADMIN)
    VALUES (@MA_ADMIN, @EMAIL_ADMIN, @MATKHAU_ADMIN);
END
GO

CREATE PROCEDURE SP_Them_TAIKHOAN_NGUOIDUNG
    @TEN_NGUOIDUNG NVARCHAR(100),
    @EMAIL_NGUOIDUNG NVARCHAR(100),
    @MATKHAU_NGUOIDUNG NVARCHAR(50)
AS
BEGIN
    DECLARE @MA_NGUOIDUNG NVARCHAR(20);
    DECLARE @ID_NGUOIDUNG INT;

    -- Lấy ID người dùng mới nhất và tăng lên 1
    SELECT @ID_NGUOIDUNG = ISNULL(MAX(ID_NGUOIDUNG), 0) + 1 FROM TAIKHOAN_NGUOIDUNG;

    -- Tạo mã người dùng mới với định dạng 'ND_XXXX'
    SELECT @MA_NGUOIDUNG = 'ND_' + RIGHT('0000' + CAST(@ID_NGUOIDUNG AS NVARCHAR(4)), 4);

    -- Chèn dữ liệu vào bảng TAIKHOAN_NGUOIDUNG
    INSERT INTO TAIKHOAN_NGUOIDUNG (MA_NGUOIDUNG, EMAIL_NGUOIDUNG, MATKHAU_NGUOIDUNG)
    VALUES (@MA_NGUOIDUNG, @EMAIL_NGUOIDUNG, @MATKHAU_NGUOIDUNG);
END
GO


--XÓA TÀI KHOẢN
CREATE PROCEDURE SP_Xoa_TAIKHOAN_ADMIN
    @MA_ADMIN VARCHAR(20)
AS
BEGIN
    DELETE FROM TAIKHOAN_ADMIN WHERE MA_ADMIN = @MA_ADMIN;
END
GO

CREATE PROCEDURE SP_Xoa_TAIKHOAN_NGUOIDUNG
    @MA_NGUOIDUNG VARCHAR(20)
AS
BEGIN
    DELETE FROM TAIKHOAN_NGUOIDUNG WHERE MA_NGUOIDUNG = @MA_NGUOIDUNG;
END
GO

--SỮA
CREATE PROCEDURE SP_Sua_TAIKHOAN_ADMIN
    @MA_ADMIN VARCHAR(20),
    @EMAIL_ADMIN NVARCHAR(100),
    @MATKHAU_ADMIN NVARCHAR(50)
AS
BEGIN
    UPDATE TAIKHOAN_ADMIN
    SET EMAIL_ADMIN = @EMAIL_ADMIN,
        MATKHAU_ADMIN = @MATKHAU_ADMIN
    WHERE MA_ADMIN = @MA_ADMIN;
END
GO

CREATE PROCEDURE SP_Sua_TAIKHOAN_NGUOIDUNG
    @MA_NGUOIDUNG VARCHAR(20),
    @EMAIL_NGUOIDUNG NVARCHAR(100),
    @MATKHAU_NGUOIDUNG NVARCHAR(50)
AS
BEGIN
    UPDATE TAIKHOAN_NGUOIDUNG
    SET EMAIL_NGUOIDUNG = @EMAIL_NGUOIDUNG,
        MATKHAU_NGUOIDUNG = @MATKHAU_NGUOIDUNG
    WHERE MA_NGUOIDUNG = @MA_NGUOIDUNG;
END
GO


--TÌM KIẾM TÀI KHOẢN
CREATE PROCEDURE SP_TimKiem_TAIKHOAN_ADMIN
    @EMAIL_ADMIN NVARCHAR(100)
AS
BEGIN
    SELECT * FROM TAIKHOAN_ADMIN
    WHERE EMAIL_ADMIN LIKE '%' + @EMAIL_ADMIN + '%';
END
GO

CREATE PROCEDURE SP_TimKiem_TAIKHOAN_NGUOIDUNG
    @TEN_NGUOIDUNG NVARCHAR(100)
AS
BEGIN
    SELECT * FROM TAIKHOAN_NGUOIDUNG
    WHERE EMAIL_NGUOIDUNG LIKE '%' + @TEN_NGUOIDUNG + '%';
END
GO

--============================================================================--
--*********************************SẢN PHẨM************************************
--============================================================================--
--ĐỌC SẢN PHẨM 
CREATE OR ALTER PROCEDURE SP_LayTatCaSanPham
AS
BEGIN
    SELECT 
        MA_SANPHAM, 
        TEN_SANPHAM, 
		HINH_SANPHAM,
        SOLUONG_SANPHAM, 
        GIA_SANPHAM, 
        TINHTRANG_SANPHAM, 
        MOTA_SANPHAM, 
        MA_ADMIN
    FROM SANPHAM;
END
GO



CREATE OR ALTER PROCEDURE SP_LayTatCaSanPhamTheoMa
    @MA_SANPHAM VARCHAR(20)
AS
BEGIN
    SELECT 
        MA_SANPHAM, 
        TEN_SANPHAM, 
        SOLUONG_SANPHAM, 
        GIA_SANPHAM, 
        TINHTRANG_SANPHAM, 
        MOTA_SANPHAM, 
        MA_ADMIN
    FROM SANPHAM
    WHERE MA_SANPHAM = @MA_SANPHAM;
END
GO


--THÊM SẢN PHẨM
CREATE PROCEDURE SP_ThemSanPham
    @TEN_SANPHAM NVARCHAR(100),
    @SOLUONG_SANPHAM INT,
    @GIA_SANPHAM FLOAT,
    @TINHTRANG_SANPHAM NVARCHAR(50),
    @MOTA_SANPHAM NVARCHAR(500),
    @EMAIL_ADMIN NVARCHAR(100),
	@EMAIL_NGUOIDUNG NVARCHAR(100)
AS
BEGIN
    DECLARE @MA_SANPHAM VARCHAR(20);
    DECLARE @ID_SANPHAM INT;
    DECLARE @MA_ADMIN VARCHAR(20);
	DECLARE @MA_NGUOIDUNG VARCHAR(20);

    -- Lấy ID sản phẩm mới nhất và tăng lên 1
    SELECT @ID_SANPHAM = ISNULL(MAX(ID_SANPHAM), 0) + 1 FROM SANPHAM;

    -- Tạo mã sản phẩm mới với định dạng 'SP_XXXX'
    SELECT @MA_SANPHAM = 'SP_' + RIGHT('0000' + CAST(@ID_SANPHAM AS NVARCHAR(4)), 4);

    -- Tìm mã admin dựa trên email
    SELECT @MA_ADMIN = MA_ADMIN FROM TAIKHOAN_ADMIN WHERE EMAIL_ADMIN = @EMAIL_ADMIN;

	SELECT @MA_NGUOIDUNG = MA_NGUOIDUNG FROM TAIKHOAN_NGUOIDUNG WHERE EMAIL_NGUOIDUNG = @EMAIL_NGUOIDUNG;

    -- Chèn sản phẩm mới vào bảng SANPHAM
    INSERT INTO SANPHAM (MA_SANPHAM, TEN_SANPHAM, SOLUONG_SANPHAM, GIA_SANPHAM, TINHTRANG_SANPHAM, MOTA_SANPHAM, MA_ADMIN)
    VALUES (@MA_SANPHAM, @TEN_SANPHAM, @SOLUONG_SANPHAM, @GIA_SANPHAM, @TINHTRANG_SANPHAM, @MOTA_SANPHAM, @MA_ADMIN);
END
GO



--XÓA SẢN PHẨM
CREATE PROCEDURE SP_XoaSanPham
    @MA_SANPHAM VARCHAR(20)
AS
BEGIN
    -- Đánh dấu tình trạng sản phẩm là "Hết hàng"
    UPDATE SANPHAM
    SET TINHTRANG_SANPHAM = N'HẾT HÀNG'
    WHERE MA_SANPHAM = @MA_SANPHAM;
END
GO


--TÌM KIẾM SẢN PHẨM
CREATE PROCEDURE SP_TimKiemSanPham
    @TEN_SANPHAM NVARCHAR(100)
AS
BEGIN
    SELECT MA_SANPHAM, TEN_SANPHAM, SOLUONG_SANPHAM, GIA_SANPHAM, TINHTRANG_SANPHAM, MOTA_SANPHAM, MA_ADMIN FROM SANPHAM
    WHERE TEN_SANPHAM LIKE '%' + @TEN_SANPHAM + '%';
END
GO


--============================================================================--
--*********************************GIỎ HÀNG************************************
--============================================================================--
--HIỆN GIỎ HÀNG 
CREATE PROCEDURE SP_HienThiGioHang
    @MA_NGUOIDUNG VARCHAR(20)
AS
BEGIN
    SELECT 
        MA_SANPHAM,
        TEN_SANPHAM,
        GIA_SANHAM,
        SOLUONG_SANPHAM,
        HINH_SANPHAM
    FROM GIOHANG_SANPHAM
    WHERE MA_NGUOIDUNG = @MA_NGUOIDUNG;
END
GO

--THÊM GIỎ HÀNG
CREATE PROCEDURE SP_ThemGioHang
    @MA_SANPHAM VARCHAR(20),
    @SOLUONG_SANPHAM INT,
    @EMAIL_NGUOIDUNG NVARCHAR(100)
AS
BEGIN
    DECLARE @MA_GIOHANG VARCHAR(20);
    DECLARE @ID_GIOHANG INT;
    DECLARE @TEN_SANPHAM NVARCHAR(100);
    DECLARE @HINH_SANPHAM NVARCHAR(100);
    DECLARE @GIA_SANHAM FLOAT;
    DECLARE @MA_NGUOIDUNG VARCHAR(20);

    -- Lấy tên, hình và giá sản phẩm từ bảng SANPHAM
    SELECT 
        @TEN_SANPHAM = TEN_SANPHAM,
        @HINH_SANPHAM = HINH_SANPHAM,
        @GIA_SANHAM = GIA_SANPHAM
    FROM SANPHAM 
    WHERE MA_SANPHAM = @MA_SANPHAM;

    -- Lấy mã người dùng dựa trên email
    SELECT @MA_NGUOIDUNG = MA_NGUOIDUNG FROM TAIKHOAN_NGUOIDUNG WHERE EMAIL_NGUOIDUNG = @EMAIL_NGUOIDUNG;

    -- Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
    IF EXISTS (SELECT 1 FROM GIOHANG_SANPHAM WHERE MA_SANPHAM = @MA_SANPHAM AND MA_NGUOIDUNG = @MA_NGUOIDUNG)
    BEGIN
        -- Nếu có, cập nhật số lượng sản phẩm
        UPDATE GIOHANG_SANPHAM
        SET SOLUONG_SANPHAM = SOLUONG_SANPHAM + @SOLUONG_SANPHAM
        WHERE MA_SANPHAM = @MA_SANPHAM AND MA_NGUOIDUNG = @MA_NGUOIDUNG;
    END
    ELSE
    BEGIN
        -- Tạo ID giỏ hàng mới
        SELECT @ID_GIOHANG = ISNULL(MAX(ID_GIOHANG), 0) + 1 FROM GIOHANG_SANPHAM;
        SELECT @MA_GIOHANG = 'GH_' + RIGHT('0000' + CAST(@ID_GIOHANG AS NVARCHAR(4)), 4);

        -- Thêm sản phẩm mới vào giỏ hàng
        INSERT INTO GIOHANG_SANPHAM (MA_GIOHANG, MA_SANPHAM, TEN_SANPHAM, HINH_SANPHAM, MA_NGUOIDUNG, GIA_SANHAM, SOLUONG_SANPHAM, TINHTRANG_GIOHANG)
        VALUES (@MA_GIOHANG, @MA_SANPHAM, @TEN_SANPHAM, @HINH_SANPHAM, @MA_NGUOIDUNG, @GIA_SANHAM, @SOLUONG_SANPHAM, N'Trong giỏ hàng');
    END
END
GO


--XÓA GIỎ HÀNG
CREATE PROCEDURE SP_XoaSanPhamGioHang
    @MA_SANPHAM VARCHAR(20),
    @MA_NGUOIDUNG VARCHAR(20)
AS
BEGIN
    -- Kiểm tra xem sản phẩm có tồn tại trong giỏ hàng của người dùng không
    IF EXISTS (SELECT 1 FROM GIOHANG_SANPHAM WHERE MA_SANPHAM = @MA_SANPHAM AND MA_NGUOIDUNG = @MA_NGUOIDUNG)
    BEGIN
        -- Nếu có, xóa sản phẩm khỏi giỏ hàng
        DELETE FROM GIOHANG_SANPHAM
        WHERE MA_SANPHAM = @MA_SANPHAM AND MA_NGUOIDUNG = @MA_NGUOIDUNG;
    END
END
GO

GO


--============================================================================--
--*************************LẤY DANH SACH MÃ ĐỂ THÊM *****************************
--============================================================================--
CREATE PROCEDURE SP_LayDanhSachMaSanPham
AS
BEGIN
    SELECT MA_SANPHAM, TEN_SANPHAM
    FROM SANPHAM;
END
GO

CREATE PROCEDURE SP_LayDanhSachMaNguoiDung
AS
BEGIN
    SELECT MA_NGUOIDUNG, EMAIL_NGUOIDUNG
    FROM TAIKHOAN_NGUOIDUNG;
END
GO


-- DANH SÁCH MÃ SẢO PHẨM
CREATE PROCEDURE SP_LayDanhSachTenSanPham
AS
BEGIN
    -- Lấy danh sách tên sản phẩm từ bảng SANPHAM
    SELECT MA_SANPHAM FROM SANPHAM;
END
GO
